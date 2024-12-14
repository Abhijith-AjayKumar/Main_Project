using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Controllers
{
    public class CommonController : Controller
    {
    
        private readonly ApplicationDbContext _context;

       public CommonController(ApplicationDbContext dbcontext)
       {
         _context = dbcontext;
       }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Registration(Register reg)
         {
            if (ModelState.IsValid)
            {
                _context.registers.Add(reg);
                int r= _context.SaveChanges();
            }
            return RedirectToAction("Login","Common");
         }
        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email,string Password)
        {
           
            if (Email != "" && Password != "")
            {
                if (_context.registers.Any(x => x.Email == Email && x.Password == Password))
                {
                    Register reg = _context.registers.FirstOrDefault(x => x.Email == Email && x.Password == Password);
                    if (reg != null)
                    {
                        HttpContext.Session.SetString("UserSession", reg.Id.ToString());
                        HttpContext.Session.SetString("Role","User");
                        HttpContext.Session.SetString("UserProfile", reg.Name);
                        return RedirectToAction("UserHome","User");
                    }
                }
                else if(_context.admin_reg.Any(x=>x.Email==Email && x.Password==Password))
                {
                    Admin_Register ad = _context.admin_reg.FirstOrDefault(x => x.Email == Email && x.Password == Password);
                    if (ad != null)
                    {
                        HttpContext.Session.SetString("AdminSession", ad.Id.ToString());
                        HttpContext.Session.SetString("Role", ad.Role.ToString());
                        HttpContext.Session.SetString("AdminProfile", ad.Name);
                        return RedirectToAction("admin_Home","Admin");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid Email or Password!";
                    return View();
                }
            }
            else
            {
                string script = "<script>alert('Enter Email or Password!');</script>";
                ViewBag.Script = script;
                return View();
            }
            return View();
        }
        
    }
}
