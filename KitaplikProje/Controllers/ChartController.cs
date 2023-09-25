using KitaplikProje.Data;
using Microsoft.AspNetCore.Mvc;
using KitaplikProje.Models;
namespace KitaplikProje.Controllers
{
    public class ChartController : Controller
    {
        
        public IActionResult Index9()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProductList());
        }
        public List<Class2> ProductList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c=new Context())
            {
                cs2 = c.Products.Select(x => new Class2
                {
                    bname = x.BookName,
                    bstock = x.BookStock,
                }).ToList();
            }
            return cs2;
        }
    }
}
