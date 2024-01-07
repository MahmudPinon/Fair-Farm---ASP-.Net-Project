using DAL.EF.Models;
using DAL.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
    internal class ColdStorageRequestItemRepo : Repo, IColdStorageRequestManage<ColdStorageItemList, int, ColdStorageItemList>
    {
        public List<ColdStorageItemList> Get()
        {
            return db.ColdStorageItemLists.ToList();
        }

        public ColdStorageItemList Get(int id) 
        {
            return db.ColdStorageItemLists.Find(id);
        }

        public List<ColdStorageItemList> GetItem(int id)
        {
            return db.ColdStorageItemLists.Where(item => item.RequestId == id).ToList();
        }
    }
}
