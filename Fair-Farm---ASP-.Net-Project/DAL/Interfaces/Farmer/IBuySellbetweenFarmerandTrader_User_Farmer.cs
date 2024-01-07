using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Farmer
{
    public interface IBuySellbetweenFarmerandTrader_User_Farmer<CLASS, ID, ID2, RET>
    {
        List<CLASS> Get(ID par1);
        RET Update(CLASS obj);

        RET GetSingle(ID2 par1);
    }
}
