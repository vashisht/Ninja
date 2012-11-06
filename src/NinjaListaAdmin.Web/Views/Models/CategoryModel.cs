using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaListaAdmin.Web.Views.Models
{
    public class CategoryModel
    {
        public List<Category> Categories { get; set; }
        public Category objcategory { get; set; }

        public int CateogryId { get; set; }
    }
}