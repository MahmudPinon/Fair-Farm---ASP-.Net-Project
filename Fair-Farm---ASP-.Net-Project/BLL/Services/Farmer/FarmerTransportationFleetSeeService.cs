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
    public class FarmerTransportationFleetSeeService
    {
        public static TransportationFleetRegisterDTO GetForFarmerTransport(int id)
        {
            var data = FarmerDataAccessFactory.FarmerTransportationFleetRegisterData().Get(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TransportationFleetRegister, TransportationFleetRegisterDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<TransportationFleetRegisterDTO>(data);
            }

            return null;
        }


        public static List<TransportationFleetRegisterDTO> GetByRegionForFarmerTransport(string id)
        {
            var data = FarmerDataAccessFactory.FarmerTransportationFleetRegisterData().GetRegionTrnasport(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TransportationFleetRegister, TransportationFleetRegisterDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<TransportationFleetRegisterDTO>>(data);
            }
            return null;
        }
    }
}
