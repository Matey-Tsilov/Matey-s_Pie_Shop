using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//this stays in the general folder because other class,
//not only those in the ProductManagement folder,
//will reuse this class
namespace Matey_s_Pie_Shop.Domain.General
{
    public class Price
    {
        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }

        public override string ToString()
        {
            return $"{ItemPrice}{Currency}s";
        }

    }
}
