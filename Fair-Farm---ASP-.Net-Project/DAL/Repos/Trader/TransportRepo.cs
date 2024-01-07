using DAL.EF.Models;
using DAL.Interfaces.Trader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Trader
{
    class TransportRepo : Repo, ITransport<TransportationFleetRegister, int, TransportationFleetRegister>
    {
        public int Add(TransportationFleetRegister obj)
        {
            db.TransportationFleetRegisters.Add(obj);
            return db.SaveChanges();
        }

        public List<TransportationFleetRegister> GetAll()
        {
            return db.TransportationFleetRegisters.ToList();
        }
    }
}