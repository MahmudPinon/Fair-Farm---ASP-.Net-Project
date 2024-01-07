using DAL.EF.Models;
using DAL.Interfaces.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Farmer
{
    internal class FarmerColdStorageItemRepo : Repo, IFarmerColdStorageandSellRequestItem<ColdStorageItemList, int, ColdStorageItemList>
    {
        public List<ColdStorageItemList> Create(List<ColdStorageItemList> itemsToCreate)
        {
            db.ColdStorageItemLists.AddRange(itemsToCreate);
            db.SaveChanges();
            return itemsToCreate;
        }

        public bool Delete(int obj)
        {
            var item = db.ColdStorageItemLists.FirstOrDefault(i => i.Id == obj);
            if (item != null)
            {
                db.ColdStorageItemLists.Remove(item);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ColdStorageItemList> Get(int id)
        {
            var item = db.ColdStorageItemLists.FirstOrDefault(i => i.RequestId == id);
            return item != null ? new List<ColdStorageItemList> { item } : new List<ColdStorageItemList>();
        }

        public ColdStorageItemList GetSingleItem(int id1, int id2)
        {
            return db.ColdStorageItemLists.FirstOrDefault(i => i.Id == id1 && i.RequestId == id2);
        }

        public List<ColdStorageItemList> Update(List<ColdStorageItemList> itemsToUpdate)
        {
            var updatedEntities = new List<ColdStorageItemList>();

            foreach (var item in itemsToUpdate)
            {
                var existingEntity = db.ColdStorageItemLists.Find(item.Id);

                if (existingEntity != null)
                {
                    var type = typeof(ColdStorageItemList);
                    var properties = type.GetProperties();

                    foreach (var property in properties)
                    {
                        var newValue = property.GetValue(item);
                        if (newValue != null)
                        {
                            property.SetValue(existingEntity, newValue);
                        }
                    }
                    updatedEntities.Add(existingEntity);
                }
            }
            db.SaveChanges();
            return updatedEntities;
        }
    }
}
