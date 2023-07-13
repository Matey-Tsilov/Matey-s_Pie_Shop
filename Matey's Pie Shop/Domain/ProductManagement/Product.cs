using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public abstract partial class Product
    {
        private string name;
        private string? description;
        protected int maxItemInStock = 0;

        public static int StockTreshold = 5;

        public Product(int id, string n, string desc, Price p, UnitType ut, int maxAmount)
        {
            Id = id;
            Price = p;
            Name = n;
            Description = desc;
            UnitType = ut;
            maxItemInStock = maxAmount;
            UpdateLowStock();
        }

        /// <summary>
        ///Properties!
        /// </summary>
        public string Name
        {
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
                }
                else
                {
                    description = value.Length > 50 ? value[..250] : value;
                }
            }
        }
        public Price Price { get; set; }
        public int Id { get; set; }
        public UnitType UnitType { get; set; }
        public int AmountInStock { get; protected set; }
        public bool IsBelowStockTreshold { get; protected set; }
        /// <summary>
        /// Properties
        /// </summary>

    }
}
