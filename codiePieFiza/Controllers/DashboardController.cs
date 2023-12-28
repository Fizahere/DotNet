using codiePieFiza.Data;
using codiePieFiza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
     
        ///Crud start
        ///Category
       public IActionResult Categories()
        {
            return View(_dBContext.Category.ToList());
          
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
                _dBContext.Category.Add(c);
                _dBContext.SaveChanges();
                return RedirectToAction("Categories");
        }
        public IActionResult EditCategory(int id)
        {
            var CategoryToEdit = _dBContext.Category.Find(id);
            return View(CategoryToEdit);
        }
        [HttpPost]
        public IActionResult EditCategory(Category c,int id)
        {
           var check= _dBContext.Category.Where(a=>a.CategoryId==id).FirstOrDefault();
            check.Name = c.Name;
            _dBContext.SaveChanges();
            return RedirectToAction("Categories");
        }

        public IActionResult DeleteCategory(int id)
        {
            Category categoryToDelete = _dBContext.Category.Find(id);
            _dBContext.Category.Remove(categoryToDelete);
            _dBContext.SaveChanges();
            return RedirectToAction("Categories");
        }
        ///Brand
        public IActionResult Brand()
        {
            var data = _dBContext.Brand.ToList();
            return View(data);
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
          
                _dBContext.Brand.Add(b);
                _dBContext.SaveChanges();
                return RedirectToAction("Brand");
            }
        public IActionResult EditBrand(int id)
        {
            var BrandToEdit = _dBContext.Brand.Find(id);
            return View(BrandToEdit);
        }
        [HttpPost]
        public IActionResult EditBrand(Brand b, int id)
        {
            var check = _dBContext.Brand.Where(a => a.BrandId == id).FirstOrDefault();
            check.BrandName = b.BrandName;
            _dBContext.SaveChanges();
            return RedirectToAction("Brand");
        }
        public IActionResult DeleteBrand(int id)
        {
            Brand brandToDelete = _dBContext.Brand.Find(id);
            _dBContext.Brand.Remove(brandToDelete);
            _dBContext.SaveChanges();
            return RedirectToAction("Brand");
        }
        ///Product
        public IActionResult Products()
        {
            return View(_dBContext.Product.Include(p=>p.Brand).Include(p=>p.Category).ToList());
        }
        public IActionResult AddProduct()
        {
            ViewBag.Category = new SelectList(_dBContext.Category, "CategoryId", "Name");
            ViewBag.Brand = new SelectList(_dBContext.Brand, "BrandId", "BrandName");
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p,IFormFile Image)
        {
            ViewBag.Category = new SelectList(_dBContext.Category, "CategoryId", "Name");
            ViewBag.Brand = new SelectList(_dBContext.Brand, "BrandId", "BrandName");
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(Image.FileName));
            Image.CopyTo(new FileStream(path, FileMode.Create));
            p.Image = Image.FileName;
                _dBContext.Product.Add(p);
            _dBContext.SaveChanges();
              
            return RedirectToAction("Products");
            }
        public IActionResult EditProduct(int id)
        {
            var ProductToEdit = _dBContext.Product.Find(id);
            return View(ProductToEdit);
        }
        [HttpPost]
        public IActionResult EditProduct(Product p, int id)
        {
            var check = _dBContext.Product.Where(a => a.ProductId == id).FirstOrDefault();
            check.ProductName = p.ProductName;
            _dBContext.SaveChanges();
            return RedirectToAction("Products");
        }
        public IActionResult DeleteProduct(int id) {
            Product productToDelete = _dBContext.Product.Find(id);
            _dBContext.Product.Remove(productToDelete);
            _dBContext.SaveChanges();
            return RedirectToAction("Products");
        }  

        }
       
        ///Crud end


    
}
