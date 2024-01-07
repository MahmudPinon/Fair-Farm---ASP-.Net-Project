using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Farmer
{
    public interface ITransportationFleetRentbyFarmer<CLASS, ID, RET>
    {
        List<CLASS> GetFarmerTransportRentRecords(ID id);
        CLASS Get(ID id);
        CLASS Getexists(ID id1, ID id2);
        RET Add(CLASS obj);
        RET Update(CLASS obj);
        bool Delete(ID obj);
    }
}
