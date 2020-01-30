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
    public class SellerController : Controller
    {
        // GET: Seller
        public readonly SellerContext _context;
        public SellerController(SellerContext context)
        {
            this._context = context;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: CookieSession/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CookieSession/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CookieSession/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CookieSession/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CookieSession/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}