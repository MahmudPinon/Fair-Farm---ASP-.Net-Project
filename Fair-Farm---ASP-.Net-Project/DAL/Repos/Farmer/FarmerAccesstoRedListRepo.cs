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
    internal class FarmerAccesstoRedListRepo : Repo, IFarmerAccessRedList<User, int, string>
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
