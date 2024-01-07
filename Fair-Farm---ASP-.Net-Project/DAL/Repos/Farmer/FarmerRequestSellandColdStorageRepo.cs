using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Interfaces.Farmer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Farmer
{
    internal class FarmerRequestSellandColdStorageRepo : Repo, IBuySellColdStorage<RequestTable, int, string>
    {
        public RequestTable Create(RequestTable obj)
        {
            db.RequestTables.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var item = db.RequestTables.FirstOrDefault(i => i.Id == obj);
            if (item != null)
            {
                db.RequestTables.Remove(item);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<RequestTable> GetByType(int userid, string strparameter)
        {
            return db.RequestTables.Where(e => e.UserId == userid && e.RequestType == strparameter).ToList();
        }

        public RequestTable Getexists(int id1, int id2)
        {
            return db.RequestTables.FirstOrDefault(e => e.Id == id1 && e.UserId == id2);
        }

        public RequestTable GetSinle(int id1)
        {
            return db.RequestTables.FirstOrDefault(e => e.Id == id1);
        }

        public RequestTable GetSinlebyUserId(int userId)
        {
            DateTime today = DateTime.Today;
            return db.RequestTables
             .Where(e => e.UserId == userId && e.Status == "Pending")
             .OrderByDescending(e => e.Id)
             .FirstOrDefault();
        }



        public RequestTable Update(RequestTable obj)
        {
            var existingEntity = db.Set<RequestTable>().Find(obj.Id);

            if (existingEntity != null)
            {
                var type = typeof(RequestTable);
                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    var newValue = property.GetValue(obj);
                    if (newValue != null)
                    {
                        property.SetValue(existingEntity, newValue);
                    }
                }

                db.SaveChanges();
                return existingEntity;
            }

            return null;
        }
    }
}
