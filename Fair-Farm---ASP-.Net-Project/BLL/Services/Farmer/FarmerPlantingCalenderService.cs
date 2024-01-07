using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.FarmerDTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services.Farmer
{
    public class FarmerPlantingCalenderService
    {
        public static List<PlantingCalendarDTO> Get()
        {
            var data = FarmerDataAccessFactory.PlantingCalenderData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlantingCalendar, PlantingCalendarDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PlantingCalendarDTO>>(data);
        }
        public static PlantingCalendarDTO Add(PlantingCalendarDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlantingCalendarDTO, PlantingCalendar>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<PlantingCalendar>(s);

            var userId = data.FarmerUserId;
            var seasonalYear = data.SeasonalYear;
            var cropsName = data.CropsName.ToLower();
            var season = data.SeasonName.ToLower();
            var region = data.Region;
            var exists = FarmerDataAccessFactory.ExistingPlantingCalenderData().Get(userId, season, seasonalYear, cropsName);
            var checkuser = DataAccessFactory.UserData().Get(userId);
            //var checkregion = DataAccessFactory.UserData().Get(userId);
            if (exists != null)
            {
                throw new Exception("Entry with similar characteristics already exists from your Profile.");
            }
            else if (checkuser == null)
            {
                throw new Exception("Your Profile Does not Exists in the System.");
            }
            else if (checkuser.UserType != "Farmer")
            {
                throw new Exception("Your Profile Does not Match With the Farmer.");
            }
            /*else if (checkregion.UserRegion != region)
            {
                throw new Exception("Your Profile Region Does not Match With the Planting Calender Region.");

            }*/


            data.CropsName = cropsName;
            data.SeasonName = season;
            data.Region = checkuser.UserRegion;
            var addedData = FarmerDataAccessFactory.PlantingCalenderData().Add(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlantingCalendar, PlantingCalendarDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<PlantingCalendarDTO>(addedData);

            return data2;
        }


        public static PlantingCalendarDTO Get(int id)
        {
            var data = FarmerDataAccessFactory.PlantingCalenderData().Get(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PlantingCalendar, PlantingCalendarDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<PlantingCalendarDTO>(data);
            }

            return null;
        }


        public static PlantingCalendarDTO Update(PlantingCalendarDTO dt, int calenderid)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlantingCalendarDTO, PlantingCalendar>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<PlantingCalendar>(dt);

            var id = data.FarmerUserId;
            var region = data.Region;
            var checkcalenderowner = FarmerDataAccessFactory.PlantingCalenderData().Get(calenderid);//we will take the crops and compare the crops owner with the Farmer Id
            var checkregion = DataAccessFactory.UserData().Get(id);

            if (checkcalenderowner == null)
            {
                throw new Exception("This Crop Does Not Exists in the System.");
            }
            else if (checkcalenderowner.FarmerUserId != id)
            {
                throw new Exception("This Calender Product Does not Belongs to You.");
            }
            /*            else if (checkregion.UserRegion != region)
                        {
                            throw new Exception("Your Profile Region Does not Match With the Planting Calender Region.");
                        }*/
            data.Id = calenderid;
            if(data.CropsName!=null)
            {
                data.CropsName = data.CropsName.ToLower();
            }
            if (data.SeasonName != null)
            {
                data.SeasonName = data.SeasonName.ToLower();
            }
            data.Region = checkregion.UserRegion;
            var updatedData = FarmerDataAccessFactory.PlantingCalenderData().Update(data);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlantingCalendar, PlantingCalendarDTO>();
            });
            var mapper2 = new Mapper(config2);
            var dataDTO = mapper2.Map<PlantingCalendarDTO>(updatedData);

            return dataDTO;
        }

        public static bool Delete(int id1, int id2)
        {
            var checkcalenderowner = FarmerDataAccessFactory.PlantingCalenderData().Get(id1);
            if (checkcalenderowner == null)
            {
                throw new Exception("This Crops Does Not Exists in the System.");

            }
            else if (checkcalenderowner.FarmerUserId != id2)
            {
                throw new Exception("Your Profile Does not Match With This Planting Calender Crops Owner.");
            }
            return FarmerDataAccessFactory.PlantingCalenderData().Delete(id1);
        }


        public static UserPlantingCalenderDTO GetwithCalenderCrops(int id)
        {
            var data = DataAccessFactory.UserData().Get(id);
            if (data == null)
            {
                throw new Exception("Invalid Access to the Planting Calender Data.");
            }
            else if (data.PlantingCalendars == null || data.PlantingCalendars.Count() == 0)
            {
                throw new Exception("You Do not Have Any Data in the Planting Calender.");
            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserPlantingCalenderDTO>();
                c.CreateMap<PlantingCalendar, PlantingCalendarDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserPlantingCalenderDTO>(data);
            return mapped;
        }
    }
}
