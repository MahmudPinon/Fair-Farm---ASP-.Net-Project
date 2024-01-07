using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>, IAuth, IUserIdFormUname
    {
        public User Add(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var ex = Get(obj.UserId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
      

        public bool Auth(string uname, string pass)  // for authentication
        {
            /*  var data = from s in db.Users
                         where s.UserName.Equals(uname) && s.Password.Equals(pass)
                         select s;
              if (data != null) return true;
              else return false;*/
            /*            var data = from s in db.Users
                                   where s.UserName.Equals(uname) && s.Password.Equals(pass)
                                   select s;*/
            var data = from s in db.Users
                       where s.UsersUserName.Equals(uname)
                            && s.Password.Equals(pass)
                            && s.UserLogInValid == true
                       select s;

            if (data.Any()) return true;
            else return false;
        }

        public int GetUserIdByUserName(string userName)
        {
            var user = db.Users.FirstOrDefault(u => u.UsersUserName.Equals(userName));
            return user != null ? user.UserId : -1; 
        }
    }
}
