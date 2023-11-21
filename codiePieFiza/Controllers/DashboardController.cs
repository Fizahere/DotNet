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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Register r)
        {
            var check = _dBContext.Register.Where(a => a.Email == r.Email && a.Password == r.Password).FirstOrDefault();

                if(check != null)
            {
                ViewBag.data = "Login Successfully!";
            }
            else
            {
                ViewBag.data = "Invalid Credientials!";
            }
                return View();

        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
