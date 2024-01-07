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
    public class FarmerTrainingServices
    {
        public static TrainingTableDTO GetTrainigDetailsById(int id)
        {
            var data = FarmerDataAccessFactory.FarmerTrainingData().Get(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TrainingTable, TrainingTableDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<TrainingTableDTO>(data);
            }

            return null;
        }


        public static List<TrainingTableDTO> GetTrainigDetailsByRegion(string region)
        {
            var data = FarmerDataAccessFactory.FarmerTrainingData().GetRegionTrnasport(region);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TrainingTable, TrainingTableDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<TrainingTableDTO>>(data);
            }
            return null;
        }
    }
}
