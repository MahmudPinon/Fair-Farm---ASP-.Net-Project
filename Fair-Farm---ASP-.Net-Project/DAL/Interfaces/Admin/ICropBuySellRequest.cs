using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Admin
{
    public interface ICropBuySellRequest<CLASS, ID, RET>
    {
        List<CLASS> Get();
        CLASS Get(ID id);
        RET Add(CLASS obj);
        RET Update(CLASS obj);
        bool Delete(ID obj);
        List<CLASS> GetItem(ID id);

    }
}
