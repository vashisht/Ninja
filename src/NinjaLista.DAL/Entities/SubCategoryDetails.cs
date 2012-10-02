using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ninjalista.DAL.Entities
{
    public class SubCategoryDetails
    {
   
        public IList<SubCategory> SubCategories { get; set; }
        public int SubCateogryId { get; set; }
       
    }
}