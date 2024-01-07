using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Admin
{
    public class PreviousPriceDataService
    {
        public static List<PreviousPriceDTO> Get()
        {
            var data = DataAccessFactory.PreviousPriceData().Get();
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PreviousPrice, PreviousPriceDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PreviousPriceDTO>>(data);
        }

        public static PreviousPriceDTO Get(int id)
        {
            var data = DataAccessFactory.PreviousPriceData().Get(id);

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

        public static bool Delete(int id)
        {
            var PPData = DataAccessFactory.PreviousPriceData().Get(id);

            if (PPData != null)
            {
                var isDeleted = DataAccessFactory.PreviousPriceData().Delete(id);

                return isDeleted;
            }

            return false;
        }
    }
}
