using System.Collections.Generic;
using Ninjalista.DAL.Entities;

namespace Ninjalista.DAL.Repositories
{
    public interface IRepository
    {
        List<AdvertismentDetails> GetAllPostAds(int subCategory);
        List<SubCategory> GetAllSubCategories();
        List<Category> GetAllCategory();
        void SaveAd(AdvertismentDetails advertisementDetails);
        int GetCategoryId(string category);
        void SaveEmailAddress(string emailAddress);
        int GetSubCategoryId(string SubCategory);
        void AddPicture(string guid);
        List<string> GetSubjects();
        AdvertismentDetails GetAdvertDetails(int id);
    }
}