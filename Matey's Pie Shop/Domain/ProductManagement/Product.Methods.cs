using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public partial class Product
    {
        public void UseProduct(int items)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;

                UpdateLowStock();
                Log($"Amount in stock updated. Now {AmountInStock} items in stock");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresenttion()}. {AmountInStock} available but {items} requested!");
            }
        }
        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void IncreaseStock()
        {
            AmountInStock++;
        }
        public void IncreaseStock(int amount)
        {
            int newValue = AmountInStock + amount;

            if (newValue <= maxItemInStock)
            {
                AmountInStock += amount;
            }
            else
            {
                //overstock isn't stored!
                AmountInStock = maxItemInStock;
                Log($"{CreateSimpleProductRepresenttion()} stock overflow. " +
                    $"{newValue - AmountInStock} item(s) ordered that " +
                    $"couldn't be stored! ");
            }
            if (AmountInStock > StockTreshold)
            {
                IsBelowStockTreshold = false;
            }
        }
        private void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }

            UpdateLowStock();

            Log(reason);

        }
        public void UpdateLowStock()
        {
            if (AmountInStock <= StockTreshold)
            {
                IsBelowStockTreshold = true;
            }
        }

        private string CreateSimpleProductRepresenttion()
        {
            return $"Product {Id} ({name})";
        }
        public string DisplayDetailsShort()
        {
            return $"{Id}. {name} \n{AmountInStock} items in stock";
        }
        public string DisplayDetailsFull()
        {
            ////StringBuilder sb = new StringBuilder();
            ////sb.Append($"{Id}. {name} \n{description} \n{AmountInStock} item(s) in stock");

            ////if (IsBelowStockTreshold)
            ////{
            ////    sb.Append("\n!!STOCK LOW!!");
            ////}

            //return sb.ToString(); 

            return DisplayDetailsFull("");
        }

        public string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Id}. {name} \n{description}\n{Price.ToString()}$\n{AmountInStock} item(s) in stock");
            sb.Append(extraDetails);

            if (IsBelowStockTreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        public static void ChangeTreshold(int newTreshold)
        {
            if (newTreshold > 0)
            {
                StockTreshold = newTreshold;
            }
        } 

    }
}
