using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjaLista.Models;
using Ninjalista.DAL.Entities;
using Ninjalista.DAL.Repositories;
using NinjaLista.Web.CaptchaServices;
//using System.Web.Mail;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using NinjaListaAdmin.Web.Views.Models;



namespace Ninjalista.Controllers
{
    [HandleError(View="Error")]
    public class HomeController : Controller
    {
        //
        private readonly IRepository _Repository = new Repository();
        private readonly IAdminRepository _adminRepository = new AdminRepository();
        private readonly NinjaLista.Web.CaptchaServices.ICaptchaService captchaService = new DefaultCaptchaService();
        //
        // GET: /Home/
        public HomeController(){}
        public HomeController(IRepository repository, NinjaLista.Web.CaptchaServices.ICaptchaService captchaService,IAdminRepository adminrepository)
        {
            _Repository = repository;
            _adminRepository = adminrepository;
            this.captchaService = captchaService;
        }

        public ActionResult Index()
        {
            
                        
            return View();
        }

        public ActionResult ManageCategories()
        {


            CategoryModel objlist = new CategoryModel();

            objlist.Categories = _adminRepository.GetAllCategory();

            

            return View(objlist);
        }
        public ActionResult ManageSubCategories()
        {


            CategoryModel  objlist = new CategoryModel();

            objlist.Categories   = _adminRepository.GetAllCategory();



            return View(objlist);
        }

        public ActionResult SubcatList()
        {



            SubCategoryModel SubCategoryModel = new SubCategoryModel();


            ViewData["load"] = "0";

            int catId = 1;

            if (Request.QueryString.Keys.Count > 0)
            {
                catId = Convert.ToInt32(Request.QueryString["CateogryId"]);
                ViewData["load"] = "1";

            }


            SubCategoryModel.subcats = _adminRepository.GetSubCategoriesByCategoryId(catId);

            return View(SubCategoryModel);


        }
        public ActionResult NewCategory()
        {
            
            return View();
        }

        public ActionResult SaveCategory(Category Category)
        {
            if (Request.Form["CategoryId"] == "0")
            {

                _adminRepository.AddCategory(Category);
            }

            else
            {
                _adminRepository.UpdateCategory_1 (Category);

            }



            CategoryModel vm = new CategoryModel();
            vm.Categories  = _adminRepository.GetAllCategory ();
            return View("ManageCategories", vm);


        }

        public ActionResult EditCategory(int id)
        {
            CategoryModel vm = new CategoryModel();
            vm.objcategory = _adminRepository.GetCategorybyId(id);
            return View("NewCategory", vm);
        }
        public ActionResult ChangeCategoryStatus(int CategoryId, bool Value)
        {
            var Category = new Category();

            Category = _adminRepository.GetCategorybyId(CategoryId);

            if (Category != null)
            {
                Category.Active = Value;
            }
            _adminRepository.UpdateCategory(Category);
            return Json(new { Message = " Category Status Changed Successfully", Success = true });
        }


        public ActionResult ChangeSubCategoryStatus(int SubCategoryId, bool Value)
        {
            SubCategory SubCategory = new SubCategory();

            SubCategory = _adminRepository.GetSubCategorybyId(SubCategoryId);

            if (SubCategory != null)
            {
                SubCategory.Active = Value;
            }
            _adminRepository.UpdateSubCategory(SubCategory);
            return Json(new { Message = " Sub Category Status Changed Successfully", Success = true });
        }

        public ActionResult ChangeAdStatus(int Adid, bool Value)
        {
            AdvertismentDetails obj = new AdvertismentDetails();

            obj = _adminRepository.GetAdvertDetails(Adid);

            if (obj != null)
            {
                obj.Active = Value;
            }
            _adminRepository.UpdateAddStatus(obj);
            return Json(new { Message = " Advertisment Status Changed Successfully", Success = true });
        }

        public ActionResult ManageAds()
        {
            AdvertListModel objlist = new AdvertListModel();
            objlist.adverts  = _adminRepository.FetchAllPostAds();
            return View(objlist);
        }


        public ActionResult NewSubCategory()
        {
            SubCategoryModel vm = new SubCategoryModel();
            vm.categories = _adminRepository.GetAllCategory();
            

            return View(vm);
        }

        public ActionResult SaveSubCategory(SubCategory subCategory)
        {
            if (Request.Form["SubCategoryId"] == "0")
            {

                _adminRepository.AddSubCategory(subCategory);
            }

            else
            {
                _adminRepository.UpdateSubCategory_1(subCategory);

            }

            CategoryModel objlist = new CategoryModel();

            objlist.Categories = _adminRepository.GetAllCategory();

            
            return View("ManageSubCategories", objlist);


        }

