using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Farmer
{
    public interface ISeeTransportationFleet<CLASS, ID, Par1>
    {
        List<CLASS> GetRegionTrnasport(Par1 reg);
        CLASS Get(ID id);
    }
}
