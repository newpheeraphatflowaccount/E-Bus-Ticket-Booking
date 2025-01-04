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

		public StudentsController(IStudentRepo studentRepo, ISubjectRepo subjectRepo)
		{
			_studentRepo = studentRepo;
			_subjectRepo = subjectRepo;
		}

		public async Task<IActionResult> Index()
		{
			var students = await _studentRepo.GetAll();
			return View(students);
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
			await _studentRepo.Delete(id);
			return RedirectToAction("Index");
		}
	}
}

/// ............jacob...............[textbox]
/// [checkbox]English	[]Maths	[]Science []Social
/// [Submit]