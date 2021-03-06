﻿using StoreData.Models;
using StoreData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Home
{
    public class HomeIndexTop
    {
        public IEnumerable<ProductsItem> ProductsList { get; set; }
        public IEnumerable<ProductsItem> MidProductsList { get; set; }
        public IEnumerable<ProductsItem> DownProductsList { get; set; }
        public IEnumerable<ProductsItem> GetAllProductsList { get; set; }
        public IEnumerable<Categories> GetAllCategories { get; set; }
        public ForPaging Paging { get; set; }
        public string Search { get; set; }
    }
}