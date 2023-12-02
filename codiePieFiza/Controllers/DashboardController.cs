using codiePieFiza.Data;
using codiePieFiza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace codiePieFiza.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyDBContext _dBContext;
        private readonly IWebHostEnvironment _env;
        public DashboardController(MyDBContext dbContext,IWebHostEnvironment env)
        {
            _dBContext = dbContext;
            _env = env;
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
        ///Brand
        public IActionResult Brands()
        {
            return View();
        }
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(Brand b)
        {
            var check = _dBContext.Brand.Where(a => a.BrandName == b.BrandName).FirstOrDefault();
            if (check != null)
            {
                ViewBag.msg = "Brand already exist!";
            }
            else
            {
                _dBContext.Brand.Add(b);
                if (_dBContext.SaveChanges() > 0)
                {
                    ViewBag.msg = "Record Inserted!";
                    ///return RedirectToAction("Brand");
                }

            }
            return View();
        }
        ///Product
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            ViewBag.Category = new SelectList(_dBContext.Category, "CategoryId", "Name");
            ViewBag.Brand = new SelectList(_dBContext.Brand, "BrandId", "BrandName");
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p,IFormFile ProductImage)
        {
            ViewBag.Category = new SelectList(_dBContext.Category, "CategoryId", "Name");
            ViewBag.Brand = new SelectList(_dBContext.Brand, "BrandId", "BrandName");
             ///Path.Combine(Iwe)

            var check = _dBContext.Product.Where(a => a.ProductName == p.ProductName).FirstOrDefault();
            if (check != null)
            {
                ViewBag.msg = "Product already exist!";
            }
            else
            {
                _dBContext.Product.Add(p);
                if (_dBContext.SaveChanges() > 0)
                {
                    ViewBag.msg = "Record Inserted!";
                    ///return RedirectToAction("Brand");
                }

            }
            return View();
        }
        ///Crud end


    }
}
