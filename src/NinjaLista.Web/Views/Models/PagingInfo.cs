using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaLista.Views.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
        public string SubCurrentCategory { get; set; }
        public string type { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((Decimal)TotalItems / ItemsPerPage); }
        }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage + 1 <= TotalPages);
            }

        }
    }
}