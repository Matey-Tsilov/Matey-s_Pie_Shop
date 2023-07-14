using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matey_s_Pie_Shop.Domain.Contracts
{
    public interface ISaveable
    {
        string ConvertToStringForSaving();
    }
}
