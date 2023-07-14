using Matey_s_Pie_Shop.Domain.Contracts;
using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public class FreshProduct : Product, ISavable
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

        public override void IncreaseStock()
        {
            AmountInStock++;
        }
        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemInStock};{Price.ItemPrice}" +
                $";{(int)Price.Currency};{(int)UnitType};2";
        }
public override object Clone()
        {
            return new FreshProduct(0, this.Name, this.Description, new Price() { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency }, this.UnitType, this.maxItemInStock);
        }
    }
}
