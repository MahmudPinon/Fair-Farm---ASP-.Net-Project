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
    public class FarmerRegularPriceService
    {
        public static List<RegularPriceUpdateDTO> GetallRegularPriceData()
        {
            var data = FarmerDataAccessFactory.FarmerRegularPriceData().GetAll();

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RegularPriceUpdate, RegularPriceUpdateDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<RegularPriceUpdateDTO>>(data);
            }
            return null;

        }

        public static RegularPriceUpdateDTO GetRegularPriceDatabyId(int id)
        {
            var data = FarmerDataAccessFactory.FarmerRegularPriceData().GetbyId(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RegularPriceUpdate, RegularPriceUpdateDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<RegularPriceUpdateDTO>(data);
            }

            return null;
        }


    }
}
