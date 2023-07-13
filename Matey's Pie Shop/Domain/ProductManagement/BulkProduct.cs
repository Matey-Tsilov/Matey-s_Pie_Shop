using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public class BulkProduct : Product
    {
        public BulkProduct(int id, string n, string desc, Price p,
             int maxAmount) : base(id, n, desc, p, UnitType.PerKilo, maxAmount)
        {
        }
    }
}
