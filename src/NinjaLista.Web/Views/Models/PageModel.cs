using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaLista.Views.Models
{
    public class PageModel
    {        
        public List<Page> pagelist { get; set; }
        public Page page { get; set; }
        
    }
}