        public ActionResult EditSubCategory(int id)
        {
            SubCategoryModel vm = new SubCategoryModel();
            vm.subcategry  = _adminRepository.GetSubCategorybyId(id);
            vm.categories = _adminRepository.GetAllCategory();
            return View("NewSubCategory", vm);
        }

        //public ActionResult SaveUser(User user)
        //{
        //    if (Request.Form["UserId"] == "0")
        //    {

        //        _adminRepository.AddUser(user);
        //    }

        //    else
        //    {
        //        _adminRepository.UpdateUser(user);

        //    }



        //    UserModel vm = new UserModel();

        //    vm.Users = _adminRepository.getAllusers();
        //    return View("ManageUsers", vm);


        //}

        //public ActionResult ManageUsers()
        //{


        //    UserModel vm = new UserModel();

        //    vm.Users  = _adminRepository.getAllusers();
        //                return View(vm);
        //}

        //public ActionResult ChangeUserStatus(int UserId, bool Value)
        //{
        //    User obj = new User();

        //    obj = _adminRepository.getUserById(UserId);

        //    if (obj != null)
        //    {
        //        obj.Active = Value;
        //    }
        //    _adminRepository.UpdateUserStatus (obj);
        //    return Json(new { Message = " User Status Changed Successfully", Success = true });
        //}

        //public ActionResult EditUser(int id)
        //{
        //    UserModel vm = new UserModel();
        //    vm.User  = _adminRepository.getUserById(id);
        //    return View("NewUser", vm);
        //}
        public JsonResult  LoginUser()
        {
            UserModel vm = new UserModel();
            User obj = new User();
            Session["Username"] = null;
            string username = Request.Form["UserName"];
            string password = Request.Form["Password"];
            obj = _adminRepository.getUserByName(username, password);

            if (obj == null)
            {
                return Json(new { Message = "Invalid User Name or Password ", Success = false });

            }

            else
            {
                if (obj.Userid ==0)
                {
                    return Json(new { Message = "Invalid User Name or Password ", Success = false });

                }

                else if (obj.Active  == false)
                {
                    return Json(new { Message = "User is Inactive.", Success = false });

                }

            }
            Session["Username"] = obj;
            return Json(new { Message = "Login Successfully ", Success = true });
        }
        //public ActionResult NewUser()
        //{
        //    return View();
        //}

        public ActionResult UserLogin()
        {
            return View();
        }

        public ActionResult ManagePopularLinks()
        {


            PopularLinkModel vm = new PopularLinkModel();

            vm.plinks  = _adminRepository.GetAllPopularLinks();



            return View(vm);
        }

        public ActionResult EditPopularLink(int id)
        {
            PopularLinkModel vm = new PopularLinkModel();
            vm.plink  = _adminRepository.GetPopularLinkById(id);
            return View("NewPopularLink", vm);
        }
        public ActionResult NewPopularLink()
        {
            return View();
        }

        public ActionResult ChangeLinkStatus(int LinkId, bool Value)
        {
            PopularLink obj = new PopularLink();

            obj = _adminRepository.GetPopularLinkById(LinkId);

            if (obj != null)
            {
                obj.Active = Value;
            }
            _adminRepository.UpdateLinkStatus(obj);
            return Json(new { Message = " Popular Link Status Changed Successfully", Success = true });
        }

        public ActionResult SavePopularLink(PopularLink  popularlink)
        {
            if (Request.Form["PopularLinkId"] == "0")
            {

                _adminRepository.AddPopularLink(popularlink);
            }

            else
            {
                _adminRepository.UpdatePopularLink(popularlink);

            }

            PopularLinkModel obj = new PopularLinkModel();

            obj.plinks  = _adminRepository.GetAllPopularLinks ();


            return View("ManagePopularLinks", obj);


        }

        //imran saeed

        public ActionResult ManagePages()
        {


            PageModel vm = new PageModel();

            vm.listpage  = _adminRepository.GetAllPages ();



            return View(vm);
        }

        public ActionResult EditPage(int id)
        {
            PageModel vm = new PageModel();
            vm.page  = _adminRepository.GetPageById(id);
            return View("NewPage", vm);
        }
        public ActionResult NewPage()
        {
            return View();
        }

        public ActionResult ChangepageStatus(int pageId, bool Value)
        {
            Page obj = new Page();

            obj = _adminRepository.GetPageById(pageId );

            if (obj != null)
            {
                obj.Active = Value;
            }
            _adminRepository.UpdatePageStatus(obj);
            return Json(new { Message = " Page Status Changed Successfully", Success = true });
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SavePage(Page page)
        {
            if (Request.Form["PageId"] == "0")
            {

                _adminRepository.AddPage(page);
            }

            else
            {
                _adminRepository.UpdatePage (page);

            }

            PageModel obj = new PageModel ();

            obj.listpage  = _adminRepository.GetAllPages ();


            return View("ManagePages", obj);


        }


    }
 }

