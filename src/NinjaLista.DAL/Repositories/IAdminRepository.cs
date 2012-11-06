using System.Collections.Generic;
using Ninjalista.DAL.Entities;

namespace Ninjalista.DAL.Repositories
{
    public interface IAdminRepository
    {
        List<AdvertismentDetails> GetAllPostAds(int subCategory);
        List<AdvertismentDetails> FetchAllPostAds();
        
        List<SubCategory> GetAllSubCategories();
        List<Category> GetAllCategory();
        void SaveAd(AdvertismentDetails advertisementDetails);
        int GetCategoryId(string category);
        void SaveEmailAddress(string emailAddress);
        int GetSubCategoryId(string SubCategory);
        void AddPicture(string guid);
        List<string> GetSubjects();
        AdvertismentDetails GetAdvertDetails(int id);
        List<SubCategory> GetSubCategoriesByCategoryId(int CategoryId);
        Category GetCategorybyId(int CategoryId);
        SubCategory GetSubCategorybyId(int SubCategoryId);
        void UpdateCategory(Category category);
        void UpdateSubCategory(SubCategory subcategory);
        void AddCategory(Category category);
        void UpdateCategory_1(Category category);
        void AddSubCategory(SubCategory subcategory);
        void UpdateSubCategory_1(SubCategory subcategory);

        void UpdateAddStatus(AdvertismentDetails advertismentdetails);

        void AddUser(User user);
        void UpdateUser(User user);
        User getUserByName (string UserName, string Password);
        User getUserById(int userid);
        List<User> getAllusers();
        void UpdateUserStatus(User user);


        void AddPopularLink(PopularLink  popularlink);
        void UpdatePopularLink(PopularLink popularlink);

        PopularLink GetPopularLinkById(int userid);
        List<PopularLink> GetAllPopularLinks();
        void UpdateLinkStatus(PopularLink popularlink);


        void AddPage(Page page);
        void UpdatePage(Page page);

        Page GetPageById(int pageid);
        List<Page> GetAllPages();
        void UpdatePageStatus(Page page);

    }
}