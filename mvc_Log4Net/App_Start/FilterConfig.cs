﻿using System.Web;
using System.Web.Mvc;

namespace mvc_Log4Net2NLog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
