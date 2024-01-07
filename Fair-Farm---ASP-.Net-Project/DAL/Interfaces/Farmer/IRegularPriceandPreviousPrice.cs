using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Farmer
{
    public interface IRegularPriceandPreviousPrice<CLASS, PAR1>
    {
        List<CLASS> GetAll();
        CLASS GetbyId(PAR1 id);
    }
}
