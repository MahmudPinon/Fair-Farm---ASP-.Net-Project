using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Trader
{
    public interface ITransport<ReturnType, IReturntype, ParamObjType>
    {
        List<ReturnType> GetAll();
        IReturntype Add(ParamObjType obj);
    }
}
