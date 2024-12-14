using Ecommerce.Models;
using Ecommerce.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NHibernate.Mapping;
using Org.BouncyCastle.Crypto.Generators;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }

        [HttpGet]
        public IActionResult UserHome()
        {
            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("UserSession"));
            Register reg = _context.registers.FirstOrDefault(x => x.Id == reg_id);
            IEnumerable<admin_ProductList> ad = _context.admin_ProductLists.Include(x => x.Categories).Include(x => x.CoverType).ToList();
            if (ad.Count() == 0)
            {
                return View();
            }
            return View(ad);

        }
        [HttpPost]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Common");
        }

        [HttpGet]
        public IActionResult OrderProduct(int id)
        {
            UserCart_Tb cart = new UserCart_Tb()
            {
                Admin_ProductList = _context.admin_ProductLists.Include(x => x.Categories).FirstOrDefault(y => y.Id == id),
                Product_Id = id,
            };
            return View(cart);



        }
        [HttpPost]
        public IActionResult OrderProduct(UserCart_Tb cart_Tb)
        {
            cart_Tb.Id = 0;
            var product_id = _context.admin_ProductLists.Find(cart_Tb.Product_Id);
            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("UserSession"));
            cart_Tb.User_Id = reg_id;
            if (cart_Tb.Count <= 49)
            {
                cart_Tb.Price = product_id.Price;
            }
            else if (cart_Tb.Count <= 99)
            {
                cart_Tb.Price = product_id.Price50;
            }
            else
            {
                cart_Tb.Price = product_id.Price100;
            }
            _context.userCarts.Add(cart_Tb);
            _context.SaveChanges();
            return RedirectToAction("shoppingCart");
        }
        [HttpGet]
        public IActionResult shoppingCart()
        {
            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("UserSession"));
            IEnumerable<UserCart_Tb> ad = _context.userCarts.Include(x => x.Admin_ProductList).Include(x => x.Register).Where(x => x.Register.Id == reg_id).ToList();
            if (ad.Count() == 0)
            {
                return View();
            }
            var total = ad.Sum(s => s.Count * s.Price);
            ViewBag.TotalAmount = total;
            return View(ad);
        }

        public IActionResult UpdateCount(int id, string action)
        {
            var item = _context.userCarts.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return RedirectToAction("shoppingCart");
            }
            if (action == "increment")
            {
                item.Count++;
            }
            else if (action == "decrement" && item.Count > 0)
            {
                item.Count--;
            }
            _context.SaveChanges();
            return RedirectToAction("shoppingCart");
        }
        [HttpPost]
        public IActionResult Cart_Del(int id)
        {
            var delete = _context.userCarts.Find(id);
            if (delete == null)
            {
                return NotFound();
            }

            _context.userCarts.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("shoppingCart");
        }
        [HttpGet]
        public IActionResult CartSummary()
        {
            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("UserSession"));
            /* var registerData = _context.registers.Find(reg_id);*/

            var order = _context.order_DetailsTb.Include(x => x.register_tb).Where(x => x.register_tb.Id == reg_id).FirstOrDefault();
            var userCartData = _context.userCarts.Include(x => x.Admin_ProductList).Where(x => x.User_Id == reg_id).ToList();

            // Populate the ViewModel with the fetched data
            CartSummary viewModel = new CartSummary
            {
                /* RegisterModel = registerData,*/
                UserCartModel = userCartData,
                // Order_DetailsModel = order
                Order_DetailsModel = new order_Details(),
            };
            viewModel.Order_DetailsModel.register_tb = _context.registers.FirstOrDefault(x => x.Id == reg_id);
            viewModel.Order_DetailsModel.Name = viewModel.Order_DetailsModel.register_tb.Name;
            viewModel.Order_DetailsModel.phone = viewModel.Order_DetailsModel.register_tb.Phone_No;
            viewModel.Order_DetailsModel.City = viewModel.Order_DetailsModel.register_tb.City;
            viewModel.Order_DetailsModel.State = viewModel.Order_DetailsModel.register_tb.State;
            viewModel.Order_DetailsModel.Pin = viewModel.Order_DetailsModel.register_tb.Pin;
            viewModel.Order_DetailsModel.Address = viewModel.Order_DetailsModel.register_tb.Address;



            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CartSummary(CartSummary cart)
        {
            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("UserSession"));
            if (ModelState.IsValid)
            {
                cart.Order_DetailsModel.register_tb = _context.registers.FirstOrDefault(x => x.Id == reg_id);
                cart.Order_DetailsModel.Email = cart.Order_DetailsModel.register_tb.Email;
                cart.Order_DetailsModel.Register_Id = reg_id;
                cart.Order_DetailsModel.Order_Date = DateTime.Now.Date;
                cart.Order_DetailsModel.Payment_Status = "pending";
                cart.Order_DetailsModel.Order_Status = "pending";
                _context.order_DetailsTb.Add(cart.Order_DetailsModel);
                var order = _context.order_DetailsTb.Include(x => x.register_tb).FirstOrDefault(x => x.register_tb.Id == reg_id);
                var userCartData = _context.userCarts.Include(x => x.Admin_ProductList).Where(x => x.User_Id == reg_id).ToList();


                // Populate the ViewModel with the fetched data
                CartSummary viewModel = new CartSummary
                {
                    /* RegisterModel = registerData,*/
                    UserCartModel = userCartData,
                    Order_DetailsModel = order,

                };

                var domain = "https://localhost:44388/";
                var options = new SessionCreateOptions
                {
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                    SuccessUrl = domain + "User/success",
                    CancelUrl = domain + "User/cancel",
                };
                foreach (var item in userCartData)
                {
                    var sessionListItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.Price * 100),
                            Currency = "inr",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Admin_ProductList.Title.ToString(),
                                Description = item.Admin_ProductList.Author.ToString(),
                            }
                        },

                        Quantity = item.Count,
                    };
                    options.LineItems.Add(sessionListItem);

                }
                var service = new SessionService();

                cart.Order_DetailsModel.Payment_Status = "paid";
                cart.Order_DetailsModel.Payment_Date = DateTime.Now;
                cart.Order_DetailsModel.Amount = userCartData.Sum(s => s.Price * s.Count);
                _context.order_DetailsTb.Add(cart.Order_DetailsModel);
                _context.SaveChanges();
                var order3 = _context.order_DetailsTb.Include(x => x.register_tb).OrderBy(x => x.Id).Last(x => x.register_tb.Id == reg_id);
                viewModel.UserCartModel = _context.userCarts.Include(x => x.Admin_ProductList).Where(x => x.Register.Id == reg_id).ToList();

                foreach (var it in viewModel.UserCartModel)
                {
                    User_Order_Status_Details user_Order_Status = new User_Order_Status_Details
                    {
                        Order_Id = order3.Id,
                        product_count = it.Count,
                        Product_Id = it.Product_Id,
                        Order_Price = it.Price,
                    };

                    _context.user_Order_Status_DetailsTb.Add(user_Order_Status);
                }
                _context.SaveChanges();
                Session session = service.Create(options);
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }
            return View("CartSummary");
        }

        [HttpGet]
        public IActionResult success()
        {
            ViewBag.ErrorMessage = "Payment Sucessfull!";
            return RedirectToAction("UserHome");
        }

        [HttpGet]
        public IActionResult cancel()
        {
            int id = _context.order_DetailsTb.OrderBy(x => x.Id).Last().Id;
            IEnumerable<User_Order_Status_Details> delete = _context.user_Order_Status_DetailsTb.Where(x => x.Order_Id == id);
            foreach (var item in delete)
            {
                _context.user_Order_Status_DetailsTb.Remove(item);
            }

            order_Details del = _context.order_DetailsTb.OrderBy(x => x.Id).Last();
            _context.order_DetailsTb.Remove(del);
            _context.SaveChanges();

            return RedirectToAction("UserHome");

        }
        [HttpGet]
        public IActionResult My_Orders(int page = 1, int pageSize = 5)
        {
            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("UserSession"));
            IEnumerable<order_Details> orders = _context.order_DetailsTb.Where(x => x.Register_Id == reg_id).OrderBy(x => x.Id).ToList();
            int totalCount = orders.Count();

            // Pagination logic (skip and take)
            var paginatedOrders = orders.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Pass total count and current page size to the view for pagination
            ViewBag.TotalCount = totalCount;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(paginatedOrders);
        }
        [HttpPost]
        public IActionResult Cancel_Order(order_Details or, int id)
        {
            or = _context.order_DetailsTb.FirstOrDefault(x => x.Id == id);
            or.Order_Status = "Cancelled";
            _context.SaveChanges();
            return RedirectToAction("My_Orders");
        }
        [HttpGet]
        public IActionResult My_Profile()
        {
            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("UserSession"));
            Register reg = _context.registers.FirstOrDefault(x => x.Id == reg_id);
            return View(reg);
        }
        [HttpGet]
        public IActionResult Profile_Edit(int id)
        {
            Register reg = _context.registers.FirstOrDefault(x => x.Id == id);
            return View(reg);
        }
        [HttpPost]
        public IActionResult Profile_Edit(Register reg)
        {
            Register re = _context.registers.FirstOrDefault(x => x.Id == reg.Id);
            re.Id = reg.Id;
            re.Name = reg.Name;
            re.Phone_No = reg.Phone_No;
            re.Pin = reg.Pin;
            re.State = reg.State;
            re.Address = reg.Address;
            re.City = reg.City;
            re.Email = reg.Email;
            _context.SaveChanges();
            return RedirectToAction("My_Profile");
        }
        [HttpGet]
        public IActionResult Change_Password()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Change_Password( ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int reg_id = Convert.ToInt32(HttpContext.Session.GetString("UserSession"));
            Register user = _context.registers.FirstOrDefault(x => x.Id == reg_id);

            if (user != null)
            {
                // Hash comparison instead of plain text
                if (model.CurrentPassword==user.Password)
                {
                    if (model.NewPassword == model.ConfirmPassword)
                    {
                        // Hash the new password before storing it
                        user.Password = model.NewPassword;
                        _context.SaveChanges();

                        return RedirectToAction("My_Profile");
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

        [HttpGet]
        public IActionResult Order_Details()
        {
            return View();
        }
    }
}

