using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Admin
{
    public interface IRegularPriceDataByName<CLASS, ID, RET>
    {
        CLASS Get(ID id);
    }
}
