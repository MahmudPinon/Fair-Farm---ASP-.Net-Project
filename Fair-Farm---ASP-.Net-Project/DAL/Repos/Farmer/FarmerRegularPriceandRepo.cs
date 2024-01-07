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
    internal class FarmerRegularPriceandRepo : Repo, IRegularPriceandPreviousPrice<RegularPriceUpdate, int>
    {
        public List<RegularPriceUpdate> GetAll()
        {
            return db.RegularPriceUpdates.ToList();
        }


        public RegularPriceUpdate GetbyId(int id)
        {
            return db.RegularPriceUpdates.Find(id);
        }
    }
}
