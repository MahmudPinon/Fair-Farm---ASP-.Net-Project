using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Admin
{
    public class ManageColdStorageRequestService
    {
        public static List<RequestTableDTO> GetColdStorageRequest()
        {
           /*var requestData = DataAccessFactory.RequestCropData().Get();*/
            var requestData = DataAccessFactory.RequestCropData().Get()
                            .Where(item => item.RequestType == "ColdStorage")
                            .ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTable, RequestTableDTO>();
                cfg.CreateMap<ColdStorageItemList, ColdStorageItemListDTO>();
            });
            var mapper = new Mapper(config);

            var requestList = mapper.Map<List<RequestTableDTO>>(requestData);
            

            foreach (var request in requestList)
            {
                
                    var requestItems = new List<ColdStorageItemListDTO>();

                    var requestItem = DataAccessFactory.ColdStorageRequestItemData().GetItem(request.Id);

                    var data2 = mapper.Map<List<ColdStorageItemListDTO>>(requestItem);

                    requestItems.AddRange(data2);

                    request.ColdStorageRequestItems = requestItems;
                
               
            }

            return requestList;
        }


        public static void UpdateStatusAndAddItemsInColdStorage(int requestId, int coldStorageId)
        {
            var request = DataAccessFactory.RequestCropData().Get(requestId);

            if (request != null && request.RequestType == "ColdStorage")
            {
                request.Status = "Accepted";
                DataAccessFactory.RequestCropData().Update(request);

                var requestItems = DataAccessFactory.ColdStorageRequestItemData().GetItem(requestId);

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ColdStorageItemList, ColdStorageItemListDTO>();
                    cfg.CreateMap<ColdStorageItemListDTO, StoredItemInColdStorage>();
                       
                });


                var mapper = new Mapper(config);

                foreach (var item in requestItems)
                {
                    var coldStorageItemListDTO = mapper.Map<ColdStorageItemListDTO>(item);
                    
                    var adminStoredItem = mapper.Map<StoredItemInColdStorage>(coldStorageItemListDTO);
                    adminStoredItem.ColdStorageId = coldStorageId;
                    var adminStoreData = DataAccessFactory.ColdStorageStoreData().Add(adminStoredItem);
                    var coldStrData = ManageColdStorageService.Get(coldStorageId);
                    coldStrData.Capacity = coldStrData.Capacity - adminStoredItem.CropsQuantity;
                    ManageColdStorageService.Update(coldStrData);
                }
            }
        }




        public static void UpdateStatusAndAdminRejected(int requestId)
        {
            var request = DataAccessFactory.RequestCropData().Get(requestId);

            if (request != null && request.RequestType == "ColdStorage")
            {
                request.Status = "NotAccepted";
                DataAccessFactory.RequestCropData().Update(request);
            }
        }




        public static List<StoredItemInColdStorageDTO> GetAllItem()
        {
            var data = DataAccessFactory.ColdStorageStoreData().Get();
          
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StoredItemInColdStorage, StoredItemInColdStorageDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<StoredItemInColdStorageDTO>>(data);
        }

        public static StoredItemInColdStorageDTO Get(int id)
        {
            var data = DataAccessFactory.ColdStorageStoreData().Get(id);

            if (data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StoredItemInColdStorage, StoredItemInColdStorageDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<StoredItemInColdStorageDTO>(data);
            }

            return null;
        }

        public static bool Delete(int id)
        {
            var coldStrItemData = DataAccessFactory.ColdStorageStoreData().Get(id);

            if (coldStrItemData != null)
            {
                var isDeleted = DataAccessFactory.ColdStorageStoreData().Delete(id);

                return isDeleted;
            }

            return false;
        }
    }
}
