using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public class RegularProduct : Product
    {
        public RegularProduct(int id, string n, string desc, Price p, UnitType ut,
            int maxAmount) : base(id, n, desc, p, ut, maxAmount)
        {
        }
        public override void IncreaseStock()
        {
            AmountInStock++;
        }
    }
}
