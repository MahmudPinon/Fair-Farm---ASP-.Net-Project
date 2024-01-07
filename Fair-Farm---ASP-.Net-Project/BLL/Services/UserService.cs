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



namespace BLL.Services
{
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Get();
            /*var data = CourseRepo.Get();*/
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data);
        }

       
        public static UserDTO Add(UserDTO c)
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
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(c);
            var x = DataAccessFactory.UserData().Add(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<UserDTO>(x);

            return data2;
        }


       

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Get(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<UserDTO>(data);
            }

            return null;
        }

        public static UserDTO Update(UserDTO user)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var userData = mapper.Map<User>(user);

            var updatedUserData = DataAccessFactory.UserData().Update(userData);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper2 = new Mapper(config2);
            var updatedUserDTO = mapper2.Map<UserDTO>(updatedUserData);

            return updatedUserDTO;
        }

        public static bool Delete(int id)
        {
            var UserData = DataAccessFactory.UserData().Get(id);

            if (UserData != null)
            {
                var isDeleted = DataAccessFactory.UserData().Delete(id);

                return isDeleted;
            }

            return false;
        }



    }

}
