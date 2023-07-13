using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public class FreshBoxedProduct : BoxedProduct
    {
        public FreshBoxedProduct(int id, string n, string desc, Price p,
            int maxAmount, int inBox) : base(id, n, desc, p, maxAmount, inBox)
        {
        }

        ////public void UseFreshBoxedProducts(int items)
        ////{
        ////    UseProduct(3);
        ////}
    }
}
