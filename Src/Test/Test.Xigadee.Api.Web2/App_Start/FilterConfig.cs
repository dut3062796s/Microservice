﻿using System.Web;
using System.Web.Mvc;

namespace Test.Xigadee.Api.Web2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
