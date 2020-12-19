using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Helper
{
    public static class ActiveMenu
    {
        public static HtmlString IsActive(this IHtmlHelper helper, string area, string action)
        {
            ViewContext context = helper.ViewContext;

            RouteValueDictionary values = context.RouteData.Values;

            string _area = "";
            if (values["area"] != null)
            {
                _area = values["area"].ToString();
            }
            else
            {
                _area = values["controller"].ToString();
            }

            string _action = "";
            if (values["action"] != null)
            {
                _action = values["action"].ToString();
            }
            else
            {
                _action = values["page"].ToString();
            }

            if ((action == _action) && (area == _area))
            {
                return new HtmlString("active") ;
            }
            else
            {
                return new HtmlString("");
            }
        }
        public static HtmlString IsMainActive(this IHtmlHelper helper, string area)
        {
            ViewContext context = helper.ViewContext;

            RouteValueDictionary values = context.RouteData.Values;
            string _area = "";
            if (values["area"] != null)
            {
                _area = values["area"].ToString();
            }
            else
            {
                _area = values["controller"].ToString();
            }
            
          

            if (area == _area)
            {
                return new HtmlString("nav-active");
            }
            else
            {
                return new HtmlString("");
            }
        }
    }
}
