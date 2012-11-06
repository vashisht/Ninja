using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaLista.Views.Models
{
    public class CategoryModel
    {        
        public List<Category> catlist { get; set; }
        public List<PopularLink> poplinklist { get; set; }
        public List<SubCategory> subcatlist { get; set; }
        
    }
}