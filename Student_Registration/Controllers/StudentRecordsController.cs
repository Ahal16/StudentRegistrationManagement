using Microsoft.AspNetCore.Mvc;
using Student_Registration.Models;
using Student_Registration.Repository;

namespace Student_Registration.Controllers
{
    public class StudentRecordsController : Controller
    {
        IStudentRecordRepository studentRepository = null;

        //Dependency Injection
        public StudentRecordsController(IStudentRecordRepository _studentRepository) 
        {
            studentRepository = _studentRepository;
        }

        public IActionResult ViewModelList()
        {
            List<StudentViewModel> stdlist = new List<StudentViewModel>();
            stdlist = studentRepository.GetStudentsList().ToList();
            return View(stdlist);
        }

        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterStudent(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.AddNewStudent(student);
                return RedirectToAction("ViewModelList"); 
            }
            return View(student);
        }
    }
}
