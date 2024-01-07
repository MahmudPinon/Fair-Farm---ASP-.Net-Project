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
    internal class FarmerTrainingDetailsRepo : Repo, ISeeTransportationFleet<TrainingTable, int, string>
    {
        public TrainingTable Get(int id)
        {
            return db.TrainingTables.FirstOrDefault(i => i.Id == id);
        }

        public List<TrainingTable> GetRegionTrnasport(string reg)
        {
            return db.TrainingTables.Where(e => e.Region == reg).ToList();
        }
    }
}
