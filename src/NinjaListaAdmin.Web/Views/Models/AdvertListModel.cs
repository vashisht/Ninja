using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaListaAdmin.Web.Views.Models
{
    public class AdvertListModel
    {
        public List<AdvertismentDetails> adverts { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public List<Category> categories { get; set; }
        public List<SubCategory> subcategories { get; set; }
        public AdvertismentDetails Ad { get; set; }
    }
}