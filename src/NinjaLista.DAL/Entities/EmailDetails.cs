using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Ninjalista.DAL.Entities
{
   public class EmailDetails
    {
       [Required(ErrorMessage = "Name is required")]
       public string Name { get; set; }
       [Required(ErrorMessage = "Email is required")]
       [RegularExpression(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$",ErrorMessage = "Please enter a Valid Email Address")]
       public string EmailAddress { get; set; }      
      
       //public List<string> Subjects { get; set; }
       [Required(ErrorMessage = "Message is required")]
       public string Message { get; set; }
        [Required(ErrorMessage = "Subject is required")]
       public string SelectedSubject { get; set; }
       
       
    }
}
