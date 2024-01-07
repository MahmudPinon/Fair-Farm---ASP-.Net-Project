using DAL.EF.Models;
using DAL.Interfaces.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Farmer
{
    internal class FarmerPreviousPriceRepo : Repo, IRegularPriceandPreviousPrice<PreviousPrice, int>
    {
        public List<PreviousPrice> GetAll()
        {
            return db.PreviousPrices.ToList();

        }

        public PreviousPrice GetbyId(int id)
        {
            return db.PreviousPrices.Find(id);
        }
    }
}
