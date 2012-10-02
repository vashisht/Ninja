using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ninjalista.DAL.Entities
{
    public class AdvertismentDetails
    {
   
        public IList<SubCategory> SubCategories { get; set; }
       
        public IList<Category> Categories { get; set; }
        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Location")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please enter Email Address")]
        public string Email { get; set; }

        public int SubCateogryId { get; set; }

        public int CateogryId { get; set; }
        public Guid Guid { get; set; }
        public DateTime PostedDate { get; set; }
        public string DetailsUrl { get; set; }
        public int AdId { get; set; }
        public string Category { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

    }
}