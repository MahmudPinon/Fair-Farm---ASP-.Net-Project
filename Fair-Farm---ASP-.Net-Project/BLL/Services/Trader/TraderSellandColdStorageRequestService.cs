using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Trader
{
    public class TraderSellandColdStorageRequestService
    {
        public static RequestTableDTO Add(RequestTableDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTableDTO, RequestTable>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<RequestTable>(s);

            var userId = data.UserId;
            var requesttype = data.RequestType;

            var checkuser = DataAccessFactory.UserData().Get(userId);
            if (checkuser == null)
            {
                throw new Exception("Your Profile Does not Exists in the System.");
            }
            else if (requesttype != "Cold Storage" && requesttype != "Sell")
            {
                throw new Exception("Invalid Request Type.");
            }
            data.Status = "Pending";
            data.Date = DateTime.Now;
            data.Region = checkuser.UserRegion;
            var addedData = DataAccessFactoryTrader.TradersellandColdStorageRequestData().Create(data);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTable, RequestTableDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<RequestTableDTO>(addedData);

            return data2;
        }


        public static bool Delete(int id1, int userid)
        {
            var checkrequest = DataAccessFactoryTrader.TradersellandColdStorageRequestData().Getexists(id1, userid);
            if (checkrequest == null)
            {
                throw new Exception("This Request Does Not Exists in the System.");
            }
            else if (checkrequest.Status == "Approved")
            {
                throw new Exception("You Can not Delete a Approved Data from the Request Table.");
            }
            return DataAccessFactoryTrader.TradersellandColdStorageRequestData().Delete(id1);
        }

        public static RequestTableDTO Update(RequestTableDTO dt, int userid)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTableDTO, RequestTable>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<RequestTable>(dt);

            var requesttableid = data.Id;
            var checkrequest = DataAccessFactoryTrader.TradersellandColdStorageRequestData().Getexists(requesttableid, userid);
            var checkuser = DataAccessFactory.UserData().Get(userid);
            if (data == null)
            {
                throw new Exception("Invalid Request Type.");
            }
            else if (checkrequest == null)
            {
                throw new Exception("This Request Does Not Exists in the System.");
            }
            else if (checkuser == null)
            {
                throw new Exception("This User Does Not Exists in the System.");
            }
            else if (checkrequest.UserId != userid)
            {
                throw new Exception("You are not Owner of this Request.");
            }
            else if (data.RequestType != null && (data.RequestType != "Cold Storage" && data.RequestType != "Sell"))
            {
                throw new Exception("In-Appropriate Request Type.");
            }
            else if (checkrequest.Status != "Pending")
            {
                throw new Exception("You can not Update this Request.");
            }
            data.Date = checkrequest.Date;
            data.Region = checkrequest.Region;
            data.Status = checkrequest.Status;
            data.UserId = checkrequest.UserId;
            var updatedData = DataAccessFactoryTrader.TradersellandColdStorageRequestData().Update(data);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTable, RequestTableDTO>();
            });
            var mapper2 = new Mapper(config2);
            var dataDTO = mapper2.Map<RequestTableDTO>(updatedData);

            return dataDTO;
        }

        public static RequestTableDTO Get(int id, int userid)
        {
            var data = DataAccessFactoryTrader.TradersellandColdStorageRequestData().Getexists(id, userid);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestTable, RequestTableDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<RequestTableDTO>(data);
            }

            return null;
        }


        public static List<RequestTableDTO> Get(int userid, string type)
        {
            var data = DataAccessFactoryTrader.TradersellandColdStorageRequestData().GetByType(userid, type);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestTable, RequestTableDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<RequestTableDTO>>(data);
            }

            return null;
        }


        public static RequestTableDTO GetSinle(int id)///No need in the Controller
        {
            var data = DataAccessFactoryTrader.TradersellandColdStorageRequestData().GetSinle(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestTable, RequestTableDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<RequestTableDTO>(data);
            }

            return null;
        }



        public static RequestTableDTO GetSinlebyUserId(int userid)
        {
            var data = DataAccessFactoryTrader.TradersellandColdStorageRequestData().GetSinlebyUserId(userid);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestTable, RequestTableDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<RequestTableDTO>(data);
            }

            return null;
        }


    }
}
