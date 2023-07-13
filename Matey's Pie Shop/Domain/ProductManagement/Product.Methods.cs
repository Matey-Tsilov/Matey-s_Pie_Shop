using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public partial class Product
    {
        public virtual void UseProduct(int items)
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
        protected void Log(string message)
        {
            Console.WriteLine(message);
        }

        public virtual void IncreaseStock()
        {
            AmountInStock++;
        }
        public virtual void IncreaseStock(int amount)
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
        protected virtual void DecreaseStock(int items, string reason)
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
        public virtual void UpdateLowStock()
        {
            if (AmountInStock <= StockTreshold)
            {
                IsBelowStockTreshold = true;
            }
        }

        protected string CreateSimpleProductRepresenttion()
        {
            return $"Product {Id} ({name})";
        }
        public virtual string DisplayDetailsShort()
        {
            return $"{Id}. {name} \n{AmountInStock} items in stock";
        }
        public virtual string DisplayDetailsFull()
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

        public virtual string DisplayDetailsFull(string extraDetails)
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
