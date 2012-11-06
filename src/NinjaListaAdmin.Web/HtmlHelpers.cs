using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using NinjaListaAdmin.Web.Views.Models;
using NinjaLista;

namespace NinjaLista
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, string category)
        {
            var results = new StringBuilder();
           UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
           
           if(pagingInfo.HasPreviousPage)
           {
               TagBuilder tag = new TagBuilder("a");
               tag.MergeAttribute("href", urlHelper.ResultsUrl(category,(pagingInfo.CurrentPage - 1).ToString()));
               tag.InnerHtml = "<<";
               tag.AddCssClass("First");
               results.Append(tag.ToString());

           }
            for (int page = 1; page <= pagingInfo.TotalPages; page++)
            {
                TagBuilder tag = new TagBuilder("a"); //construct an <a> tag
                tag.MergeAttribute("href", urlHelper.ResultsUrl(category,page.ToString()));
                tag.InnerHtml = page.ToString();
                if (page == pagingInfo.CurrentPage)
                    tag.AddCssClass("page larger");
                else
                    tag.AddCssClass("page smaller");
                results.Append((tag.ToString()));
            }

            if (pagingInfo.HasNextPage)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", urlHelper.ResultsUrl(category, (pagingInfo.CurrentPage + 1).ToString()));
                tag.InnerHtml = ">>";
                tag.AddCssClass("Last");
                results.Append(tag.ToString());

            }

            return MvcHtmlString.Create(results.ToString());
        }

        private static string GetResultsPageUrl(string page)
        {
            return string.Format("/{0}", page);
        }
    }
}