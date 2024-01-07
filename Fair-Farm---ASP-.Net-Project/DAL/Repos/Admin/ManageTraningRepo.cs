using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class ManageTraningRepo : Repo, IRepo<TrainingTable, int, TrainingTable>
    {
        public TrainingTable Add(TrainingTable obj)
        {
            db.TrainingTables.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var ex = Get(obj);
            db.TrainingTables.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<TrainingTable> Get()
        {
            return db.TrainingTables.ToList();
        }

        public TrainingTable Get(int id)
        {
            return db.TrainingTables.Find(id);
        }

        public TrainingTable Update(TrainingTable obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
