using System.Collections.Generic;
using Ninjalista.DAL.Entities;

namespace Ninjalista.DAL.Repositories
{
    public interface IRepository
    {
        List<AdvertismentDetails> GetAllPostAds(int subCategory);
        List<SubCategory> GetAllSubCategories();
        List<Category> GetAllCategory();
        List<Category> GetAllActiveCategory();
        void SaveAd(AdvertismentDetails advertisementDetails);
        int GetCategoryId(string category);
        void SaveEmailAddress(string emailAddress);
        int GetSubCategoryId(string SubCategory);
        void AddPicture(string guid);
        List<string> GetSubjects();
        AdvertismentDetails GetAdvertDetails(int id);
        List<SubCategory> GetSubCategoriesByCategoryId(int CategoryId);
        List<SubCategory> GetActiveSubCategoriesByCategoryId(int CategoryId);
        List<Category> GetActiveCatagoryList();
        List<PopularLink> GetActivePopularLinkList();
        List<Page> GetAllActivePages();
        SubCategory GetSubCategorybyId(int SubCategoryId);
        Category GetCategorybyId(int CategoryId);
        List<AdvertismentDetails> GetAllPostAdsByCategory(int category);
        List<AdvertismentDetails> GetSearchResults(string keyword);
        List<SubCategory> GetPopularCategoriesList();
        Page GetPageByName(string TitleLink);
    }
}