﻿using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
