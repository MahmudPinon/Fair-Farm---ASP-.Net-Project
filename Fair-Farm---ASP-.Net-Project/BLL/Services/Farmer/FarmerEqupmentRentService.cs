using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs.FarmerDTOs;

namespace BLL.Services.Farmer
{
    public class FarmerEqupmentRentService
    {
        public static EquipmentRentDTO Add(EquipmentRentDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EquipmentRentDTO, EquipmentRent>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<EquipmentRent>(s);

            var owneruserid = data.OwnerUserId;
            var perdayrent = data.PerdayRent;
            data.RentStatus = "Not Rented";
            var checkuser = DataAccessFactory.UserData().Get(owneruserid);

            if (checkuser == null)
            {
                throw new Exception("Your Profile Does not Exists in the System.");
            }
            else if (perdayrent <= 0)
            {
                throw new Exception("Per day Rent Can not be 0 or Negative Number.");
            }
            else if (checkuser.UserType == "Admin")
            {
                throw new Exception("Your Profile Does not Match With the Farmer or Trader.");
            }
            data.Region = checkuser.UserRegion;
            data.RenterUserId = data.OwnerUserId;
            var addedData = FarmerDataAccessFactory.FarmerEquipmentRentData().Add(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EquipmentRent, EquipmentRentDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<EquipmentRentDTO>(addedData);

            return data2;
        }


        public static EquipmentRentDTO Get(int id)
        {
            var data = FarmerDataAccessFactory.FarmerEquipmentRentData().Get(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EquipmentRent, EquipmentRentDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<EquipmentRentDTO>(data);
            }

            return null;
        }

        public static List<EquipmentRentDTO> GetByRegion(string id)
        {
            var data = FarmerDataAccessFactory.FarmerEquipmentRentData().GetByRegion(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EquipmentRent, EquipmentRentDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<EquipmentRentDTO>>(data);
            }
            return null;
        }

        public static EquipmentRentDTO GetOwnRequestStatus(int id, int renterid)
        {
            var data = FarmerDataAccessFactory.FarmerEquipmentRentData().GetmyOwnRequest(id);
            if (data == null)
            {
                throw new Exception("This Equpment Does not Exists in the System.");
            }
            else if (data.RenterUserId != renterid)
            {
                throw new Exception("You are not Renter of this Eqipment.");
            }
            else if (data.RenterUserId == data.OwnerUserId)
            {
                throw new Exception("Invalid Request.");

            }
            else if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EquipmentRent, EquipmentRentDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<EquipmentRentDTO>(data);
            }

            return null;
        }


        public static List<EquipmentRentDTO> GetRentRequestsofMyAdvertise(int ownerid)
        {
            var data = FarmerDataAccessFactory.FarmerEquipmentRentData().GetRentRequests(ownerid);
            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EquipmentRent, EquipmentRentDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<EquipmentRentDTO>>(data);
            }
            return null;
        }

