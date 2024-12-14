using Ecommerce.Models;
using Ecommerce.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webhost;
        private const int PageSize = 10;
        public AdminController(ApplicationDbContext dbcontext,IWebHostEnvironment hostEnvironment)
        {
            _context = dbcontext;
            webhost = hostEnvironment;
        }

        [HttpGet]
        public IActionResult admin_Reg()
        {
            return View();
        }
        [HttpPost]
        public IActionResult admin_Reg(Admin_Register reg)
        {
            if (ModelState.IsValid)
            {
                _context.admin_reg.Add(reg);
                _context.SaveChanges();
                return View("admin_Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult admin_Home()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Category()
        { 
            IEnumerable<Admin_Categories> ad = _context.admin_cats.ToList();
            if (ad.Count() == 0)
            {

                return View();
            }
            return View(ad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var delete = _context.admin_cats.Find(id);
            if (delete == null)
            {
                return NotFound();
            }

            _context.admin_cats.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Category");
        }
        [HttpGet]
        public IActionResult upsert(int?id)
        {
            Admin_Categories up = new Admin_Categories();
            if (id != null)
            {
                up = _context.admin_cats.Find(id);
            }
            return View(up);
           
        }
        [HttpPost]
        public IActionResult upsert(Admin_Categories admin)
        {
            if (admin.Id != 0)
            {
                Admin_Categories edit = _context.admin_cats.Where(x => x.Id == admin.Id).FirstOrDefault();
                edit.Id = admin.Id;
                edit.Catergory_Name = admin.Catergory_Name;
                int r = _context.SaveChanges();
                _context.SaveChanges();
                return RedirectToAction("Category");
            }
            else if(admin.Id==0)
            {
                _context.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Category");
            }
            else
            {
                ViewBag.ErrorMessage = "Something went wrong try again!";
                return View();
            }
        }


        [HttpGet]
        public IActionResult CoverType()
        {
            IEnumerable<admin_CoverType> ad = _context.admin_CoverTypess.ToList();
            if (ad.Count() == 0)
            {
                return View();
            }
            return View(ad);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CoverType(int id)
        {
            var delete = _context.admin_CoverTypess.Find(id);
            if (delete == null)
            {
                return NotFound();
            }

            _context.admin_CoverTypess.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("CoverType");
        }

        [HttpGet]
        public IActionResult Upsert_CT(int? id)
        {
            admin_CoverType up = new admin_CoverType();
            if (id != null)
            {
                up = _context.admin_CoverTypess.Find(id);
            }
            return View(up);

        }
        [HttpPost]
        public IActionResult Upsert_CT(admin_CoverType admin)
        {
            if (admin.Id != 0)
            {
                admin_CoverType edit = _context.admin_CoverTypess.Where(x => x.Id == admin.Id).FirstOrDefault();
                edit.Id = admin.Id;
                edit.Cover_Type = admin.Cover_Type;
                int r = _context.SaveChanges();
                _context.SaveChanges();
                return RedirectToAction("CoverType");
            }
            else if (admin.Id == 0)
            {
                _context.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("CoverType");
            }
            else
            {
                ViewBag.ErrorMessage = "Something went wrong try again!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Product_List()
        {
            IEnumerable<admin_ProductList> ad = _context.admin_ProductLists.Include(x => x.Categories).Include(x=>x.CoverType).ToList();
            if (ad.Count() == 0)
            {
                return View();
            }
            return View(ad);
          
        }
        [HttpPost]
        public IActionResult Product_List_del(int id)
        {
            var delete = _context.admin_ProductLists.Find(id);
            if (delete == null)
            {
                return NotFound();
            }

            _context.admin_ProductLists.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Product_List");
        }

        [HttpGet]
        public IActionResult Upsert_PL(int?id)
        {

            admin_ProductList up = new admin_ProductList();
            ViewData["Cover_TypeID"] = new SelectList(_context.Set<admin_CoverType>(), "Id", "Cover_Type");
            ViewData["Catergory_Id"] = new SelectList(_context.Set<Admin_Categories>(), "Id", "Catergory_Name");
            if (id != null)
            {
                up = _context.admin_ProductLists.Find(id);
                return View(up);
            }
            
            return View(up);

        }
        [HttpPost]
        public IActionResult Upsert_PL(admin_ProductList admin)
        {
            if (admin.Id != 0)
            {
                admin_ProductList edit = _context.admin_ProductLists.Where(x => x.Id == admin.Id).FirstOrDefault();
                edit.Id = admin.Id;
                edit.Title = admin.Title;
                edit.ISBN = admin.ISBN;
                edit.Author = admin.Author;
                edit.Description = admin.Description;
                edit.ListPrice = admin.ListPrice;
                edit.Price = admin.Price;
                edit.Price50 = admin.Price50;
                edit.Price100 = admin.Price100;
                edit.Catergory_Id = admin.Catergory_Id;
                edit.Cover_TypeID = admin.Cover_TypeID;
                if (admin.ProfileImage != null)
                {
                    string FileName = null;
                    string uploadsFolder = Path.Combine(webhost.WebRootPath, "Image");
                    FileName = Guid.NewGuid().ToString() + "_" + admin.ProfileImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        admin.ProfileImage.CopyTo(fileStream);
                        admin.Photo = "/" + FileName;
                    }
                    edit.Photo = admin.Photo;
                }
                _context.SaveChanges();
                return RedirectToAction("Product_List");
            }
            else if (admin.Id == 0)
            { 

                    if (admin.ProfileImage != null)
                    {
                        string FileName = null;
                        string uploadsFolder = Path.Combine(webhost.WebRootPath, "Image");
                        FileName = Guid.NewGuid().ToString() + "_" + admin.ProfileImage.FileName;
                        string filePath = Path.Combine(uploadsFolder, FileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            admin.ProfileImage.CopyTo(fileStream);
                        admin.Photo = "/"+FileName;
                        }
                    }
                _context.admin_ProductLists.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Product_List");
            
        }
            return View();
        }
        [HttpGet]
        public IActionResult Company_List(string searchString,int pageIndex=1)
        {
           
            IEnumerable<Admin_CompanyDetails> ad = _context.Admin_CompanyDetailstb.ToList();
            if (ad.Count() == 0)
            {
                
                ad = null;
                return View();
            }

            /*Search and paging*/
            var totalProducts = _context.Admin_CompanyDetailstb.CountAsync();
            var products = _context.Admin_CompanyDetailstb
                .Skip((pageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            
            if (!String.IsNullOrEmpty(searchString))
            {
                ad = _context.Admin_CompanyDetailstb.Where(s => s.Name.Contains(searchString)).ToList();
                
            }
            return View(ad);
            /* var viewModel = new PaginatedList<Admin_CompanyDetails> ( products, totalProducts, pageIndex, PageSize);*/

            /* return View(viewModel);*/

        }

        [HttpPost]
        public IActionResult Company_List(int id)
        {
            var delete = _context.Admin_CompanyDetailstb.Find(id);
            if (delete == null)
            {
                return NotFound();
            }

            _context.Admin_CompanyDetailstb.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Company_List");
        }


        [HttpGet]
        public IActionResult Create_Company(int? id)                     //Upsert
        {
            Admin_CompanyDetails up = new Admin_CompanyDetails();
            if (id != null)
            {
                up = _context.Admin_CompanyDetailstb.Find(id);
            }
            return View(up);
        }
        [HttpPost]
        public IActionResult Create_Company(Admin_CompanyDetails admin)
        {
            if (admin.Id != 0)
            {
                Admin_CompanyDetails edit = _context.Admin_CompanyDetailstb.Where(x => x.Id == admin.Id).FirstOrDefault();
                edit.Id = admin.Id;
                edit.Name = admin.Name;
                edit.Address = admin.Address;
                edit.City = admin.City;
                edit.Pin = admin.Pin;
                edit.Phone_No = admin.Phone_No;
                int r = _context.SaveChanges();
                _context.SaveChanges();
                return RedirectToAction("Company_List");
            }
            else if (admin.Id == 0)
            {
                _context.Admin_CompanyDetailstb.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Company_List");
            }
            else
            {
                ViewBag.ErrorMessage = "Something went wrong try again!";
                return View();
            }
        }
        //paging




        [HttpGet]
        public IActionResult Manage_Order(string searchString, string orderStatus , int page = 1, int pageSize = 5)
        {
            // Fetch all order details as IQueryable for efficient filtering
            IEnumerable<order_Details> orders = _context.order_DetailsTb.ToList();

            // Filtering by search string (Name, Email, Phone)
            if (!string.IsNullOrEmpty(searchString))
            {
                orders = _context.order_DetailsTb.Where(o => o.Name.Contains(searchString) ||
                                   o.Email.Contains(searchString) ||o.phone.ToString().Contains(searchString)).ToList();
            }

            // Filtering by order status, default is "All"
            if (!string.IsNullOrEmpty(orderStatus) && orderStatus == "All")
            {
                orders = orders.OrderBy(x=>x.Order_Date); 
            }
            if (!string.IsNullOrEmpty(orderStatus) && orderStatus == "pending")
            {
                orders = orders.Where(o => o.Payment_Status == "pending");
            }
            if (!string.IsNullOrEmpty(orderStatus) && orderStatus== "In_Process")
            {
                orders = orders.Where(o => o.Order_Status == "pending");
            }
            if (!string.IsNullOrEmpty(orderStatus) && orderStatus == "Completed")
            {
                orders = orders.Where(o => o.Order_Status == "Completed");
            }
            if (!string.IsNullOrEmpty(orderStatus) && orderStatus == "Rejected")
            {
                orders = orders.Where(o => o.Order_Status == "Cancelled");
            }


            // Total count for pagination
            int totalCount = orders.Count();

            // Pagination logic (skip and take)
            var paginatedOrders = orders.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Pass total count and current page size to the view for pagination
            ViewBag.TotalCount = totalCount;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchString = searchString;
            ViewBag.OrderStatus = orderStatus;

            return View(paginatedOrders);
        }
        [HttpGet]
        public IActionResult Order_Edit(int id)
        {
            
            var order = _context.order_DetailsTb.Include(x => x.register_tb).FirstOrDefault(x => x.register_tb.Id == id);
            var userCartData = _context.userCarts.Include(x => x.Admin_ProductList).Where(x => x.User_Id == id).ToList();

            CartSummary viewModel = new CartSummary
            {
              
                UserCartModel = userCartData,
                Order_DetailsModel = order
            };
            viewModel.Order_DetailsModel.register_tb = _context.registers.FirstOrDefault(x => x.Id == id);
            viewModel.Order_DetailsModel.Name = viewModel.Order_DetailsModel.register_tb.Name;
            viewModel.Order_DetailsModel.phone = viewModel.Order_DetailsModel.register_tb.Phone_No;
            viewModel.Order_DetailsModel.City = viewModel.Order_DetailsModel.register_tb.City;
            viewModel.Order_DetailsModel.State = viewModel.Order_DetailsModel.register_tb.State;
            viewModel.Order_DetailsModel.Pin = viewModel.Order_DetailsModel.register_tb.Pin;
            viewModel.Order_DetailsModel.Email = viewModel.Order_DetailsModel.register_tb.Email;
            viewModel.Order_DetailsModel.Address = viewModel.Order_DetailsModel.register_tb.Address;
            viewModel.Order_DetailsModel.Order_Status =viewModel.Order_DetailsModel.Order_Status;
            viewModel.Order_DetailsModel.Id = _context.order_DetailsTb.FirstOrDefault(x => x.Register_Id == id).Id;     
            return View(viewModel);
         
        }
    
        [HttpPost]
        public IActionResult Order_Edit(CartSummary cart)
        {
            if (ModelState.IsValid)
            {
                
             order_Details edit = _context.order_DetailsTb.Where(x => x.Id == cart.Order_DetailsModel.Id).FirstOrDefault();
                edit.Name = cart.Order_DetailsModel.Name;
                edit.Order_Date = cart.Order_DetailsModel.Order_Date;
                edit.Order_Status = cart.Order_DetailsModel.Order_Status;
                edit.Payment_Date = cart.Order_DetailsModel.Payment_Date;
                edit.Payment_Status = cart.Order_DetailsModel.Payment_Status;
                edit.phone = cart.Order_DetailsModel.phone;
                edit.Pin = cart.Order_DetailsModel.Pin;
                edit.Shipping_Date = cart.Order_DetailsModel.Shipping_Date;
                edit.State = cart.Order_DetailsModel.State;
                edit.City = cart.Order_DetailsModel.City;
                edit.Carrier = cart.Order_DetailsModel.Carrier;
                edit.Tracking_Id = cart.Order_DetailsModel.Tracking_Id;
                edit.Transcation_Id = cart.Order_DetailsModel.Transcation_Id;
                edit.Email= cart.Order_DetailsModel.Email;
                edit.Address= cart.Order_DetailsModel.Address;
                _context.SaveChanges();
            }
            return RedirectToAction("Order_Edit");
        }

        [HttpGet]
        public IActionResult Admin_Profile()
        {
            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("AdminSession"));
            Admin_Register reg = _context.admin_reg.FirstOrDefault(x => x.Id == reg_id);
            return View(reg);
        }
        [HttpGet]
        public IActionResult Admin_Profile_Edit(int id)
        {
            Admin_Register reg = _context.admin_reg.FirstOrDefault(x => x.Id == id);
            return View(reg);
        }
        [HttpPost]
        public IActionResult Admin_Profile_Edit(Admin_Register reg)
        {
            Admin_Register re = _context.admin_reg.FirstOrDefault(x => x.Id == reg.Id);
            re.Id = reg.Id;
            re.Name = reg.Name;
            re.Phone_No = reg.Phone_No;
            re.Pin = reg.Pin;
            re.State = reg.State;
            re.Address = reg.Address;
            re.City = reg.City;
            re.Email = reg.Email;
            re.Company = reg.Company;
            _context.SaveChanges();
            return RedirectToAction("Admin_Profile");
        }

        [HttpGet]
        public IActionResult Ad_Ch_Password()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Ad_Ch_Password(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("AdminSession"));
            Admin_Register user = _context.admin_reg.FirstOrDefault(x => x.Id == reg_id);

            if (user != null)
            {
                // Hash comparison instead of plain text
                if (model.CurrentPassword == user.Password)
                {
                    if (model.NewPassword == model.ConfirmPassword)
                    {
                        // Hash the new password before storing it
                        user.Password = model.NewPassword;
                        _context.SaveChanges();

                        return RedirectToAction("Admin_Profile");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "New Password and Confirm Password do not match!";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Current password is incorrect!";
                }
            }

            return View(model);
        }











        [HttpPost]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Common");
        }
    }


}
