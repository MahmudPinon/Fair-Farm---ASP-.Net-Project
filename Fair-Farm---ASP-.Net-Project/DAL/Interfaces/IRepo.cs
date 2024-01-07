using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RET> // declaration use er shomoy bole dite hobe class ta ki
    {
        List<CLASS> Get();
        CLASS Get(ID id);
        RET Add(CLASS obj);
        RET Update(CLASS obj);
        bool Delete(ID obj);
       
    }
}
