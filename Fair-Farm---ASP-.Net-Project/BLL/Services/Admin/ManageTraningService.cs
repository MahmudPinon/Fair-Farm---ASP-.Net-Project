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
    public class ManageTraningService
    {
        public static List<TrainingTableDTO> Get()
        {
            var data = DataAccessFactory.TrainingData().Get();
            /*var data = CourseRepo.Get();*/
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrainingTable, TrainingTableDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TrainingTableDTO>>(data);
        }

        public static TrainingTableDTO Add(TrainingTableDTO c)
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
                cfg.CreateMap<TrainingTableDTO, TrainingTable>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<TrainingTable>(c);
            var x = DataAccessFactory.TrainingData().Add(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrainingTable, TrainingTableDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<TrainingTableDTO>(x);

            return data2;
        }

        public static TrainingTableDTO Get(int id)
        {
            var data = DataAccessFactory.TrainingData().Get(id);

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

        public static TrainingTableDTO Update(TrainingTableDTO tr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrainingTableDTO, TrainingTable>();
            });
            var mapper = new Mapper(config);
            var trainingData = mapper.Map<TrainingTable>(tr);

            var updatedTrainingData = DataAccessFactory.TrainingData().Update(trainingData);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrainingTable, TrainingTableDTO>();
            });
            var mapper2 = new Mapper(config2);
            var updatedTrainingDTO = mapper2.Map<TrainingTableDTO>(updatedTrainingData);

            return updatedTrainingDTO;
        }

        public static bool Delete(int id)
        {
            var trainingData = DataAccessFactory.TrainingData().Get(id);

            if (trainingData != null)
            {
                var isDeleted = DataAccessFactory.TrainingData().Delete(id);

                return isDeleted;
            }

            return false;
        }
    }
}
