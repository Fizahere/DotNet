using codiePieFiza.Data;
using codiePieFiza.Models;
using Microsoft.AspNetCore.Mvc;

namespace codiePieFiza.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyDBContext _dBContext;
            public DashboardController(MyDBContext dbContext)
        {
            _dBContext = dbContext;
        }
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
               
            return RedirectToAction("Index");

        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("name");
            return RedirectToAction("Login");
        }

    }
}
