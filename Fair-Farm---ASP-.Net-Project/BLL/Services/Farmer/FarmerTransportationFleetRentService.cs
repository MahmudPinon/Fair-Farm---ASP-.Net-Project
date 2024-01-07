using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Farmer
{
    public class FarmerTransportationFleetRentService
    {
        public static TransportationFleetRentDTO Add(TransportationFleetRentDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransportationFleetRentDTO, TransportationFleetRent>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<TransportationFleetRent>(s);

            var renterid = data.Renterid;
            var days = data.HowmanydaysforRent;
            var transportid = data.TransportationFleetRegisterId;
            data.Approvestatus = null;
            var checkalreadyrequest = FarmerDataAccessFactory.FarmerTransportationFleetRentData().Getexists(data.Renterid, data.TransportationFleetRegisterId);
            var checkuser = DataAccessFactory.UserData().Get(renterid);
            var transport = FarmerDataAccessFactory.FarmerTransportationFleetRegisterData().Get(transportid);
            if (checkuser == null)
            {
                throw new Exception("Your Profile Does not Exists in the System.");
            }
            else if (transport == null)
            {
                throw new Exception("This Transport Does not Exists in the System.");
            }
            else if (transport.Userid == renterid)
            {
                throw new Exception("You Can Not Rent Your Transport.");
            }
            else if (transport.Region != checkuser.UserRegion)
            {
                throw new Exception("This Transport Does not Belongs to Your Region.");
            }
            else if (transport.RentedStatus == "Rented")
            {
                throw new Exception("This Transportation is Already Rented You Can not Rent It.");
            }
            else if (days <= 0)
            {
                throw new Exception("Days Can not be Negative or 0.");
            }
            else if (data.Location == null)
            {
                throw new Exception("Location Can not be Null or Empty.");
            }
            else if (checkuser.UserType == "Admin")
            {
                throw new Exception("Admin Can not Rent the Transport.");
            }
            else if (checkalreadyrequest != null)
            {
                throw new Exception("You Already Requested For this Transport.");
            }
            data.Region = checkuser.UserRegion;
            data.TotalRent = transport.PerdayRent * days;
            data.Approvestatus = "Pending";
            data.TransportationName = transport.TransportationName;
            data.TransportationNumber = transport.TransportationNumber;
            var addedData = FarmerDataAccessFactory.FarmerTransportationFleetRentData().Add(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransportationFleetRent, TransportationFleetRentDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<TransportationFleetRentDTO>(addedData);

            return data2;
        }


        public static TransportationFleetRentDTO UpdatebyFarmer(int id, int renterid, TransportationFleetRentDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransportationFleetRentDTO, TransportationFleetRent>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<TransportationFleetRent>(s);
            var transport = FarmerDataAccessFactory.FarmerTransportationFleetRentData().Get(id);

            if (transport == null)
            {
                throw new Exception("This Transportation Does not Exists in the System.");
            }
            else if (s == null)
            {
                throw new Exception("You Do not Provided Any Data To Update.");
            }
            else if (data.Location == null && data.HowmanydaysforRent <= 0)
            {
                throw new Exception("You Do not Provided Correct Data To Update.");
            }
            else if (transport.Renterid != renterid)
            {
                throw new Exception("You are not Renter of this Transport.");
            }
            else if (transport.Approvestatus == "Approved")
            {
                throw new Exception("You can Not Modify this Record as itis Already Approved.");
            }
            else if (data.HowmanydaysforRent <= 0 && data.Location != null)
            {
                data.TotalRent = transport.TotalRent;
            }
            else if (data.HowmanydaysforRent > 0 && data.Location == null)
            {
                data.Location = transport.Location;
                var transportsingle = FarmerDataAccessFactory.FarmerTransportationFleetRegisterData().Get(transport.TransportationFleetRegisterId);
                data.TotalRent = transportsingle.PerdayRent * (data.HowmanydaysforRent);
            }
            else if (data.HowmanydaysforRent > 0 && data.Location != null)
            {
                var transportsingle = FarmerDataAccessFactory.FarmerTransportationFleetRegisterData().Get(transport.TransportationFleetRegisterId);
                data.TotalRent = transportsingle.PerdayRent * (data.HowmanydaysforRent);
                data.Location = transport.Location;


            }

            data.TransportationName = transport.TransportationName;
            data.TransportationNumber = transport.TransportationNumber;
            data.Region = transport.Region;
            data.Approvestatus = transport.Approvestatus;
            data.TransportationFleetRegisterId = transport.TransportationFleetRegisterId;
            data.Renterid = transport.Renterid;
            data.Id = id;

            var updatedData = FarmerDataAccessFactory.FarmerTransportationFleetRentData().Update(data);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransportationFleetRent, TransportationFleetRentDTO>();
            });
            var mapper2 = new Mapper(config2);
            var dataDTO = mapper2.Map<TransportationFleetRentDTO>(updatedData);

            return dataDTO;
        }

        public static bool Delete(int id, int renterid)
        {
            var checktransport = FarmerDataAccessFactory.FarmerTransportationFleetRentData().Get(id);
            if (checktransport == null)
            {
                throw new Exception("This Transport Does Not Exists in the System.");

            }
            else if (checktransport.Renterid != renterid)
            {
                throw new Exception("Your Profile Does not Match With This Transport Renter.");
            }
            else if (checktransport.Approvestatus == "Not Approved")
            {
                throw new Exception("You can not Delete This Request.");
            }
            else if (checktransport.Approvestatus != "Pending")
            {
                throw new Exception("You can not Delete a Approved Transport.");
            }
            return FarmerDataAccessFactory.FarmerTransportationFleetRentData().Delete(id);
        }

        public static TransportationFleetRentDTO GetOwnRentedTransport(int id, int renterid)
        {
            var data = FarmerDataAccessFactory.FarmerTransportationFleetRentData().Get(id);
            if (data == null)
            {
                throw new Exception("This Transport Record Does not Exists in the System.");
            }
            else if (data.Renterid != renterid)
            {
                throw new Exception("You are not Renter of this Transport.");
            }
            else if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TransportationFleetRent, TransportationFleetRentDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<TransportationFleetRentDTO>(data);
            }

            return null;
        }


        public static List<TransportationFleetRentDTO> GetFarmerRentTransportHistory(int ownerid)
        {
            var data = FarmerDataAccessFactory.FarmerTransportationFleetRentData().GetFarmerTransportRentRecords(ownerid);
            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TransportationFleetRent, TransportationFleetRentDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<TransportationFleetRentDTO>>(data);
            }
            return null;
        }

    }
}
