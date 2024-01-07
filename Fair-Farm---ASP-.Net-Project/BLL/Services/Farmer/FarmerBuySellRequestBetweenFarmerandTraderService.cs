using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Farmer
{
    public class FarmerBuySellRequestBetweenFarmerandTraderService
    {
        public static List<BuySellRequestBetweenFarmerAndTraderDTO> GetBuySellRequestBetweenFarmerandTraderbyRegion(string region)
        {
            var data = FarmerDataAccessFactory.FarmerBuySellRequestBetweenFarmerandTrader().Get(region);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BuySellRequestBetweenFarmerAndTrader, BuySellRequestBetweenFarmerAndTraderDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<BuySellRequestBetweenFarmerAndTraderDTO>>(data);
            }
            return null;
        }




        public static BuySellRequestBetweenFarmerAndTraderDTO GetBuySellRequestBetweenFarmerandTraderbyId(int Id)
        {
            var data = FarmerDataAccessFactory.FarmerBuySellRequestBetweenFarmerandTrader().GetSingle(Id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BuySellRequestBetweenFarmerAndTrader, BuySellRequestBetweenFarmerAndTraderDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<BuySellRequestBetweenFarmerAndTraderDTO>(data);
            }
            return null;
        }

        public static BuySellRequestBetweenFarmerAndTraderDTO Update(BuySellRequestBetweenFarmerAndTraderDTO dt, int userId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BuySellRequestBetweenFarmerAndTraderDTO, BuySellRequestBetweenFarmerAndTrader>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<BuySellRequestBetweenFarmerAndTrader>(dt);

            var user = DataAccessFactory.UserData().Get(userId);

            if (user == null)
            {
                throw new Exception("You are not a Registered User of the System.");
            }
            else if (data == null)
            {
                throw new Exception("You Have Provided Empty Data.");
            }

            var cropsdata = FarmerDataAccessFactory.FarmerBuySellRequestBetweenFarmerandTrader().GetSingle(data.Id);
            if (data.Id == 0)
            {
                throw new Exception("Invalid Input.");
            }
            else if (cropsdata == null)
            {
                throw new Exception("This Crops Does not Exists in the System.");
            }
            else if (user.UserRegion != data.Region)
            {
                throw new Exception("This Request Does not Belongs to Your Region.");
            }
            else if (cropsdata.Status != "Refere")
            {
                throw new Exception("This Request is Already Taken by Another Farmer.");
            }
            else if (data.Status != "Approved")
            {
                throw new Exception("Invalid Input.");
            }
            data.Userid = userId;

            var updatedData = FarmerDataAccessFactory.FarmerBuySellRequestBetweenFarmerandTrader().Update(data);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BuySellRequestBetweenFarmerAndTrader, BuySellRequestBetweenFarmerAndTraderDTO>();
            });
            var mapper2 = new Mapper(config2);
            var dataDTO = mapper2.Map<BuySellRequestBetweenFarmerAndTraderDTO>(updatedData);

            return dataDTO;
        }

    }
}
