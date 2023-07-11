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
        public List<OrderItem> OrderItems { get;  }

        public bool Fulfilled { get; set; } = false;

        public Order () 
        {
            Id = new Random().Next(999999);
            int numberOfSecondsTillFulfillment = new Random().Next(100);
            OrderFulfillmentDate = DateTime.Now.AddSeconds(numberOfSecondsTillFulfillment);
            OrderItems = new List<OrderItem>();

        }

        public string ShowOrderDetails()
        {
            StringBuilder orderDetails = new StringBuilder();

            orderDetails.AppendLine($"Order ID: {Id}");
            orderDetails.AppendLine($"Order fulfilment date: {OrderFulfillmentDate.ToShortTimeString()}");

            if (OrderItems != null)
            {
                foreach (OrderItem item in OrderItems)
                {
                    orderDetails.AppendLine(item.ToString());
                }
            }

            return orderDetails.ToString();
        }
    }
}
