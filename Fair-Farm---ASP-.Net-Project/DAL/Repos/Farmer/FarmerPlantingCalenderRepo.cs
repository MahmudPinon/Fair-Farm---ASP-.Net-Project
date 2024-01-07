using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Interfaces.Farmer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Farmer
{
    internal class FarmerPlantingCalenderRepo : Repo, IRepo<PlantingCalendar, int, PlantingCalendar>, ICheckPlantingCalenderExisting<PlantingCalendar, int, string>
    {
        public PlantingCalendar Add(PlantingCalendar obj)
        {
            db.PlantingCalendars.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int obj)
        {
            var item = db.PlantingCalendars.FirstOrDefault(i => i.Id == obj);
            if (item != null)
            {
                db.PlantingCalendars.Remove(item);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<PlantingCalendar> Get()
        {
            return db.PlantingCalendars.ToList();
        }

        public PlantingCalendar Get(int id)
        {
            return db.PlantingCalendars.FirstOrDefault(i => i.Id == id);
        }

        public PlantingCalendar Get(int id, string itm1, string itm2, string itm3)
        {

            return db.PlantingCalendars.FirstOrDefault(i => i.FarmerUserId == id && i.SeasonName == itm1 && i.SeasonalYear == itm2 && i.CropsName == itm3);


        }

        public PlantingCalendar Update(PlantingCalendar obj)
        {
            var existingEntity = db.Set<PlantingCalendar>().Find(obj.Id);

            if (existingEntity != null)
            {
                var type = typeof(PlantingCalendar);
                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    var newValue = property.GetValue(obj);
                    if (newValue != null)
                    {
                        property.SetValue(existingEntity, newValue);
                    }
                }

                db.SaveChanges();
                return existingEntity;
            }

            return null;
        }


    }
}
