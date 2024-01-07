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
    public class FarmerAccessRedListService
    {
        public static List<UserDTO> GetRedListedUserbyFarmerandbyRegion(string region, string type)
        {
            var data = FarmerDataAccessFactory.FarmerAccesstoRedListUserData().GetByRegion(region, type);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<UserDTO>>(data);
            }
            return null;
        }


        public static UserDTO GetRedListedUserbyFarmerandbyId(int id, string type)
        {
            var data = FarmerDataAccessFactory.FarmerAccesstoRedListUserData().GetById(id, type);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<UserDTO>(data);
            }

            return null;
        }


    }

}
