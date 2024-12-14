using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class CartSummary
    {

      
        public IEnumerable<UserCart_Tb> UserCartModel { get; set; }

        public order_Details Order_DetailsModel { get; set; }

    
    }


}
