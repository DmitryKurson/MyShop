using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;

namespace MyShop.Controllers
{
    public class ClientController : Controller
    {
        MyShopDBContext db;
        public ClientController(MyShopDBContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index_A()
        {
            List<Client> clients = await db.client.ToListAsync();
            return View(clients);
        }

        public IActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client clients)
        {
            db.client.Add(clients);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Client clients)
        {
            db.client.Update(clients);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Client? client = await db.client.FirstOrDefaultAsync(c => c.id == id);
                if (client != null)
                {
                    return View(client);
                }
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Client? client = await db.client.FirstOrDefaultAsync(c => c.id == id);
                if (client != null)
                {
                    db.client.Remove(client);
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
