using DAL.EF.Models;
using DAL.Interfaces.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Farmer
{
    internal class FarmerBuySellBetweenFarmerandTraderRepo : Repo, IBuySellbetweenFarmerandTrader_User_Farmer<BuySellRequestBetweenFarmerAndTrader, string, int, BuySellRequestBetweenFarmerAndTrader>
    {
        public List<BuySellRequestBetweenFarmerAndTrader> Get(string par1)
        {
            return db.BuySellRequestBetweenFarmerAndTraders.Where(e => e.Region == par1 && e.RequestType == "Refere").ToList();
        }

        public BuySellRequestBetweenFarmerAndTrader GetSingle(int par1)
        {
            return db.BuySellRequestBetweenFarmerAndTraders.FirstOrDefault(e => e.Id == par1);
        }

        public BuySellRequestBetweenFarmerAndTrader Update(BuySellRequestBetweenFarmerAndTrader obj)
        {
            var existingEntity = db.Set<BuySellRequestBetweenFarmerAndTrader>().Find(obj.Id);

            if (existingEntity != null)
            {
                var type = typeof(BuySellRequestBetweenFarmerAndTrader);
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
