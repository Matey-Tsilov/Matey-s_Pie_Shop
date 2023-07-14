using Matey_s_Pie_Shop.Domain.Contracts;
using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public class RegularProduct : Product, ISavable
    {
        public RegularProduct(int id, string n, string desc, Price p, UnitType ut,
            int maxAmount) : base(id, n, desc, p, ut, maxAmount)
        {
        }
        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemInStock};{Price.ItemPrice}" +
                $";{(int)Price.Currency};{(int)UnitType};4";
        }
        public override object Clone()
        {
            return new RegularProduct(0, this.Name, this.Description, new Price() { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency }, this.UnitType, this.maxItemInStock);
        }

    }
}
