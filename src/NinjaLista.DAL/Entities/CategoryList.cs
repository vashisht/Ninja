using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ninjalista.DAL.Entities
{
    public class CategoryList
    {
   
        public IList<Category> Categories { get; set; }
        public int CateogryId { get; set; }
       
    }
}