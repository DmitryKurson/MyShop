using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;
using System.Linq;

namespace MyShop.Controllers
{
    public class GoodsController : Controller
    {
        MyShopDBContext db;
        public GoodsController(MyShopDBContext context)
        {
            db = context;
        }

       


        public async Task<ActionResult> Index_A()
        {
            
            List<Goods> goods = await db.goods.ToListAsync();
            return View(goods);
        }

        public async Task<ActionResult> Index_U()
        {
            var goods_by_producer = await db.goods
                .Include(g => g.Producer)
                .GroupBy(g => g.Producer)
                .ToListAsync();



           
            return View(goods_by_producer);
        }

        public IActionResult Create()
        {
            ViewBag.Producers = new SelectList(db.producer, "id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.goods.Add(goods);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Producers = new SelectList(db.producer, "id", "title");
            return View(goods);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Goods goods)
        {
            db.goods.Update(goods);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Goods? goods = await db.goods.FirstOrDefaultAsync(c => c.id == id);
                if (goods != null)
                {
                    return View(goods);
                }
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Goods? goods = await db.goods.FirstOrDefaultAsync(c => c.id == id);
                if (goods != null)
                {
                    db.goods.Remove(goods);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
