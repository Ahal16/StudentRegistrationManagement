using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Student_Registration.Models;

namespace Student_Registration.Repository
{
    public interface ILoginRepository
    {
        public int LoginCheck(Logins login);
    }
}
