using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class ManageColdStorageRepo : Repo, IRepo<ManageColdStorage, int, ManageColdStorage>
    {
        public ManageColdStorage Add(ManageColdStorage obj)
        {
            db.ManageColdStorages.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var ex = Get(obj);
            db.ManageColdStorages.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<ManageColdStorage> Get()
        {
            return db.ManageColdStorages.ToList();
        }

        public ManageColdStorage Get(int id)
        {
            return db.ManageColdStorages.Find(id);
        }

        public ManageColdStorage Update(ManageColdStorage obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
