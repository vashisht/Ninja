using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaListaAdmin.Web.Views.Models
{
    public class PageModel
    {
        public List<Page> listpage  { get; set; }
        public Page  page { get; set; }

        
    }
}