using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Trader
{
    public interface IShowDetails<ReturnType, IReturntype, ParamObjType>
    {
        List<ReturnType> GetAll();

    }
}
