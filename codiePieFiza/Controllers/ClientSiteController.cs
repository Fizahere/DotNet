using codiePieFiza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codiePieFiza.Controllers
{
    public class ClientSiteController : Controller
    {
        private readonly MyDBContext _dBContext;
        public ClientSiteController(MyDBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public IActionResult Index()
        {
            var products = _dBContext.Product.
                Skip(0).Take(5)
                .ToList();
            return View(products);
        }

        public IActionResult CategoryDetail(int id)
        {
            var product = _dBContext.Product.Where(e => e.CategoryId == id).ToList();
            return View(product);
        }
        public IActionResult ProductDetail(int id)
        {
            ViewBag.product = _dBContext.Product.Where(e => e.ProductId == id).FirstOrDefault();
            return View();
        }
    }
}
