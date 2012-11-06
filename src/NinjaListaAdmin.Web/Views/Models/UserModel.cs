using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninjalista.DAL.Entities;

namespace NinjaListaAdmin.Web.Views.Models
{
    public class UserModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
        
        
        
    }
}