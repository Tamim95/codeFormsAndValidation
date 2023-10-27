using codeFormsAndValidation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace codeFormsAndValidation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult WeaklyTypedLogin()
        {

            return View();
        }
        [HttpPost]
        public IActionResult LoginPost(string username, string password) //WeaklyTped Form passing parameter
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            return View();
        }
        //--------------StrongTyped Form---------------
        public IActionResult StrongTypedLogin()
        {
            return View();
        }
        //have to create a success method
        public IActionResult LoginSuccess(LoginViewModel login)
        {
            if(login.Username!=null && login.Password != null)
            {
                if(login.Username.Equals("admin") && login.Password.Equals("admin"))
                {
                    ViewBag.Message = "You are successfully logged in.";
                    return View();
                }
            }
            ViewBag.Message = "Invalid Credintials.";
            return View(login);
        }

        //------------Model Binding-----------------
        public IActionResult UserDetail()
        {
            var user = new LoginViewModel() { Username = "Bhawna", Password = "1234" };
            
            return View(user);
        }
        public IActionResult UserList()
        {
            var users = new List<LoginViewModel>()
            {
                new LoginViewModel() {Username="Lucy", Password="1234"},
                new LoginViewModel() {Username="Maria", Password="1234"}
            };
            return View(users);
        }
        


    }
}
