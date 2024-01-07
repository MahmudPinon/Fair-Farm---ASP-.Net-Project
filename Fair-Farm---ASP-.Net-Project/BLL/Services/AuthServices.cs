using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthServices
    {
        public static TokenDTO Login(string uname, string pass)
        {
           /* return DataAccessFactory.AuthData().Auth(uname, pass);*/




            var res = DataAccessFactory.AuthData().Auth(uname, pass);
            if (res)
            {
                var token = new Token();
                token.UserName = uname;
                token.CreatedAt = DateTime.Now;
                token.TKey = Guid.NewGuid().ToString();
                /*token.UserId = 2;*/

                token.UserId = DataAccessFactory.GetUserIdData().GetUserIdByUserName(uname);
                var ret = DataAccessFactory.TokenData().Add(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    /* return mapper.Map<TokenDTO>(ret);*/
                    return mapper.Map<TokenDTO>(ret);
                }

            }
            return null;
        }
        public static bool IsTokenValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (extk != null && extk.DeletedAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            extk.DeletedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null)
            {
                return true;
            }
            return false;


        }
        public static bool IsAdmin(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (IsTokenValid(tkey) && extk.User.UserType.Equals("Admin"))
            {
                return true;
            }
            return false;
        }

        public static bool IsTrader(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (IsTokenValid(tkey) && extk.User.UserType.Equals("Trader"))
            {
                return true;
            }
            return false;
        }

        public static bool IsFarmer(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (IsTokenValid(tkey) && extk.User.UserType.Equals("Farmer"))
            {
                return true;
            }
            return false;
        }
    }
    }

