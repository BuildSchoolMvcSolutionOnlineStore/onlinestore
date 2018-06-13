using StoreData.Models;
using StoreData.Repositories;
using StoreData.ViewModels.Customer;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class OrdersService
    {
        private OrdersRepository ordersRepository = new OrdersRepository();
        private OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository();
        private CartRepository cartRepository = new CartRepository();
        private ProductsRepository productsRepository = new ProductsRepository();
        //訂單列表
        public IEnumerable<AdminOrder> GetOrderList(string Search, ForPaging Paging)
        {
            IEnumerable<AdminOrder> Data;
            if (String.IsNullOrEmpty(Search))
            {
                Data = ordersRepository.GetAll_Admin();
            }
            else
            {
                Data = ordersRepository.SearchById_Admin(Search);
            }

            Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
            Paging.SetRightPage();

            return Data.OrderByDescending(x => x.OrderDate).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }
        //訂單列表 帶狀態
        public IEnumerable<AdminOrder> GetOrderList(string Search, ForPaging Paging, int status)
        {
            IEnumerable<AdminOrder> Data;
            if (String.IsNullOrEmpty(Search))
            {
                Data = ordersRepository.GetAll_Admin().Where(x => x.Status == status);
            }
            else
            {
                Data = ordersRepository.SearchById_Admin(Search).Where(x => x.Status == status);
            }

            Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
            Paging.SetRightPage();

            return Data.OrderByDescending(x => x.OrderDate).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }

        //狀態列表
        //0 未出貨
        //1 已出貨
        //2 已到貨
        //3 已領收
        //4 訂單完成
        //5 客戶帶取消訂單 or 管理者要求取消訂單

        //更新狀態
        public void UpdateStatus(string Id, int status)
        {
            var item = ordersRepository.FindById(Id);
            item.Status = status;
            if (item.Status == 1)
            {
                item.ShippedDate = DateTime.Now;
            }
            ordersRepository.Update(item);
        }

        //判斷是否可以新增訂單
        public string Create(string CustomerId,CreateOrderView model)
        {
            bool IsAllStock = true;
            List<string> NotStockName = new List<string>();

            //取得購物車資料
            var Data = cartRepository.FindById(CustomerId);

            //確認庫存
            foreach (var item in Data)
            {
                var product = productsRepository.FindById(item.ProductID);
                //購買數量大於庫存數量
                if(item.Quantity > product.Stock)
                {
                    IsAllStock = false;
                    NotStockName.Add(product.ProductName);
                }
            }

            if (IsAllStock)
            {
                //新增訂單
                CreateOrder(CustomerId, model);
                //更新產品庫存
                UpdateStock(CustomerId);
                //刪除購物車資料
                DeleteCart(CustomerId);
                return "訂單成立";
            }
            else
            {
                var str = "";
                foreach (var item in NotStockName)
                {
                    str += item +" ";
                }
                return $"{str}庫存不足";
            }
        }
        public void CreateOrder(string CustomerId,CreateOrderView model)
        {
            //產生orderId
            string Id = ordersRepository.GetNewId();
            var split = Id.Split('E');
            string numner = (Convert.ToInt32(split[1]) + 1).ToString();
            while (numner.Length < 3)
            {
                numner = "0" + numner;
            }

            
            var newOrder = new Orders()
            {
                OrderID = "DE" + numner,
                CustomerID = CustomerId,
                OrderDate = DateTime.Now,
                PaymentMethodID = model.PaymentMethodID,
                DeliveryMethodID = model.DeliveryMethodID,
                Status = 0
            };
            //新增訂單
            ordersRepository.Create(newOrder);
            //新增訂單明細
            CreateOrderDetail(newOrder.OrderID, CustomerId);
        }

        //新增訂單明細
        public void CreateOrderDetail(string OrderId, string CustomerId)
        {
            var Data = cartRepository.FindById(CustomerId);
            foreach (var item in Data)
            {
                var newData = new OrderDetails()
                {
                    OrderID = OrderId,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    Discount = 0
                };
                orderDetailsRepository.Create(newData);
            }
        }
        //刪除購物車資料
        public void DeleteCart(string CustomerId)
        {
            cartRepository.DeleteById(CustomerId);
        }
        //更新產品庫存
        public void UpdateStock(string CustomerId)
        {
            var Data = cartRepository.FindById(CustomerId);
            foreach (var item in Data)
            {
                var product = productsRepository.FindById(item.ProductID);
                product.Stock = product.Stock - item.Quantity;
                productsRepository.Update(product);
            }
        }
    }
}