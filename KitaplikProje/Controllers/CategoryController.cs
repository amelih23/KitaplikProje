using KitaplikProje.Models;
using KitaplikProje.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KitaplikProje.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index3(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(categoryRepository.List(x => x.CategoryName == p));
            }
            
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p) 
        {
            if (!ModelState.IsValid)//eğer farklıysa...
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(p);
            return RedirectToAction("Index3");
        }
        public IActionResult CategoryGet(int id)
        {
            var x=categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryID = x.CategoryID
            };
            return View(ct);
        }
      
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {

            var x = categoryRepository.TGet(p.CategoryID);
            if (x != null)
            {
                x.CategoryName = p.CategoryName;
                x.CategoryDescription = p.CategoryDescription;

                categoryRepository.TUpdate(x);

            }

            return RedirectToAction("Index3");

        }
        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            categoryRepository.TDelete(x);
            
            return RedirectToAction("Index3");
        }

    }
}
