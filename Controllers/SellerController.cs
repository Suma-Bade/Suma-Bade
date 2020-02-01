using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmartMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EmartMVC.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        private readonly SellerContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;
        public SellerController(SellerContext context, IWebHostEnvironment hostingEnvironment)
        {
            this._context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult RegisterSeller()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterSeller(Seller s)
        {
            try
            {

                _context.Add(s);
                _context.SaveChanges();
                ViewBag.message = s.Username + "has got successfully registered";
                return RedirectToAction("SellerLogin");
            }
            catch (Exception e)
            {
                ViewBag.message = s.Username + "Registration failed ";
                return View();
            }

        }
        [HttpGet]
        public ActionResult SellerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SellerLogin(Seller s)
        {
            var logUser = _context.Sellers.Where(e => e.Username == s.Username && e.Password == s.Password).ToList();
            if (logUser.Count == 0)
            {
                ViewBag.message = "Not valid User";
                return View();
            }
            else
            {//to store session values
                HttpContext.Session.SetString("Uname", s.Username);

                ////HttpContext.Session.SetString("lastLogin", DateTime.Now.ToString());
                return RedirectToAction("SellerDashBoard");
            }

        }

        public ActionResult SellerDashBoard()
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
        public ActionResult LogOut1()
        {
            Response.Cookies.Append("lastLogin", DateTime.Now.ToString());
            HttpContext.Session.Clear();
            return RedirectToAction("SellerLogin");
        }
        // GET: CookieSession
        public async Task<IActionResult> SellerIndex()
        {
            return View(await _context.Sellers.ToListAsync());
        }

        

        // GET: CookieSession/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CookieSession/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SellerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.PhotoPath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.PhotoPath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Seller newseller = new Seller
                {
                    Username = model.Username,
                    Email = model.Email,
                    Companyname = model.Companyname,
                    Password = model.Password,
                    GSTIN = model.GSTIN,
                    AboutCompany = model.AboutCompany,
                    Address = model.Address,
                    Website = model.Website,
                    Mobileno = model.Mobileno,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    PhotoPath = uniqueFileName
                };

                _context.Add(newseller);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = newseller.SId });
            }
            return View();

        }
        // GET: CookieSession/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Seller seller = _context.Sellers.FirstOrDefault(e => e.SId == id);
            return View(seller);
        }

        // GET: CookieSession/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }
        // POST: CookieSession/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SId,Username,Password,Companyname,GSTIN,AboutCompany,Address,Website,Email,Mobileno")] Seller seller)
        {
            if (id != seller.SId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerExists(seller.SId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SellerIndex));
            }
            return View(seller);
        }
        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.SId == id);
        }
        // GET: CookieSession/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _context.Sellers
                .FirstOrDefaultAsync(m => m.SId == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // POST: CookieSession/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SellerIndex));
        }


    }
}