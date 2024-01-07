using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Admin
{
    public interface IColdStorageRequestManage<CLASS, ID, RET>
    {
        List<CLASS> Get();
        CLASS Get(ID id);
 
        List<CLASS> GetItem(ID id);

    }
}
