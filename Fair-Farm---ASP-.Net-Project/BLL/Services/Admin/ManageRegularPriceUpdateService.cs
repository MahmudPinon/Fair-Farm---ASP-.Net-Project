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
    public class ManageRegularPriceUpdateService
    {
        public static List<RegularPriceUpdateDTO> Get()
        {
            var data = DataAccessFactory.RegularPriceData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegularPriceUpdate, RegularPriceUpdateDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<RegularPriceUpdateDTO>>(data);
        }

        public static RegularPriceUpdateDTO Add(RegularPriceUpdateDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegularPriceUpdateDTO, RegularPriceUpdate>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<RegularPriceUpdate>(s);
            var x = DataAccessFactory.RegularPriceData().Add(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegularPriceUpdate, RegularPriceUpdateDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<RegularPriceUpdateDTO>(x);

            return data2;
        }

        public static RegularPriceUpdateDTO Get(int id)
        {
            var data = DataAccessFactory.RegularPriceData().Get(id);

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

        public static RegularPriceUpdateDTO Update(RegularPriceUpdateDTO price)
        {
            var previousPrice = Get(price.Id);
            var configPP = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegularPriceUpdateDTO, PreviousPrice>();
            });
            var mapperPP = new Mapper(configPP);
            var dataPP = mapperPP.Map<PreviousPrice>(previousPrice);
            var dataCheckAvailable = DataAccessFactory.PreviousPriceData().Get(dataPP.Id);
            if (dataCheckAvailable!=null)
            {
                DataAccessFactory.PreviousPriceData().Delete(dataPP.Id);

            }
            DataAccessFactory.PreviousPriceData().Add(dataPP);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegularPriceUpdateDTO, RegularPriceUpdate>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<RegularPriceUpdate>(price);

            var updatedData = DataAccessFactory.RegularPriceData().Update(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegularPriceUpdate, RegularPriceUpdateDTO>();
            });
            var mapper2 = new Mapper(config2);
            var dataDTO = mapper2.Map<RegularPriceUpdateDTO>(updatedData);

            return dataDTO;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.RegularPriceData().Delete(id);
        }


    }


}
