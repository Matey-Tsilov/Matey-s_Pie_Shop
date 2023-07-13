using Matey_s_Pie_Shop.Domain.Contracts;
using Matey_s_Pie_Shop.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.ProductManagement
{
    public class BoxedProduct : Product, ISavable, ILoggable
    {
        private int amountPerBox;
        
        public int AmountPerBox
        {
            get { return amountPerBox; }
            set { 
                amountPerBox = value; 
            }
        }

        public BoxedProduct(int id, string n, string desc, Price p,
            int maxAmount, int inBox) 
            : base(id, n, desc, p, UnitType.PerBox, maxAmount)
        {
            AmountPerBox = inBox;
        }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Boxed product:\n");
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append("!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        public override void UseProduct(int items)
        {
            int batchSize;
            int smallestMultiple = 0;

            while (true)
            {
                smallestMultiple++;
                if (smallestMultiple * AmountPerBox > items)
                {
                    batchSize = smallestMultiple * AmountPerBox;
                    break;
                }
            }
            
            base.UseProduct(batchSize);
        }

        public override void IncreaseStock()
        {
            //in order to reuse validations!
            IncreaseStock(1);
        }

        public override void IncreaseStock(int amount)
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

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemInStock};{Price.ItemPrice}" +
                $";{(int)Price.Currency};{(int)UnitType};1;{AmountPerBox}";
        }
        public override object Clone()
        {
            return new BoxedProduct(0, this.Name, this.Description, 
                new Price() { ItemPrice = this.Price.ItemPrice, 
                    Currency = this.Price.Currency }, this.maxItemInStock, this.AmountPerBox);
        }

    }
}
