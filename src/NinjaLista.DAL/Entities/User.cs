namespace Ninjalista.DAL.Entities
{
   public class User
    {
       public int Userid { get; set; }
       public string UserName { get; set; }
       public string Password { get; set; }

       public string FirstName { get; set; }
       public string LastName { get; set; }

       public bool Active { get; set; }
       
    }
}
