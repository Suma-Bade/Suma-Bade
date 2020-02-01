using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmartMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmartMVC.Controllers
{
    public class ItemController : Controller
    {
        public readonly ItemContext _context;
        public ItemController(ItemContext context)
        {
            this._context = context;
        }
        // GET: Item
        List<Item> items = new List<Item>();
        [HttpGet]
        public ActionResult ItemAdd()
        {
            return View(items);
        }

        //[HttpPost]
        //public ActionResult Additems(int id, int price, string item_name, string description, int stock_number, string remarks)
        //{
        //    items.Add(new Item() {ItemId=id,Price=price,Item_Name=item_name,Description=description,Stocknumber=stock_number,Remarks=remarks});
        //    @ViewBag.Msg = "Item Id : " + id + "Item Price : " + price + "Item Name : " + item_name + "Description : " + description + "Stocknumber : " + stock_number + "Remarks : " + remarks;
        //    return View(items);
        //}
        [HttpPost]
        public ActionResult ItemAdd(Item items)
        {
            try
            {

                _context.Add(items);
                _context.SaveChanges();
                ViewBag.message = items.ItemName + "has got successfully addes";
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                ViewBag.message = items.ItemName + "Failed ";
                return View();
            }

        }
        public ActionResult ItemIndex()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        // GET: CookieSession/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CookieSession/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(ItemIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: CookieSession/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        // POST: CookieSession/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sid,UserName,Password,Email,MobileNo")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerExists(item.ItemId))

                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ItemIndex));
            }
            return View(item);
        }


        // GET: CookieSession/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CookieSession/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buyer = await _context.Items.FindAsync(id);
            _context.Items.Remove(buyer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ItemIndex));
        }
        private bool SellerExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}