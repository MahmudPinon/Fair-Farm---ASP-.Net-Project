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
    public class FarmerColdStorageItemService
    {
        public static List<ColdStorageItemListDTO> Add(List<ColdStorageItemListDTO> s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ColdStorageItemListDTO, ColdStorageItemList>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ColdStorageItemList>>(s);

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
            else if (checkitem.RequestType != "Cold Storage")
            {
                throw new Exception("Your Request Type is not Cold Storage.");
            }
            var region = checkitem.Region;
            foreach (var item in data)
            {
                item.Region = region;
                item.RequestId = reqid;
            }

            foreach (var item in data)
            {
                if (item.CropsName == null || item.CropsQuantity == 0 || item.Duration == 0)
                {
                    throw new Exception("You Have Provided Some Empty Field.");
                }
            }

            var extradata = DataAccessFactory.ColdStorageData().Get();
            var matchingRegionData = extradata.FirstOrDefault(item => item.Region == region);

            if (matchingRegionData == null)
            {
                throw new Exception("No matching region data found.");
            }

            var singlerent = matchingRegionData.PerdayPerkgPrice;

            foreach (var item in data)
            {
                item.TotalRent = item.Duration * (item.CropsQuantity * singlerent);
            }

            var addedData = FarmerDataAccessFactory.FarAddColdStorageItemtotheRequestItemData().Create(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ColdStorageItemList, ColdStorageItemListDTO>();
            });

            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<List<ColdStorageItemListDTO>>(addedData);

            return data2;
        }



        public static bool Delete(int id1)
        {
            var checkrequest = FarmerDataAccessFactory.FarAddColdStorageItemtotheRequestItemData().Get(id1);
            if (checkrequest == null)
            {
                throw new Exception("This Request Does Not Exists in the System.");
            }
            var checkitem = FarmerDataAccessFactory.FarmersellandColdStorageRequestData().GetSinle(checkrequest[0].RequestId);

            if (checkitem.Status == "Approved")
            {
                throw new Exception("You Can not Delete a Approved Cold Storage Item Data from the Item Table.");
            }
            return FarmerDataAccessFactory.FarAddColdStorageItemtotheRequestItemData().Delete(id1);
        }

        public static List<ColdStorageItemListDTO> UpdateData(List<ColdStorageItemListDTO> s, int userId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ColdStorageItemListDTO, ColdStorageItemList>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ColdStorageItemList>>(s);

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
                throw new Exception("You cannot modify approved request data.");
            }
            else if (checkitem.RequestType != "Cold Storage")
            {
                throw new Exception("Your request type is not Cold Storage.");
            }

            var region = checkitem.Region;

            foreach (var item in data)
            {
                item.Region = region;
                item.RequestId = reqid;
            }

            foreach (var item in data)
            {
                if (item.CropsName == null || item.CropsQuantity == 0 || item.Duration == 0)
                {
                    throw new Exception("You have provided some empty field.");
                }
            }

            var extradata = DataAccessFactory.ColdStorageData().Get();
            var matchingRegionData = extradata.FirstOrDefault(item => item.Region == region);

            if (matchingRegionData == null)
            {
                throw new Exception("No matching region data found.");
            }

            var singlerent = matchingRegionData.PerdayPerkgPrice;

            foreach (var item in data)
            {
                item.TotalRent = item.Duration * (item.CropsQuantity * singlerent);
            }

            var updatedData = FarmerDataAccessFactory.FarAddColdStorageItemtotheRequestItemData().Update(data);

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ColdStorageItemList, ColdStorageItemListDTO>();
            });

            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<List<ColdStorageItemListDTO>>(updatedData);

            return data2;
        }



        public static List<ColdStorageItemListDTO> GetAll(int Id)
        {
            var data = FarmerDataAccessFactory.FarAddColdStorageItemtotheRequestItemData().Get(Id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ColdStorageItemList, ColdStorageItemListDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<ColdStorageItemListDTO>>(data);
            }

            return null;
        }

        public static ColdStorageItemListDTO GetSinle(int id, int requestId)
        {
            var data = FarmerDataAccessFactory.FarAddColdStorageItemtotheRequestItemData().GetSingleItem(id, requestId);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ColdStorageItemList, ColdStorageItemListDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<ColdStorageItemListDTO>(data);
            }

            return null;
        }
    }
}
