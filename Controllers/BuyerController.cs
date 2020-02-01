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
    public class BuyerController : Controller
    {
        public readonly BuyerContext _context;
        public BuyerController(BuyerContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult RegisterBuyer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterBuyer(Buyer b)
        {
            try
            {

                _context.Add(b);
                _context.SaveChanges();
                ViewBag.message = b.Username + "has got successfully registered";
                return RedirectToAction("BuyerLogin");
            }
            catch (Exception e)
            {
                ViewBag.message = b.Username + "Registration failed ";
                return View();
            }

        }
        [HttpGet]
        public ActionResult BuyerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BuyerLogin(Buyer b)
        {
            var logUser = _context.Buyers.Where(e => e.Username == b.Username && e.Password == b.Password).ToList();
            if (logUser.Count == 0)
            {
                ViewBag.message = "Not valid User";
                return View();
            }
            else
            {//to store session values
                HttpContext.Session.SetString("Uname", b.Username);

                ////HttpContext.Session.SetString("lastLogin", DateTime.Now.ToString());
                return RedirectToAction("BuyerDashBoard");
            }

        }

        public ActionResult BuyerDashBoard()
        {
            if (HttpContext.Session.GetString("Uname") != null)
            {
                ViewBag.uname = HttpContext.Session.GetString("Uname").ToString();
                //ViewBag.lldt = HttpContext.Session.GetString("lastLogin").ToString();
                if (Request.Cookies["lastLogin"] != null)
                {
                    ViewBag.lldt = Request.Cookies["lastLogin"].ToString();
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Response.Cookies.Append("lastLogin", DateTime.Now.ToString());
            HttpContext.Session.Clear();
            return RedirectToAction("BuyerLogin");
        }
        // GET: CookieSession
        public async Task<IActionResult> BuyerIndex()
        {
            return View(await _context.Buyers.ToListAsync());
        }

        // GET: CookieSession/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyers
                .FirstOrDefaultAsync(m => m.BId == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
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

                return RedirectToAction(nameof(BuyerIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: CookieSession/Edit/5
        public async Task<IActionResult> Edit(int? bid)
        {
            if (bid == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyers.FindAsync(bid);
            if (buyer == null)
            {
                return NotFound();
            }
            return View(buyer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int bid, [Bind("BId,Username,Password,Email,Mobileno")] Buyer buyer)
        {
            if (bid != buyer.BId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerExists(buyer.BId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(BuyerIndex));
            }
            return View(buyer);
        }
        private bool BuyerExists(int bid)
        {
            return _context.Buyers.Any(e => e.BId == bid);
        }

        public async Task<IActionResult> Delete(int? bid)
        {
            if (bid == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyers
                .FirstOrDefaultAsync(m => m.BId == bid);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int bid)
        {
            var buyer = await _context.Buyers.FindAsync(bid);
            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BuyerIndex));
        }

    }
}