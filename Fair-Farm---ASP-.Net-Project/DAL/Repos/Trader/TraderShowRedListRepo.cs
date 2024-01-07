using DAL.EF.Models;
using DAL.Interfaces.Trader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Trader
{
    internal class TraderShowRedListRepo : Repo, ITraderShowRedList<User, int, string>
    {
        public User GetById(int id, string type)
        {
            return db.Users.FirstOrDefault(i => i.UserId == id && i.UserType == type && i.UserRedList == true);
        }

        public List<User> GetByRegion(string region, string type)
        {
            return db.Users.Where(e => e.UserRegion == region && e.UserType == type && e.UserRedList == true).ToList();
        }
    }
}
