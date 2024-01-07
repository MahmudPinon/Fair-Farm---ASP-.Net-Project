using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class AdminStoredItemRepo : Repo, IRepo<AdminStoredItem, int, AdminStoredItem>
    {
        public AdminStoredItem Add(AdminStoredItem obj)
        {
            db.AdminStoredItems.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var item = db.AdminStoredItems.FirstOrDefault(i => i.Id == obj);
            if (item != null)
            {
                db.AdminStoredItems.Remove(item);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<AdminStoredItem> Get()
        {
            return db.AdminStoredItems.ToList();
        }

        public AdminStoredItem Get(int id)
        {
            return db.AdminStoredItems.FirstOrDefault(i => i.Id == id);
        }

        public AdminStoredItem Update(AdminStoredItem obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return obj;
        }
    }
}
