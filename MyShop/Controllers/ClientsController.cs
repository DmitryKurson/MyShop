using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;

namespace MyShop.Controllers
{
    public class ClientsController : Controller
    {
        MyShopDBContext db;
        public ClientsController(MyShopDBContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Clients> clients = await db.clients.ToListAsync();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Clients clients)
        {
            db.clients.Add(clients);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Clients clients)
        {
            db.clients.Update(clients);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Clients? client = await db.clients.FirstOrDefaultAsync(c => c.id == id);
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
                Clients? client = await db.clients.FirstOrDefaultAsync(c => c.id == id);
                if (client != null)
                {
                    db.clients.Remove(client);
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
