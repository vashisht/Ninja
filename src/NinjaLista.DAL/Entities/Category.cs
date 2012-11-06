using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace Ninjalista.DAL.Entities
{
   public class Category
    {

       public Category()
       {
           subcategoylist = new List<SubCategory>();


       }
       public int CategoryId { get; set; }
       public string CategoryName { get; set; }
       public bool Active { get; set; }
       public decimal Ordr { get; set; }
       public IList<SubCategory> subcategoylist { get; set; }
    }
}
