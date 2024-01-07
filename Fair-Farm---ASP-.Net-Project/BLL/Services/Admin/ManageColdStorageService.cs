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
    public class ManageColdStorageService
    {
        public static List<ManageColdStorageDTO> Get()
        {
            var data = DataAccessFactory.ColdStorageData().Get();
            /*var data = CourseRepo.Get();*/
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManageColdStorage, ManageColdStorageDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ManageColdStorageDTO>>(data);
        }

        public static ManageColdStorageDTO Add(ManageColdStorageDTO c)
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
                cfg.CreateMap<ManageColdStorageDTO, ManageColdStorage>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ManageColdStorage>(c);
            var x = DataAccessFactory.ColdStorageData().Add(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManageColdStorage, ManageColdStorageDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<ManageColdStorageDTO>(x);

            return data2;
        }

        public static ManageColdStorageDTO Get(int id)
        {
            var data = DataAccessFactory.ColdStorageData().Get(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ManageColdStorage, ManageColdStorageDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<ManageColdStorageDTO>(data);
            }

            return null;
        }

        public static ManageColdStorageDTO Update(ManageColdStorageDTO tr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManageColdStorageDTO, ManageColdStorage>();
            });
            var mapper = new Mapper(config);
            var ColdStorageData = mapper.Map<ManageColdStorage>(tr);

            var updatedColdStorageData = DataAccessFactory.ColdStorageData().Update(ColdStorageData);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManageColdStorage, ManageColdStorageDTO>();
            });
            var mapper2 = new Mapper(config2);
            var updatedTrainingDTO = mapper2.Map<ManageColdStorageDTO>(updatedColdStorageData);

            return updatedTrainingDTO;
        }

        public static bool Delete(int id)
        {
            var ColdStorageData = DataAccessFactory.ColdStorageData().Get(id);

            if (ColdStorageData != null)
            {
                var isDeleted = DataAccessFactory.ColdStorageData().Delete(id);

                return isDeleted;
            }

            return false;
        }
    }
}
