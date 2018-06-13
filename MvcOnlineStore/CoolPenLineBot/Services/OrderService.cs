using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Repositories;
using StoreData.ViewModels.Manager;

namespace CoolPenLineBot.Services
{
    public class OrderService
    {
        private OrdersRepository repository = new OrdersRepository();
        public string SearchOrder(string orderId)
        {
            IEnumerable<AdminOrder> data = repository.SearchById_Admin(orderId);
            if (data.Count() == 1)
            {
                var item = data.FirstOrDefault();
                string shipping = (item.ShippedDate == null) ? "尚未出貨" : item.ShippedDate.ToString();
                string status="";
                if (item.Status == 0)
                {
                    status = "未出貨";
                }
                else if (item.Status == 1)
                {
                    status = "已出貨";

                }
                else if (item.Status == 2)
                {
                    status = "已到貨";
                }
                else if (item.Status == 3)
                {
                    status = "已完成";
                }
                else if (item.Status == 4)
                {
                    status = "要求取消訂單";
                }
                var str = $"訂單ID: {item.OrderId}\n" +
                    $"訂單時間: {item.OrderDate }\n" +
                    $"出貨時間: {shipping}\n" +
                    $"付款方式: {item.PaymentMethod}\n" +
                    $"運送方式: {item.DeliveryMethod}\n" +
                    $"總金額: ${item.Amount}\n" +
                    $"狀態: {status}";
                return str;
            }
            else
            {
                return "很抱歉沒有搜尋到有關於您的訂單\n請確認是否有輸入錯誤";
            }
        }
    }
}