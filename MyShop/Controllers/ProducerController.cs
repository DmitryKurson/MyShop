using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;

namespace MyShop.Controllers
{
    public class ProducerController : Controller
    {
        MyShopDBContext db;
       
        public ProducerController(MyShopDBContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Producer> producers = await db.producer.ToListAsync();
            return View(producers);
        }

        public IActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
          
            db.producer.Add(producer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Producer producer)
        {
            db.producer.Update(producer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Producer? producer = await db.producer.FirstOrDefaultAsync(c => c.id == id);
                if (producer != null)
                {
                    return View(producer);
                }
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Producer? producer = await db.producer.FirstOrDefaultAsync(c => c.id == id);
                if (producer != null)
                {
                    db.producer.Remove(producer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(int? id)
        {
            return View();
        }
    }
}
