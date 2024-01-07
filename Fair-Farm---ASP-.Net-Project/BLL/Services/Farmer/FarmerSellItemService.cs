using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Farmer
{
    public class FarmerSellItemService
    {
        public static List<RequestTableItemDTO> Add(List<RequestTableItemDTO> s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTableItemDTO, RequestTableItem>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<RequestTableItem>>(s);
            if (data.Count == 0)
            {
                throw new Exception("Empty List Submitted.");
            }

            int reqid = data[0].RequestId;
            var checkitem = FarmerDataAccessFactory.FarmersellandColdStorageRequestData().GetSinle(reqid);
            if (checkitem == null)
            {
                throw new Exception("Invalid Request Id is Provided.");
            }
            else if (checkitem.Status == "Approved")
            {
                throw new Exception("Request is Already Approved You can not Add More Item.");
            }
            else if (checkitem.RequestType != "Sell")
            {
                throw new Exception("Your Request Type is not Sell.");
            }
            var region = checkitem.Region;
            foreach (var item in data)
            {
                item.Region = region;
                item.RequestId = reqid;
            }

            foreach (var item in data)
            {
                if (item.CropsName == null || item.CropsQuantity == null || item.Price == null || item.Description == null)
                {
                    throw new Exception("You Have Provided Some Empty Field.");
                }
            }

            var addedData = FarmerDataAccessFactory.FarAddSellItemtotheRequestItemData().Create(data);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTableItem, RequestTableItemDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<List<RequestTableItemDTO>>(addedData);

            return data2;
        }



        public static bool Delete(int id1)
        {
            var checkrequest = FarmerDataAccessFactory.FarAddSellItemtotheRequestItemData().Get(id1);

            if (checkrequest == null || checkrequest.Count == 0)
            {
                throw new Exception("This Request Does Not Exist in the System.");
            }

            var requestId = checkrequest[0].RequestId;
            var checkitem = FarmerDataAccessFactory.FarmersellandColdStorageRequestData().GetSinle(requestId);

            if (checkitem == null)
            {
                throw new Exception("The Request Item Data is Null.");
            }

            if (checkitem.Status == "Approved")
            {
                throw new Exception("You Cannot Delete an Approved Request Item Data from the Item Table.");
            }

            return FarmerDataAccessFactory.FarAddSellItemtotheRequestItemData().Delete(id1);
        }


        public static List<RequestTableItemDTO> UpdateData(List<RequestTableItemDTO> s, int userid)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTableItemDTO, RequestTableItem>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<RequestTableItem>>(s);
            if (data.Count == 0)
            {
                throw new Exception("Empty List Submitted.");
            }

            int reqid = data[0].RequestId;
            var checkitem = FarmerDataAccessFactory.FarmersellandColdStorageRequestData().GetSinle(reqid);
            if (checkitem == null)
            {
                throw new Exception("Invalid Request Id is Provided.");
            }
            else if (checkitem.Status == "Approved")
            {
                throw new Exception("Request is Already Approved You can not Add More Item.");
            }
            else if (checkitem.RequestType != "Sell")
            {
                throw new Exception("Your Request Type is not Sell.");
            }
            var region = checkitem.Region;
            foreach (var item in data)
            {
                item.Region = region;
                item.RequestId = reqid;
            }

            foreach (var item in data)
            {
                if ((item.CropsName.Length == 0 && item.CropsName != null) || (item.CropsQuantity.Length == 0 && item.CropsQuantity != null) || (item.Price.Length == 0 && item.Price != null) || (item.Description.Length == 0 && item.Description != null))
                {
                    throw new Exception("You Have Provided Some Empty Field.");
                }
            }

            var addedData = FarmerDataAccessFactory.FarAddSellItemtotheRequestItemData().Update(data);
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTableItem, RequestTableItemDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<List<RequestTableItemDTO>>(addedData);

            return data2;
        }


        public static List<RequestTableItemDTO> GetAll(int Id)
        {
            var data = FarmerDataAccessFactory.FarAddSellItemtotheRequestItemData().Get(Id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestTableItem, RequestTableItemDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<RequestTableItemDTO>>(data);
            }

            return null;
        }

        public static RequestTableItemDTO GetSinle(int id, int requestId)
        {
            var data = FarmerDataAccessFactory.FarAddSellItemtotheRequestItemData().GetSingleItem(id, requestId);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestTableItem, RequestTableItemDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<RequestTableItemDTO>(data);
            }

            return null;
        }



    }
}
