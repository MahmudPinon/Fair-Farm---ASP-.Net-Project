using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Farmer
{
    public interface ICheckPlantingCalenderExisting<RET, PAR1, PAR2>
    {
        RET Get(PAR1 id, PAR2 itm1, PAR2 itm2, PAR2 itm3);
    }
}
