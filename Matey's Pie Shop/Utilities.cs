using Matey_s_Pie_Shop.Domain.General;
using Matey_s_Pie_Shop.Domain.OrderManagement;
using Matey_s_Pie_Shop.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop
{
    public class Utilities
    {
        private static List<Product> inventory = new();
        private static List<Order> orders = new();

        internal static void InitializeStock()//Mock implementation
        {
            Product p1 = new Product(1, "Sugar", "Not helthy", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKilo, 100);
            Product p2 = new Product(2, "Cake decoration", "Lorem Ipsum", new Price() { ItemPrice = 8, Currency = Currency.Euro }, UnitType.PerItem, 20);
            Product p3 = new Product(3, "Strawberry", "Lorem Ipsum", new Price() { ItemPrice = 3, Currency = Currency.Euro }, UnitType.PerBox, 10);

            inventory.Add(p1);
            inventory.Add(p2);  
            inventory.Add(p3);

        }
    }
}
