using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Trader
{
    public interface ICropsOrder<CLASS, ID, RET>
    {

        RET Add(CLASS obj);

    }
}
