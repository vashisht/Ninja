using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NinjaLista
{
    public static class UrlExtentions
    {
        const string  UrlDetailsFormat = "/details/{0}/{1}/{2}/{3}";
        const string UrlResultsFormat = "/{0}/{1}/{2}";
        public static string DetailsUrl(this UrlHelper urlHelper,string title,string categoryName,string subcategory,int Id)
        {
            return string.Format(UrlDetailsFormat, categoryName.ToLower().Replace(" ", "-"), subcategory.ToLower().Replace(" ", "-"), urlHelper.Encode(title.ToLower().Replace(" ", "-")), Id);
         
        }

        public static string ResultsUrl(this UrlHelper urlHelper, string category,int id , string page)
        {
            return string.Format(UrlResultsFormat,category.ToLower().Replace(" ","-"),id,page).Replace("/0","").Replace("//","/");

        }

    }
}