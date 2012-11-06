namespace Ninjalista.DAL.Entities
{
   public class Page
    {
       public int PageId { get; set; }
       public string Title { get; set; }
       public string Detail { get; set; }
       public string LinkTitle { get; set; }
     

       public bool Active { get; set; }
       
    }
}
