using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Controllers
{
    public class ProductController : Controller
    {
        MyShopDBContext db;
        public ProductController(MyShopDBContext context)
        {
            db = context;
        }

       


        public async Task<ActionResult> Index_A()
        {
            
            List<Product> products = await db.product.ToListAsync();
            return View(products);
        }

        public async Task<ActionResult> Index_U()
        {
            var product_by_producer = await db.product
                .Include(g => g.Producer)
                .GroupBy(g => g.Producer)
                .ToListAsync();    
            return View(product_by_producer);
        }

        public IActionResult Create()
        {
            ViewBag.Producers = new SelectList(db.producer, "id", "title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {

            product.ProductOrders = new List<ProductOrder>();
            product.Producer = await db.producer.FindAsync(product.ProducerId);
            db.product.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("index_a");
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Product product)
        {
            db.product.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("index_a");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Product? product = await db.product.FirstOrDefaultAsync(c => c.id == id);
                if (product != null)
                {
                    return View(product);
                }
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product? product = await db.product.FirstOrDefaultAsync(c => c.id == id);
                if (product != null)
                {
                    db.product.Remove(product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("index_a");
                }
            }
            return NotFound();
        }

    }
}
