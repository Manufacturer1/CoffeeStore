﻿using CoffeeStore.Filters;
using System.Web;
using System.Web.Mvc;

namespace CoffeeStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        
        }
    }
}
