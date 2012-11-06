using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaListaAdmin.Web.Views.Models
{
    public class PopularLinkModel
    {
        public List<PopularLink> plinks  { get; set; }
        public PopularLink  plink { get; set; }

        
    }
}