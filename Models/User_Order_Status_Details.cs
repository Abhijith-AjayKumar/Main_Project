using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class User_Order_Status_Details

    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public virtual admin_ProductList ProductLists { get; set; }

        public int product_count { get; set; }

        public float Order_Price { get; set; }

        public int Order_Id { get; set; }
        [ForeignKey("Order_Id ")]
        public virtual order_Details Order_Detailss { get; set; }
    }
}
