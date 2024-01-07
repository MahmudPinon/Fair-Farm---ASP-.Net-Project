using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class ManageColdStorageRequestRepo : Repo, IRepo<StoredItemInColdStorage, int, StoredItemInColdStorage>
    {
        public StoredItemInColdStorage Add(StoredItemInColdStorage obj)
        {
            db.StoredItemInColdStorages.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var ex = Get(obj);
            db.StoredItemInColdStorages.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<StoredItemInColdStorage> Get()
        {
            return db.StoredItemInColdStorages.ToList();
        }

        public StoredItemInColdStorage Get(int id)
        {
            return db.StoredItemInColdStorages.Find(id);
        }

        public StoredItemInColdStorage Update(StoredItemInColdStorage obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
