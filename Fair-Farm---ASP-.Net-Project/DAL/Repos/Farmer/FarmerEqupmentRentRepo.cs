using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Interfaces.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Farmer
{
    internal class FarmerEqupmentRentRepo : Repo, IFarmerRent<EquipmentRent, int, EquipmentRent, string>
    {
        public EquipmentRent Add(EquipmentRent obj)
        {
            db.EquipmentRents.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var item = db.EquipmentRents.FirstOrDefault(i => i.Id == obj);
            if (item != null)
            {
                db.EquipmentRents.Remove(item);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<EquipmentRent> GetRentRequests(int ownerid)
        {
            return db.EquipmentRents.Where(e => e.OwnerUserId == ownerid && e.RentStatus == "Not Rented" && e.RenterUserId != e.OwnerUserId).ToList();
        }

        public EquipmentRent Get(int id)
        {
            return db.EquipmentRents.FirstOrDefault(i => i.Id == id);
        }

        public List<EquipmentRent> GetByRegion(string id)
        {
            return db.EquipmentRents.Where(e => e.Region == id).ToList();

        }

        public EquipmentRent GetmyOwnRequest(int id)
        {
            return db.EquipmentRents.FirstOrDefault(i => i.Id == id);
        }

        public EquipmentRent Update(EquipmentRent obj)
        {
            var existingRequest = Get(obj.Id);
            if (existingRequest != null)
            {
                if (obj.EquipmentName == null)
                {
                    obj.EquipmentName = existingRequest.EquipmentName;
                }
                else if (obj.PerdayRent == 0)
                {
                    obj.PerdayRent = existingRequest.PerdayRent;
                }
                else if (obj.Location == null)
                {
                    obj.Location = existingRequest.Location;
                }
                db.Entry(existingRequest).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return existingRequest;
            }
            return null;
        }

        public EquipmentRent UpdateforRentReq(int id1, int id2)
        {
            var equipmentRent = db.EquipmentRents.FirstOrDefault(e => e.Id == id1);
            if (equipmentRent != null)
            {
                equipmentRent.RenterUserId = id2;
                db.SaveChanges();
                return equipmentRent;
            }
            return null;
        }
    }
}
