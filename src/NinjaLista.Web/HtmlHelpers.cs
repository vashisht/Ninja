using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using NinjaLista.Views.Models;
using NinjaLista;

namespace NinjaLista
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo,int Id, string category)
        {
            var results = new StringBuilder();
           UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
           
           if(pagingInfo.HasPreviousPage)
           {
               TagBuilder tag = new TagBuilder("a");
               tag.MergeAttribute("href", urlHelper.ResultsUrl((pagingInfo.type != "" ? pagingInfo.type + "/" : pagingInfo.CurrentCategory + "/") + category,Id,(pagingInfo.CurrentPage - 1).ToString()));
               tag.InnerHtml = "<<";
               tag.AddCssClass("First");
               results.Append(tag.ToString());

           }
            for (int page = 1; page <= pagingInfo.TotalPages; page++)
            {
                TagBuilder tag = new TagBuilder("a"); //construct an <a> tag

                tag.MergeAttribute("href", urlHelper.ResultsUrl((pagingInfo.type != "" ? pagingInfo.type + "/" : pagingInfo.CurrentCategory + "/") + category, Id, page.ToString()));
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
                tag.MergeAttribute("href", urlHelper.ResultsUrl((pagingInfo.type != "" ? pagingInfo.type + "/" : pagingInfo.CurrentCategory + "/") + category, Id, (pagingInfo.CurrentPage + 1).ToString()));
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