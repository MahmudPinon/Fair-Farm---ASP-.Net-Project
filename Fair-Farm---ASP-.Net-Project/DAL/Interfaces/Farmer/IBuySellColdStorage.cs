using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Farmer
{
    public interface IBuySellColdStorage<CLASS, ID, PAR1>
    {
        List<CLASS> GetByType(ID id, PAR1 strparameter);
        CLASS Getexists(ID id1, ID id2);
        CLASS Create(CLASS obj);
        CLASS Update(CLASS obj);
        CLASS GetSinle(ID id1);
        bool Delete(ID obj);

        CLASS GetSinlebyUserId(ID obj);
    }
}
