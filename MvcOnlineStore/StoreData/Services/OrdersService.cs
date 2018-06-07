using StoreData.Models;
using StoreData.Repositories;
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
        public IEnumerable<AdminOrder> GetOrderList(string Search, ForPaging Paging,int status)
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
        public void UpdateStatus(string Id,int status)
        {
            var item = ordersRepository.FindById(Id);
            item.Status = status;
            if(item.Status == 1)
            {
                item.ShippedDate = DateTime.Now;
            }
            ordersRepository.Update(item);
        }
    }
}