using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using ETicketBooking.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.UI.Controllers
{
	public class StudentsController : Controller
	{
		private readonly IStudentRepo _studentRepo;
		private readonly ISubjectRepo _subjectRepo;
		private string StudentImage = "StudentImage";
		private IUtilityRepo _utilityRepo;

		public StudentsController(IStudentRepo studentRepo, ISubjectRepo subjectRepo, IUtilityRepo utilityRepo)
		{
			_studentRepo = studentRepo;
			_subjectRepo = subjectRepo;
			_utilityRepo = utilityRepo;
		}

		public async Task<IActionResult> Index()
		{
			List<StudentListViewModel> studentListViewModels = new List<StudentListViewModel>();
			var students = await _studentRepo.GetAll();
			foreach (var student in students)
			{
				studentListViewModels.Add(new StudentListViewModel
				{
					Id = student.Id,
					Name = student.Name,
					ProfileImageUrl = student.ProfileImageUrl
				});
			}
			return View(studentListViewModels);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var subjects = await _subjectRepo.GetAll();
			var vm = new CreateStudentViewModel();
			foreach (var subject in subjects)
			{
				vm.SubjectList.Add(new CheckBoxTable 
				{ 
					Id = subject.Id,
					IsChecked = false,
					Text = subject.Name
				});
			}
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateStudentViewModel vm)
		{
			var student = new Student
			{
				Name = vm.Name
			};
			if (vm.ImagePath != null)
			{
				student.ProfileImageUrl = await _utilityRepo.SaveImagePath(StudentImage, vm.ImagePath);
			}

			var selectedSubjectIds = vm.SubjectList.Where(x => x.IsChecked).Select(x => x.Id).ToList();
			foreach (var subjectId in selectedSubjectIds)
			{
				student.StudentSubjects.Add(new StudentSubject
				{
					SubjectId = subjectId
				});
			}
			await _studentRepo.Insert(student);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var student = await _studentRepo.GetById(id);
			var existingSubjectIds = student.StudentSubjects.Select(x => x.SubjectId).ToList();

			var subjects = await _subjectRepo.GetAll();
			var vm = new StudentViewModel();
			vm.Name = student.Name;
			vm.Id = student.Id;
			vm.ProfileImage = student.ProfileImageUrl;
			foreach (var subject in subjects)
			{
				vm.SubjectList.Add(new CheckBoxTable
				{
					Id = subject.Id,
					IsChecked = existingSubjectIds.Contains(subject.Id),
					Text = subject.Name
				}
				);
			}
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(StudentViewModel vm)
		{
			var student = await _studentRepo.GetById(vm.Id);
			var existingSubjectIds = student.StudentSubjects.Select(x => x.SubjectId).ToList();
			student.Name = vm.Name;
			if (vm.ImagePath != null)
			{
				student.ProfileImageUrl = await _utilityRepo.EditFilePath(StudentImage, vm.ImagePath, student.ProfileImageUrl);
			}

			var selectedSubjectIds = vm.SubjectList.Where(x => x.IsChecked).Select(x => x.Id).ToList();

			var toAdd = selectedSubjectIds.Except(existingSubjectIds).ToList();
			var toRemove = existingSubjectIds.Except(selectedSubjectIds).ToList();

			foreach (var subjectId in toRemove)
			{
				var studentSubject = student.StudentSubjects.Where(x => x.SubjectId == subjectId).FirstOrDefault();
				student.StudentSubjects.Remove(studentSubject);
			}

			foreach (var subjectId in toAdd)
			{
				student.StudentSubjects.Add(new StudentSubject
				{
					SubjectId = subjectId
				});
			}
			await _studentRepo.Update(student);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var student = await _studentRepo.GetById(id);
			await _studentRepo.Delete(id);
			await _utilityRepo.DeleteFile(student.ProfileImageUrl, StudentImage);
			return RedirectToAction("Index");
		}
	}
}

/// ............jacob...............[textbox]
/// [checkbox]English	[]Maths	[]Science []Social
/// [Submit]