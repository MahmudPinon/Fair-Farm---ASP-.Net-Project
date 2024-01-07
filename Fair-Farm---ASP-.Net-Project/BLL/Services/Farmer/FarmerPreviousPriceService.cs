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
    public class FarmerPreviousPriceService
    {

        public static List<PreviousPriceDTO> GetallPreviousPriceData()
        {
            var data = FarmerDataAccessFactory.FarmerPreviousData().GetAll();

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PreviousPrice, PreviousPriceDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<PreviousPriceDTO>>(data);
            }
            return null;

        }


        public static PreviousPriceDTO GetPreviousPriceDatabyId(int id)
        {
            var data = FarmerDataAccessFactory.FarmerPreviousData().GetbyId(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PreviousPrice, PreviousPriceDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<PreviousPriceDTO>(data);
            }

            return null;
        }
    }
}
