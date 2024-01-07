using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Trader
{
    public class TransportService
    {
        public static List<TransportationFleetRegisterDTO> GetAll()
        {
            var data = DataAccessFactoryTrader.TransportContent().GetAll();
            return Convert(data);
        }

        public static int Add(TransportationFleetRegisterDTO data)
        {
            var value = Convert(data);
            return DataAccessFactoryTrader.TransportContent().Add(value);
        }
        private static List<TransportationFleetRegisterDTO> Convert(List<TransportationFleetRegister> data)
        {
            var value = new List<TransportationFleetRegisterDTO>();
            foreach (TransportationFleetRegister transport in data)
            {
                value.Add(Convert(transport));
            }
            return value;
        }

        private static List<TransportationFleetRegister> Convert(List<TransportationFleetRegisterDTO> data)
        {
            var value = new List<TransportationFleetRegister>();
            foreach (TransportationFleetRegisterDTO transport in data)
            {
                value.Add(Convert(transport));
            }
            return value;
        }




        static TransportationFleetRegisterDTO Convert(TransportationFleetRegister Trans)
        {
            return new TransportationFleetRegisterDTO()
            {
                Id = Trans.Id,
                Capacity = Trans.Capacity,
                Location = Trans.Location,
                PerdayRent = Trans.PerdayRent,
                PhoneNumber = Trans.PhoneNumber,
                Region = Trans.Region,
                RentedStatus = Trans.RentedStatus,
                TransportationName = Trans.TransportationName,
                TransportationNumber = Trans.TransportationNumber,
                Userid = Trans.Userid
            };
        }
        static TransportationFleetRegister Convert(TransportationFleetRegisterDTO Trans)
        {
            return new TransportationFleetRegister()
            {
                Id = Trans.Id,
                Capacity = Trans.Capacity,
                Location = Trans.Location,
                PerdayRent = Trans.PerdayRent,
                PhoneNumber = Trans.PhoneNumber,
                Region = Trans.Region,
                RentedStatus = Trans.RentedStatus,
                TransportationName = Trans.TransportationName,
                TransportationNumber = Trans.TransportationNumber,
                Userid = Trans.Userid
            };
        }
    }
}
