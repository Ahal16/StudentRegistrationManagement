using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Student_Registration.Models;
using Student_Registration.Repository;

namespace Student_Registration.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin([Bind] Logins login)
        {
            int res = _loginRepository.LoginCheck(login);
            if (res == 1)
            {
                TempData["msg"] = "Login Successful";
                return RedirectToAction("ViewModelList", "StudentRecords");
            }
            else
            {
                TempData["msg"] = "Invalid Login Credentials";
                return RedirectToAction("UserLogin", "Login");
            }
            return View();
        }
    }
}
