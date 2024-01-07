using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class BuySellRequestBetweenFarmerAndTraderRepo : Repo, IRepo<BuySellRequestBetweenFarmerAndTrader, int, BuySellRequestBetweenFarmerAndTrader>
    {
      public BuySellRequestBetweenFarmerAndTrader Add(BuySellRequestBetweenFarmerAndTrader obj)
        {
            db.BuySellRequestBetweenFarmerAndTraders.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.BuySellRequestBetweenFarmerAndTraders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<BuySellRequestBetweenFarmerAndTrader> Get()
        {
            return db.BuySellRequestBetweenFarmerAndTraders.ToList();
        }

        public BuySellRequestBetweenFarmerAndTrader Get(int id)
        {
            return db.BuySellRequestBetweenFarmerAndTraders.Find(id);
        }

        public BuySellRequestBetweenFarmerAndTrader Update(BuySellRequestBetweenFarmerAndTrader obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
