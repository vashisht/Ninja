namespace Ninjalista.DAL.Entities
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public bool Active { get; set; }
        public decimal Ordr { get; set; }
    }
}