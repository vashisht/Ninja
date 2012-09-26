using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NinjaLista.Models
{
    public class ReplyAdDetails
    {
        [Required(ErrorMessage = "Please enter your Name")]        
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", ErrorMessage = "Please enter a Valid Email Address")]
        public string FromEmail { get; set; }
        public int TelephoneNum { get; set; }
        [Required(ErrorMessage = "Please enter message")]
        public string Message { get; set; }
        public string ToEmailAddress { get; set; }
        public string AdTitle { get; set; }
       
    }
}