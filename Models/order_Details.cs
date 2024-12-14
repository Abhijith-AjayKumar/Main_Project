using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class order_Details
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Register_Id { get; set; }

        [ForeignKey("Register_Id")]
        public virtual Register register_tb { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "invalid name")]
        public string Name { get; set; }

        [RegularExpression(@"\b[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "invalid email")]
        public string Email { get; set; }
     
        [Display(Name = "Phone No")]
     
        public string Address { get; set; }

        public int phone { get; set; }
     
        public string City { get; set; }
    
        public string State { get; set; }
      
        public int Pin { get; set; }

        public DateTime Order_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Shipping_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Payment_Date { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Carrier { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Tracking_Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Transcation_Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Payment_Status { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Order_Status { get; set; }

        public float Amount { get; set; }
    }
}
