using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.OrderManagement
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderFulfillmentDate { get; set; }
        List<OrderItem> OrderItems { get;  }

        public bool Fulfilled { get; set; } = false;

        public Order () 
        {
            Id = new Random().Next(999999);
            int numberOfSecondsTillFulfillment = new Random().Next(100);
            OrderFulfillmentDate = DateTime.Now.AddSeconds(numberOfSecondsTillFulfillment);
            OrderItems = new List<OrderItem>();

        }
    }
}
