using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop
{
    public class Product
    {
        private int id;
        private string name;
        private string? description;

        private int maxItemInStock = 0;

        /// <summary>
        ///Properties!
        /// </summary>
        public int Id { get; set; }
        public string Name { 
            get { return name; } 
            set { name = value.Length > 50 ? value[..50] : value; } 
        }
        //because its otional we need to include the null case!
        public string? Description
        {
            get { return name; }
            set 
            {
                if (value == null)
                {
                    description = string.Empty;
                }else
                {
                    description = value.Length > 50 ? value[..250] : value;
                }
            }
        }
        public UnitType UnitType { get; set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockTreshold { get; private set; }
        /// <summary>
        /// Properties
        /// </summary>




        public void UseProduct(int items    )
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;

                UpdateLowStock();
                Log($"Amount in stock updated. Now {AmountInStock} items in stock");
            }else
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
        private void UpdateLowStock()
        {
            if (AmountInStock <= 10)
            {
                IsBelowStockTreshold = true;
            }
        }

        private string CreateSimpleProductRepresenttion()
        {
            return $"Product {id} ({name})";
        } 
        public string DisplayDetailsShort()
        {
            return $"{id}. {name} \n{AmountInStock} items in stock";
        }
        public string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{id}. {name} \n{description} \n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString(); 
        }




    }
}
