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
    public class ManageBuySellRequestService
    {

        public static List<RequestTableDTO> Get()
        {
            var requestData = DataAccessFactory.RequestCropData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTable, RequestTableDTO>();
                cfg.CreateMap<RequestTableItem, RequestTableItemDTO>();
            });
            var mapper = new Mapper(config);

            var requestList = mapper.Map<List<RequestTableDTO>>(requestData);

            foreach (var request in requestList)
            {
                var requestItems = new List<RequestTableItemDTO>(); 

                var requestItem = DataAccessFactory.RequestTableItemData().GetItem(request.Id); 

                var data2 = mapper.Map<List<RequestTableItemDTO>>(requestItem);
                requestItems.AddRange(data2);

                request.RequestItems = requestItems; 
            }

            return requestList;
        }


        public static void AddRequestAndItems(RequestTableDTO requestDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestTableDTO, RequestTable>();
                cfg.CreateMap<RequestTableItemDTO, RequestTableItem>();
            });
            var mapper = new Mapper(config);

            var requestEntity = mapper.Map<RequestTable>(requestDto);

            var addedRequest = DataAccessFactory.RequestCropData().Add(requestEntity);

            var requestItems = requestDto.RequestItems.Select(itemDto => mapper.Map<RequestTableItem>(itemDto)).ToList();
            foreach (var requestItem in requestItems)
            {
                requestItem.RequestId = addedRequest.Id;
                DataAccessFactory.RequestTableItemData().Add(requestItem);

            }
        }


        public static void UpdateStatusAndAddItems(int requestId)
        {
            var request = DataAccessFactory.RequestCropData().Get(requestId);

            if (request != null && request.RequestType == "Sell")
            {

                request.Status = "Accepted"; 
                DataAccessFactory.RequestCropData().Update(request);

                var requestItems = DataAccessFactory.RequestTableItemData().GetItem(requestId);

                var config = new MapperConfiguration(cfg => cfg.CreateMap<RequestTableItem, AdminStoredItem>());
                var mapper = new Mapper(config);

                foreach (var item in requestItems)
                {
                    var adminStoredItem = mapper.Map<AdminStoredItem>(item);
                    adminStoredItem.StorageRequestId = requestId;

                    var adminStoreData = DataAccessFactory.AdminStoredItemData().Add(adminStoredItem); 

                    RegularPriceUpdate RegPriceItem = new RegularPriceUpdate();

                    RegPriceItem.Id=adminStoreData.Id;
                    RegPriceItem.CropName = adminStoreData.CropsName;
                    RegPriceItem.CropQuantity = adminStoreData.CropsQuantity;
                    RegPriceItem.Price = (((adminStoreData.Price / adminStoreData.CropsQuantity) + 10) * adminStoreData.CropsQuantity);
                    RegPriceItem.Description = adminStoreData.Description;
                    RegPriceItem.AdminStoredItemId = adminStoreData.StorageRequestId;
                    DataAccessFactory.RegularPriceData().Add(RegPriceItem);
                }
            }
        }



        public static void UpdateStatusAndSendToTrader(int requestId)
        {
            var request = DataAccessFactory.RequestCropData().Get(requestId);

            if (request != null && request.RequestType == "Sell") 
            {
                request.Status = "Refere"; 
                DataAccessFactory.RequestCropData().Update(request);

                var requestItems = DataAccessFactory.RequestTableItemData().GetItem(requestId);

                var config = new MapperConfiguration(cfg => cfg.CreateMap<RequestTableItem, BuySellRequestBetweenFarmerAndTrader>());
                var mapper = new Mapper(config);

                foreach (var item in requestItems)
                {
                    var buySellRequestItem = mapper.Map<BuySellRequestBetweenFarmerAndTrader>(item);
                    buySellRequestItem.RequestId = requestId;
                    buySellRequestItem.Userid = request.UserId;
                    buySellRequestItem.RequestType = request.RequestType;
                    buySellRequestItem.Status = request.Status;

                    DataAccessFactory.BuySellRequestBetweenFarmerAndTraderData().Add(buySellRequestItem);
                }
            }
        }

        /*Admin will sell to trader start*/
        public static void UpdateStatusAndSellItems(int requestId)
        {
            var request = DataAccessFactory.RequestCropData().Get(requestId);

            if (request != null && request.RequestType == "Buy")
            {
                request.Status = "Sold";
                DataAccessFactory.RequestCropData().Update(request);

                var requestItems = DataAccessFactory.RequestTableItemData().GetItem(requestId);

                foreach (var item in requestItems)
                {

                    DeductSoldQuantityFromRegularPrice(item.CropsName, item.CropsQuantity);
                }
            }
        }

        private static void DeductSoldQuantityFromRegularPrice(string cropName, string soldQuantityStr)
        {
            if (int.TryParse(soldQuantityStr, out int soldQuantity))
            {
               
                var regularPriceItem = DataAccessFactory.RegularPriceNameData().Get(cropName);

                if (regularPriceItem != null)
                {
                    decimal oldCropQuantity = regularPriceItem.CropQuantity;


                    regularPriceItem.CropQuantity -= soldQuantity;
                    regularPriceItem.Price = (((regularPriceItem.Price / oldCropQuantity)) * regularPriceItem.CropQuantity);

                    DataAccessFactory.RegularPriceData().Update(regularPriceItem);
                }
              
                else
                {
                  
                }
            }
            else
            {
                
            }
        }
        /*Admin will sell to trader end*/

        public static void UpdateStatusAndSendToFarmer(int requestId)
        {
            var request = DataAccessFactory.RequestCropData().Get(requestId);

            if (request != null && request.RequestType == "Buy")
            {
                request.Status = "NotSellRefere";
                DataAccessFactory.RequestCropData().Update(request);

                var requestItems = DataAccessFactory.RequestTableItemData().GetItem(requestId);

                var config = new MapperConfiguration(cfg => cfg.CreateMap<RequestTableItem, BuySellRequestBetweenFarmerAndTrader>());
                var mapper = new Mapper(config);

                foreach (var item in requestItems)
                {
                    var buySellRequestItem = mapper.Map<BuySellRequestBetweenFarmerAndTrader>(item);
                    buySellRequestItem.RequestId = requestId;
                    buySellRequestItem.Userid = request.UserId;
                    buySellRequestItem.RequestType = request.RequestType;
                    buySellRequestItem.Status = request.Status;

                    DataAccessFactory.BuySellRequestBetweenFarmerAndTraderData().Add(buySellRequestItem);
                }
            }
        }




    }
}
