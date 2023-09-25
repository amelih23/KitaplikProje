using KitaplikProje.Models;
using KitaplikProje.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using X.PagedList;

namespace KitaplikProje.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        Context c = new Context();
        public IActionResult Index4(int page=1)
        {
            return View(productRepository.TList("Category").ToPagedList(page,4));//product vieew kategori adı getirmek için döndürdük
        }
        [HttpGet]//sayfa yüklendiği zaman çalışır 
        public IActionResult ProductAdd()
        {//burda bi tane nesne listesi oluşturacaz daha sonra oluşturmuş olduğumuz bu nesneyi bir viewbag yardımıyla dropdown a view tarafı için gönderecz ordanda verileri istelemeyi yapacaz
            List<SelectListItem> values = (from x in c.Categories.ToList()//amaç kategori adını çekebilmek ekleme işleminde
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;//viewbag -controllerdan view tarafında veri gönderir
            return View();
        }
        [HttpPost]
        public IActionResult ProductAdd(Product p)
        {
            productRepository.TAdd(p);
            return RedirectToAction("Index4");
        }
        public IActionResult ProductDelete(int id)
        {
            productRepository.TDelete(new Product { BookID = id });
            return RedirectToAction("Index4");
        }
        public IActionResult ProductGet(int id)
        {
            var x = productRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()//amaç kategori adını çekebilmek ekleme işleminde
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            Product prt = new Product()
            {
                BookID = x.BookID,
                CategoryID=x.CategoryID,
                BookName = x.BookName,
                BookWrites = x.BookWrites,
                BookPublishHouse = x.BookPublishHouse,
                BookPublishYear = x.BookPublishYear,
                BookImageURL = x.BookImageURL,
                BookSummary = x.BookSummary,
                BookStock = x.BookStock,

            };
            return View(prt);
        }
        [HttpPost]
        public IActionResult ProductUpdate(Product p)
        {
            var x = productRepository.TGet(p.BookID);
            x.BookID = p.BookID;
            x.CategoryID = p.CategoryID;
            x.BookName = p.BookName;
            x.BookWrites = p.BookWrites;
            x.BookPublishHouse = p.BookPublishHouse;
            x.BookPublishYear = p.BookPublishYear;
            x.BookImageURL = p.BookImageURL;
            x.BookSummary = p.BookSummary;
            x.BookStock = p.BookStock;
            productRepository.TUpdate(x);
            return RedirectToAction("Index4");
        }
        
    }
}
