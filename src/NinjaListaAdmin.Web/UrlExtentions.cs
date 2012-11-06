using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NinjaLista
{
    public static class UrlExtentions
    {
        const string  UrlDetailsFormat = "/details/{0}/{1}/{2}";
        const string UrlResultsFormat = "/{0}/{1}";
        public static string DetailsUrl(this UrlHelper urlHelper,string title,string categoryName,int Id)
        {
            return string.Format(UrlDetailsFormat, categoryName ,title.ToLower(), Id);
         
        }

        public static string ResultsUrl(this UrlHelper urlHelper, string category , string page)
        {
            return string.Format(UrlResultsFormat,category,page);

        }

    }
}