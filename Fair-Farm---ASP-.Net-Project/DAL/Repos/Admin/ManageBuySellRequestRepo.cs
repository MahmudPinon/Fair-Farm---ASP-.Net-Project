using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class ManageBuySellRequestRepo : Repo, IRepo<RequestTable, int, RequestTable>
    {

        public RequestTable Add(RequestTable obj)
        {
            db.RequestTables.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            throw new NotImplementedException();
        }

        public List<RequestTable> Get()
        {
            
            return db.RequestTables.ToList();
        }

        public RequestTable Get(int id)
        {
            return db.RequestTables.Find(id);
        }

        /*    public RequestTable Update(RequestTable obj)
            {
                var ex = Get(obj.Id);
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return ex;
            }*/
        public RequestTable Update(RequestTable obj)
        {
            var existingRequest = Get(obj.Id);
            if (existingRequest != null)
            {
                db.Entry(existingRequest).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return existingRequest;
            }
            return null;
        }

    }
}
