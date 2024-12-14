using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Register> registers  { get; set; }
        public DbSet<Admin_Register> admin_reg { get; set; }
        public DbSet<Admin_Categories> admin_cats { get; set; }
        public DbSet<admin_CoverType> admin_CoverTypess { get; set; }
        public DbSet<admin_ProductList> admin_ProductLists { get; set; }
        public DbSet<Admin_CompanyDetails> Admin_CompanyDetailstb { get; set; }
        public DbSet<UserCart_Tb> userCarts { get; set; }
        public DbSet<order_Details> order_DetailsTb { get; set; }
        public DbSet<User_Order_Status_Details> user_Order_Status_DetailsTb { get; set; }
      
    }
}
