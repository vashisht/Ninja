using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaLista.Views.Models
{
    public class AdvertListModel
    {
        public List<AdvertismentDetails> adverts { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int Id { get; set; }
        //public string type { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentSubCategory { get; set; }
        public List<SubCategory> subcatlist { get; set; }
    }
}