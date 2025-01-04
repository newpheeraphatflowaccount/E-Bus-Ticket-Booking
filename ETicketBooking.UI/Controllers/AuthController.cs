using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using ETicketBooking.UI.ViewModels.UserInfoViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.UI.Controllers
{
	public class AuthController : Controller
	{
		private readonly IUserRepo _userRepo;

		public AuthController(IUserRepo userRepo)
		{
			_userRepo = userRepo;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login");
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(CreateUserInfoViewModel vm)
		{
			var userInfoFromDb = await _userRepo.Login(vm.UserName, vm.Password);
			HttpContext.Session.SetInt32("userId", userInfoFromDb.Id);
			HttpContext.Session.SetString("userName", userInfoFromDb.UserName);

			return RedirectToAction("Index", "Departments");
		}

		[HttpPost]
		public async Task<IActionResult> Register(CreateUserInfoViewModel vm)
		{
			var userInfo = new UserInfo
			{
				UserName = vm.UserName,
				Password = vm.Password
			};
			await _userRepo.Register(userInfo);
			return RedirectToAction("Login");
		}
	}
}
