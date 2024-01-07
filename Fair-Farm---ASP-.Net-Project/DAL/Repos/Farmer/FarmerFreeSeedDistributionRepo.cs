using DAL.EF.Models;
using DAL.Interfaces.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Farmer
{
    internal class FarmerFreeSeedDistributionRepo : Repo, ISeeTransportationFleet<FreeSeedsDistribution, int, string>
    {
        public FreeSeedsDistribution Get(int id)
        {
            return db.FreeSeedsDistributions.FirstOrDefault(i => i.Id == id);
        }

        public List<FreeSeedsDistribution> GetRegionTrnasport(string reg)
        {
            return db.FreeSeedsDistributions.Where(e => e.Region == reg).ToList();
        }
    }
}
