using codiePieFiza.Data;
using codiePieFiza.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace codiePieFiza.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyDBContext _dBContext;
            public DashboardController(MyDBContext dbContext)
        {
            _dBContext = dbContext;
        }

        ///dashboard index 
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Login");
            }
            return View();
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
               
            return RedirectToAction("Index");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("name");
            return RedirectToAction("Login");
        }
        ///Auth end
        
        ///Crud start
        ///Category
       public IActionResult Categories()
        {
            return View();
       }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            var check= _dBContext.Category.Where(a=>a.Name == c.Name).FirstOrDefault();
            if(check!=null)
            {
                ViewBag.msg = "category already exist!";
            }
            else
            {
                _dBContext.Category.Add(c);
                if (_dBContext.SaveChanges()>0)
                {
                ViewBag.msg = "Record Inserted!";                
                    ///return RedirectToAction("Categories");
                }
                
            }
            return View();
        }
        ///Crud end


    }
}
