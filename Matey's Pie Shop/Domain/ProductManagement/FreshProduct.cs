using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public class FreshProduct : Product
    {
        public DateTime ExpiryDateTime { get; set; }
        public string StorageInstructions { get; set; }
            public FreshProduct(int id, string n, string desc, Price p, UnitType ut,
                 int maxAmount) : base(id, n, desc, p, ut, maxAmount)
            {
            }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Boxed product:\n");
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append("!!STOCK LOW!!");
            }
            sb.AppendLine($"Storage Instructions: {StorageInstructions}");
            sb.AppendLine($"Expiry Date: {ExpiryDateTime.ToShortDateString()}");

            return sb.ToString();
        }
    }
}
