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
    internal class FarmerRegisteredTransportationFleetRepo : Repo, ISeeTransportationFleet<TransportationFleetRegister, int, string>
    {
        public TransportationFleetRegister Get(int id)
        {
            return db.TransportationFleetRegisters.FirstOrDefault(i => i.Id == id);

        }

        public List<TransportationFleetRegister> GetRegionTrnasport(string reg)
        {
            return db.TransportationFleetRegisters.Where(e => e.Region == reg).ToList();
        }
    }
}
