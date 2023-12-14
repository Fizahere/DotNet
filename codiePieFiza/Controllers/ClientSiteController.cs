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
            var products = _dBContext.Product.ToList();
            return View(products);
        }
    }
}
