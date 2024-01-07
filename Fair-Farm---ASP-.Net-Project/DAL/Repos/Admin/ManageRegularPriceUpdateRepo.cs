using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class ManageRegularPriceUpdateRepo : Repo, IRepo<RegularPriceUpdate, int, RegularPriceUpdate>, IRegularPriceDataByName<RegularPriceUpdate, string, RegularPriceUpdate>
    {
        public RegularPriceUpdate Add(RegularPriceUpdate obj)
        {
            db.RegularPriceUpdates.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var ex = Get(obj);
            db.RegularPriceUpdates.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<RegularPriceUpdate> Get()
        {
            return db.RegularPriceUpdates.ToList();
        }

        public RegularPriceUpdate Get(int id)
        {
            return db.RegularPriceUpdates.Find(id);
        }

        public RegularPriceUpdate Get(string cropName)
        {
            return db.RegularPriceUpdates.FirstOrDefault(item => item.CropName == cropName);
        }

        public RegularPriceUpdate Update(RegularPriceUpdate obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
