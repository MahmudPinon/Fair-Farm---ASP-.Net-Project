using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Interfaces.Trader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Trader
{
    internal class CropsRequestTableRepo : Repo, ICropsOrder<RequestTable, int, RequestTable>
    {
        public RequestTable Add(RequestTable obj)
        {
            db.RequestTables.Add(obj);
            db.SaveChanges();
            return obj;
        }

    }
}
