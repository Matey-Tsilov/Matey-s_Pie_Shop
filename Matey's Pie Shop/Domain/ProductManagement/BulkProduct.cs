using Matey_s_Pie_Shop.Domain.Contracts;
using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public class BulkProduct : Product, ISavable
    {
        public BulkProduct(int id, string n, string desc, Price p,
             int maxAmount) : base(id, n, desc, p, UnitType.PerKilo, maxAmount)
        {
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }
        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemInStock};{Price.ItemPrice}" +
                $";{(int)Price.Currency};{(int)UnitType};3";
        }
        public override object Clone()
        {
            return new BulkProduct(0, this.Name, this.Description, new Price() { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency }, this.maxItemInStock);
        }
    }
}
