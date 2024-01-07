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
    internal class FarmerSellItemRepo : Repo, IFarmerColdStorageandSellRequestItem<RequestTableItem, int, RequestTableItem>
    {
        public List<RequestTableItem> Create(List<RequestTableItem> itemsToCreate)
        {
            db.RequestTableItems.AddRange(itemsToCreate);
            db.SaveChanges();
            return itemsToCreate;
        }


        public bool Delete(int obj)
        {
            var itemsToDelete = db.RequestTableItems.Where(i => i.RequestId == obj).ToList();

            if (itemsToDelete.Any())
            {
                db.RequestTableItems.RemoveRange(itemsToDelete);
                db.SaveChanges();
                return true;
            }
            return false;
        }



        public List<RequestTableItem> Get(int id)
        {
            var item = db.RequestTableItems.FirstOrDefault(i => i.RequestId == id);
            return item != null ? new List<RequestTableItem> { item } : new List<RequestTableItem>();
        }


        public RequestTableItem GetSingleItem(int id1, int id2)
        {
            return db.RequestTableItems.FirstOrDefault(i => i.Id == id1 && i.RequestId == id2);
        }

        public List<RequestTableItem> Update(List<RequestTableItem> itemsToUpdate)
        {
            var updatedEntities = new List<RequestTableItem>();

            foreach (var item in itemsToUpdate)
            {
                var existingEntity = db.RequestTableItems.Find(item.Id);

                if (existingEntity != null)
                {
                    var type = typeof(RequestTableItem);
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
