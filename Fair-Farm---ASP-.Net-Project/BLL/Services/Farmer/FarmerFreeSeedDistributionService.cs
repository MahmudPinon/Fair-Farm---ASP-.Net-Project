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
    public class FarmerFreeSeedDistributionService
    {
        public static FreeSeedsDistributionDTO GetFreeSeedsDistributionInfoById(int id)
        {
            var data = FarmerDataAccessFactory.FarmerFreeSeedDistributionData().Get(id);

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


        public static List<FreeSeedsDistributionDTO> GetFreeSeedsDistributionInfoByRegion(string id)
        {
            var data = FarmerDataAccessFactory.FarmerFreeSeedDistributionData().GetRegionTrnasport(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<FreeSeedsDistribution, FreeSeedsDistributionDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<FreeSeedsDistributionDTO>>(data);
            }
            return null;
        }

    }
}
