using DAL.EF.Models;
using DAL.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class PreviousPriceRepo : Repo, IPreviousPrice<PreviousPrice, int, PreviousPrice>
    {
        public PreviousPrice Add(PreviousPrice obj)
        {
            db.PreviousPrices.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var ex = Get(obj);
            db.PreviousPrices.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<PreviousPrice> Get()
        {
            return db.PreviousPrices.ToList();
        }

        public PreviousPrice Get(int id)
        {
            return db.PreviousPrices.Find(id);
        }

       /* public PreviousPrice Update(PreviousPrice obj)
        {
            throw new NotImplementedException();
        }*/
    }
}
