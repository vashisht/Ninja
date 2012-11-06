using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaListaAdmin.Web.Views.Models
{
    public class SubCategoryModel
    {
        public List<SubCategory> subcats { get; set; }
        public List<Category> categories { get; set; }
        public SubCategory subcategry { get; set; }
        
        
    }
}