        public static EquipmentRentDTO UpdateforMyRentRequest(int renteruserid, int equipmentid)
        {

            var checkrenterexists = DataAccessFactory.UserData().Get(renteruserid);
            var checkequpment = FarmerDataAccessFactory.FarmerEquipmentRentData().Get(equipmentid);

            if (checkrenterexists == null)
            {
                throw new Exception("You are not a Registered User in the System.");
            }
            else if (checkequpment == null)
            {
                throw new Exception("Equpment Does not Exists in the System.");
            }
            else if (checkrenterexists.UserId == checkequpment.OwnerUserId)
            {
                throw new Exception("You Can not Rent Your Equipment.");
            }
            else if (checkrenterexists.UserRegion != checkequpment.Region)
            {
                throw new Exception("This Equpment Does not Belongs to Your Region.");
            }
            else if (checkequpment.RentStatus == "Rented")
            {
                throw new Exception("This Equpment is Already Rented.");
            }
            else if (checkequpment.RenterUserId == renteruserid)
            {
                throw new Exception("You have Already Requested for this Equpment.");
            }
            else if (checkequpment.RenterUserId != checkequpment.OwnerUserId)
            {
                throw new Exception("Another User is Already Requested For the Equipment Please Try Another.");
            }
            var updatedData = FarmerDataAccessFactory.FarmerEquipmentRentData().UpdateforRentReq(equipmentid, renteruserid);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EquipmentRent, EquipmentRentDTO>();
            });
            var mapper2 = new Mapper(config2);
            var dataDTO = mapper2.Map<EquipmentRentDTO>(updatedData);

            return dataDTO;
        }
        public static EquipmentRentDTO UpdatebyEqupmentOwner(int id, int ownerid, EquipmentRentDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EquipmentRentDTO, EquipmentRent>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<EquipmentRent>(s);

            var checkownerexists = DataAccessFactory.UserData().Get(ownerid);
            var checkequpment = FarmerDataAccessFactory.FarmerEquipmentRentData().Get(id);
            //var renter = DataAccessFactory.UserData().Get(checkequpment.RenterUserId);
            if (checkownerexists == null)
            {
                throw new Exception("You are not a Registered User in the System.");
            }
            else if (checkequpment == null)
            {
                throw new Exception("Equpment Does not Exists in the System.");
            }
            else if (checkownerexists.UserId != checkequpment.OwnerUserId)
            {
                throw new Exception("You are not Owner of the Equipment.");
            }
            else if (data.Region != null)
            {
                throw new Exception("You Can not Update the Region.");
            }
            else if ((checkequpment.RentStatus == "Rented") && (data.RentStatus != "Rented" || data.RentStatus != null))
            {
                throw new Exception("This Equipment is Rented You can not Modify it.");
            }
            else if ((data.RentStatus == "Rented" && (checkequpment.RenterUserId == checkequpment.OwnerUserId)) || ((data.RentStatus != "Rented" && data.RentStatus != "Not Rented")))
            {
                throw new Exception("You are Providing Invalid Rent Status.");
            }
            else if (data.RentStatus != "Rented")
            {
                data.RenterUserId = checkequpment.OwnerUserId;
            }
            else if (data.RentStatus == "Rented" && (checkequpment.RenterUserId != checkequpment.OwnerUserId))
            {
                data.OwnerUserId = checkequpment.OwnerUserId;
                data.RentStatus = "Rented";
                data.Region = checkownerexists.UserRegion;
                data.Location = checkequpment.Location;
                data.EquipmentName = checkequpment.EquipmentName;
                data.PerdayRent = checkequpment.PerdayRent;
                data.Id = checkequpment.Id;
                data.RenterUserId = checkequpment.RenterUserId;

            }
            var updatedData = FarmerDataAccessFactory.FarmerEquipmentRentData().Update(data);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EquipmentRent, EquipmentRentDTO>();
            });
            var mapper2 = new Mapper(config2);
            var dataDTO = mapper2.Map<EquipmentRentDTO>(updatedData);

            return dataDTO;
        }


        public static bool Delete(int id, int ownerid)
        {
            var checkequpment = FarmerDataAccessFactory.FarmerEquipmentRentData().Get(id);
            if (checkequpment == null)
            {
                throw new Exception("This Equipment Does Not Exists in the System.");
            }
            else if (checkequpment.OwnerUserId != ownerid)
            {
                throw new Exception("Your Profile Does not Match With This Eqipment Owner.");
            }
            else if (checkequpment.RentStatus != "Not Rented")
            {
                throw new Exception("You can not Delete a Rented Equipment.");
            }
            return FarmerDataAccessFactory.FarmerEquipmentRentData().Delete(id);
        }

        public static FarmerEquipmentRentDTO GetRentRelatedHistory(int id)
        {
            var data = DataAccessFactory.UserData().Get(id);
            if (data == null)
            {
                throw new Exception("Invalid Access to the Equipment Rent Data.");
            }
            else if (data.PlantingCalendars == null || data.PlantingCalendars.Count() == 0)
            {
                throw new Exception("You Do not Have Any Data in the Equipment Rent.");
            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, FarmerEquipmentRentDTO>();
                c.CreateMap<EquipmentRent, EquipmentRentDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FarmerEquipmentRentDTO>(data);
            return mapped;
        }
    }
}
