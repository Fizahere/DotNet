using codiePieFiza.Data;
using codiePieFiza.Models;
using Microsoft.AspNetCore.Mvc;

namespace codiePieFiza.Controllers
{
    public class AuthController : Controller
    {
        private readonly MyDBContext _dBContext;
        public AuthController(MyDBContext dbContext)
        {
            _dBContext = dbContext;
        }

        ///Auth start
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Register r)
        {
            var check = _dBContext.Register.Where(a => a.Email == r.Email && a.Password == r.Password).FirstOrDefault();
            HttpContext.Session.SetString("name", check.Name);
            if (check != null)
            {
                return Redirect("~/dashboard/index"); 
                           
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("name");
            return RedirectToAction("Login");
        }
        ///Auth end
    }
}
