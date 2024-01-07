using System;
using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Admin;

namespace DAL.Repos.Admin
{

    internal class ManageBuySellRequestItemRepo : Repo, ICropBuySellRequest<RequestTableItem, int, RequestTableItem>
    {
        public RequestTableItem Add(RequestTableItem obj)
        {
            db.RequestTableItems.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var ex = Get(obj);
            db.RequestTableItems.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<RequestTableItem> Get()
        {
            return db.RequestTableItems.ToList();
        }

        public RequestTableItem Get(int id)
        {
            return db.RequestTableItems.Find(id);
        }

        public List<RequestTableItem> GetItem(int id)
        {
            return db.RequestTableItems.Where(item => item.RequestId == id).ToList();
        }

        public RequestTableItem Update(RequestTableItem obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
