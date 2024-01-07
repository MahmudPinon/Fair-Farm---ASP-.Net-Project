using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class FreeSeedsDistributionManagementRepo : Repo, IRepo<FreeSeedsDistribution, int, FreeSeedsDistribution>
    {
        public FreeSeedsDistribution Add(FreeSeedsDistribution obj)
        {
            db.FreeSeedsDistributions.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var ex = Get(obj);
            db.FreeSeedsDistributions.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<FreeSeedsDistribution> Get()
        {
            return db.FreeSeedsDistributions.ToList();
        }

        public FreeSeedsDistribution Get(int id)
        {
            return db.FreeSeedsDistributions.Find(id);
        }

        public FreeSeedsDistribution Update(FreeSeedsDistribution obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
