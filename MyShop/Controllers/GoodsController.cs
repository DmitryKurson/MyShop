using Microsoft.AspNetCore.Mvc;
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
                .GroupBy(g => g.producer)
                .ToListAsync();



           
            return View(goods_by_producer);
        }

    }
}
