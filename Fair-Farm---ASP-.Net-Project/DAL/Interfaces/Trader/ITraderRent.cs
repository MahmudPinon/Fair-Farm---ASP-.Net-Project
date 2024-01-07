using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Trader
{
    public interface ITraderRent<CLASS, ID, RET, Par1>
    {
        List<CLASS> GetRentRequests(ID id);
        CLASS Get(ID id);
        List<CLASS> GetByRegion(Par1 id);
        CLASS GetmyOwnRequest(ID id);
        RET Add(CLASS obj);
        RET Update(CLASS obj);
        RET UpdateforRentReq(ID id1, ID id2);
        bool Delete(ID obj);


    }
}
