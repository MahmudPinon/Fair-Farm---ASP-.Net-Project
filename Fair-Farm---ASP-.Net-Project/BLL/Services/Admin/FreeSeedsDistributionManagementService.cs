using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Admin
{
    public class FreeSeedsDistributionManagementService
    {
        public static List<FreeSeedsDistributionDTO> Get()
        {
            var data = DataAccessFactory.FreeSeedReqData().Get();
         
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FreeSeedsDistribution, FreeSeedsDistributionDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<FreeSeedsDistributionDTO>>(data);
        }

        public static FreeSeedsDistributionDTO Add(FreeSeedsDistributionDTO c)
        {
            var validationResults = new List<ValidationResult>();
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(c, serviceProvider: null, items: null);
            bool isValid = Validator.TryValidateObject(c, context, validationResults, validateAllProperties: true);

            if (!isValid)
            {

                return null;
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FreeSeedsDistributionDTO, FreeSeedsDistribution>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<FreeSeedsDistribution>(c);
            var x = DataAccessFactory.FreeSeedReqData().Add(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FreeSeedsDistribution, FreeSeedsDistributionDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<FreeSeedsDistributionDTO>(x);

            return data2;
        }

        public static FreeSeedsDistributionDTO Get(int id)
        {
            var data = DataAccessFactory.FreeSeedReqData().Get(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<FreeSeedsDistribution, FreeSeedsDistributionDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<FreeSeedsDistributionDTO>(data);
            }

            return null;
        }

        public static FreeSeedsDistributionDTO Update(FreeSeedsDistributionDTO tr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FreeSeedsDistributionDTO, FreeSeedsDistribution>();
            });
            var mapper = new Mapper(config);
            var FreeSeedsReqData = mapper.Map<FreeSeedsDistribution>(tr);

            var updatedFreeSeedReqData = DataAccessFactory.FreeSeedReqData().Update(FreeSeedsReqData);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FreeSeedsDistribution, FreeSeedsDistributionDTO>();
            });
            var mapper2 = new Mapper(config2);
            var updatedFreeSeedReqDTO = mapper2.Map<FreeSeedsDistributionDTO>(updatedFreeSeedReqData);

            return updatedFreeSeedReqDTO;
        }

        public static bool Delete(int id)
        {
            var FreeSeedRequestData = DataAccessFactory.FreeSeedReqData().Get(id);

            if (FreeSeedRequestData != null)
            {
                var isDeleted = DataAccessFactory.FreeSeedReqData().Delete(id);

                return isDeleted;
            }

            return false;
        }
    }
}
