using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ETicketBooking.Repositories.Implementations
{
	public class UtilityRepo : IUtilityRepo
	{
		private readonly IWebHostEnvironment _env;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UtilityRepo(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
		{
			_env = env;
			_httpContextAccessor = httpContextAccessor;
		}

		public Task DeleteFile(string filePath, string DirName)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				return Task.CompletedTask;
			}
			var fileName = Path.GetFileName(filePath);
			var completeFilePath = Path.Combine(_env.WebRootPath, DirName, fileName);
			if (File.Exists(completeFilePath))
			{
				File.Delete(completeFilePath);
			}
			return Task.CompletedTask;
		}

		public async Task<string> EditFilePath(string DirName, IFormFile file, string fullPath)
		{
			await DeleteFile(fullPath, DirName);
			return await SaveImagePath(DirName, file);
		}

		public async Task<string> SaveImagePath(string DirName, IFormFile file)
		{
			string dir = Path.Combine(_env.WebRootPath, DirName);
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			var extension = Path.GetExtension(file.FileName);
			var fileName = $"{Guid.NewGuid()} {extension}";
			string completeFilePath = Path.Combine(dir, fileName);
			using (var memoryStream = new MemoryStream())
			{
				await file.CopyToAsync(memoryStream);
				var content = memoryStream.ToArray();
				await File.WriteAllBytesAsync(completeFilePath, content);
			}
			var basePath = $"{_httpContextAccessor?.HttpContext?.Request.Scheme}://{_httpContextAccessor?.HttpContext?.Request.Host}";
			var fullPath = Path.Combine(basePath, DirName, fileName).Replace("\\", "/");
			return fullPath;

		}
	}
}
