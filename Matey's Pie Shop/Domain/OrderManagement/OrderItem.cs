using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.OrderManagement
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  
        
        public string ProductName { get; set; } = string.Empty;
        public int AmountOrder { get; set; }

        public override string ToString()
        {
            return $"Product ID - {ProductId}; Name: {ProductName}, Amount ordered: {AmountOrder}";
        }
    }
}
