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
using NinjaLista.Views.Models;


namespace Ninjalista.Controllers
{
    [HandleError(View="Error")]
    public class HomeController : Controller
    {
        //
        private readonly IRepository _Repository = new Repository();
        private readonly NinjaLista.Web.CaptchaServices.ICaptchaService captchaService = new DefaultCaptchaService();
        //
        // GET: /Home/
        public HomeController(){}
        public HomeController(IRepository repository, NinjaLista.Web.CaptchaServices.ICaptchaService captchaService)
        {
            _Repository = repository;
            this.captchaService = captchaService;
        }

        public ActionResult Index()
        {

            CategoryModel vm = new CategoryModel();
            vm.catlist = _Repository.GetActiveCatagoryList();
            vm.poplinklist = _Repository.GetActivePopularLinkList();

           
            return View(vm);
        }


        public ActionResult Linksuteisemlondres()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contato()
        {
            PopulateSubjects();
            return View();

        }
        [HttpPost]
        public ActionResult Contato(EmailDetails emailDetails)
        {
            if (!ModelState.IsValid)
            {
                PopulateSubjects();
                return View();
            }

            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From =   emailDetails.EmailAddress;
            //mailMessage.To = "admin@ninjalista.com";
            //mailMessage.Subject = emailDetails.SelectedSubject;
            //mailMessage.Body =emailDetails.Message;
            //SendEmail(mailMessage);

            MailMessage message = new MailMessage();
            message.To.Add(emailDetails.EmailAddress );
            message.IsBodyHtml = true;
            message.Subject = emailDetails.SelectedSubject;
            message.Body = emailDetails.Message;
            System.Net.Mail.SmtpClient smtp = new SmtpClient();
            smtp.Send(message);


            return RedirectToAction("Index");
            
           
        }
        private void PopulateSubjects()
        {
            var subjects = new List<string>();
            subjects = _Repository.GetSubjects();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var sub in subjects)
            {
                list.Add(new SelectListItem { Value = sub, Text = sub });
            }
            ViewData["Subjects"] = list;
        }

        [HttpGet]
        public ActionResult ReplyAd(int id)
        {
            ReplyAdDetails replyad = new ReplyAdDetails();
            
           var adDetails = _Repository.GetAdvertDetails(id);
            replyad.ToEmailAddress = adDetails.Email;
             replyad.AdTitle = adDetails.Title;
            replyad.Category = adDetails.Category;
            replyad.SubCategory = adDetails.SubCategory;
            replyad.CategoryId = adDetails.CateogryId;
            replyad.SubCategoryId = adDetails.SubCateogryId;
           replyad.AdId = id;
            return View(replyad);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ReplyAd(ReplyAdDetails replyDetails)
        {
            if (ModelState.IsValid)
            {
                var adDetails = _Repository.GetAdvertDetails(replyDetails.AdId);
                var subject = string.Format("{0} {1}", "Resposta ao seu anúncio: ", replyDetails.AdTitle);
                //var adDetails = _Repository.GetAdvertDetails(replyDetails.AdId);
                ////MailMessage mailMessage = new MailMessage();
                ////mailMessage.From = replyDetails.FromEmail;
                ////mailMessage.To = replyDetails.ToEmailAddress;
                ////mailMessage.Subject = replyDetails.AdTitle;
                ////mailMessage.Body = replyDetails.Message;
                ////SendEmail(mailMessage);



                string msg = "Você recebeu uma resposta ao seu anúncio, veja os detalhes abaixo:<br/><br/>";
                msg += "mensagem de: " + HtmlRemoval.StripTagsCharArray(replyDetails.Name) + "<br/>";
                msg += "email para contato: " + replyDetails.FromEmail + "<br/>";
                msg += "Número de telefone: " + replyDetails.TelephoneNum + "<br/>";
                msg += "Mensagem: " + HtmlRemoval.StripTagsCharArray(replyDetails.Message) + "<br/>";
                MailMessage message = new MailMessage();
                message.To.Add(adDetails.Email);
                message.IsBodyHtml = true;
                message.Subject = subject;//replyDetails.AdTitle;
                message.Body = msg;
                System.Net.Mail.SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
                TempData["Title"] = "Sua mensagem foi enviada com sucesso!";
                TempData["Body"] = "Parabéns, sua mensagem foi enviada com sucesso!";
                TempData["Body1"] = "";
                return RedirectToAction("Confirmation", "Home");
            }
            return View(replyDetails);
            
        }

       public void SendEmail(MailMessage msg)
        {
           var host = ConfigurationManager.AppSettings["host"];
           

           //SmtpMail.SmtpServer = host;
       
           //SmtpMail.Send(msg);
           
        }
       
        public ActionResult Details(string category, string title,int Id)
        {
            var details = new AdvertismentDetails();
            details = _Repository.GetAdvertDetails(Id);
            if (details.AdId != 0)
            {
                details.Category = category;
                details.AdId = Id;
                details.link = (Request.UrlReferrer == null) ? "" : Request.UrlReferrer.AbsoluteUri;
                return View(details);    
            }
            else
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            
        }

        public ActionResult Confirmation()
        {
            return View("Confirmation");
        }
      

        public ActionResult Partners(EmailDetails emailDetails)
        {

            return View();
        }


        [HttpGet]
        public ViewResult PostAd()
        {
            try
            {
                var advertisementDetails = new AdvertismentDetails();
                advertisementDetails.Guid = Guid.NewGuid();
               // advertisementDetails.SubCategories = _Repository.GetAllSubCategories();
                advertisementDetails.Categories = _Repository.GetAllActiveCategory();
                return View(advertisementDetails);
            }
            catch (Exception ex)
            {
                
                return View();
            }
            
            //return View();
        }


        public ActionResult SubCategoryDropdown()
        {



            var subcategorydetail = new SubCategoryDetails();


            Dictionary<string, object> uf = new Dictionary<string, object>();

            int catId = 1;

                if (Request.QueryString.Keys.Count > 0)
                {
                     catId = Convert.ToInt32(Request.QueryString["CateogryId"]);
                                    
                }


                subcategorydetail.SubCategories = _Repository.GetActiveSubCategoriesByCategoryId(catId);

                return View(subcategorydetail);
            
          
        }


        [HttpPost]
        public JsonResult UploadImage(string qqFile)
        {

            var path = HttpContext.Server.MapPath("../public");
            var file = string.Empty;

            try
            {
                var stream = Request.InputStream;
                if (String.IsNullOrEmpty(Request["qqfile"]))
                {
                    // IE
                    HttpPostedFileBase postedFile = Request.Files[0];
                    stream = postedFile.InputStream;
                    file = Path.Combine(path, System.IO.Path.GetFileName(Request.Files[0].FileName));
                }
                else
                {
                    //Webkit, Mozilla
                    file = Path.Combine(path, qqFile);
                }

                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                System.IO.File.WriteAllBytes(file, buffer);
                new ImageResizer().Resize(stream, file, "117");
                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, "application/json");
            }

            return Json(new { success = true }, "text/html");




//
//          string folderName = Guid.NewGuid().ToString();
//            string folderPath = HttpContext.Server.MapPath("../public") + "\\" + folderName;
//
//            Directory.CreateDirectory(folderPath);
//            Directory.CreateDirectory(folderPath + "\\thumb");
//
//            if (fileData.ContentLength > 0)
//            {
//                               string filePath = Path.Combine(folderPath,
//                                               Path.GetFileName(fileData.FileName));
//                fileData.SaveAs(filePath);
//
//
//
//                _Repository.AddPicture(folderName);
//
//
//                string outputFileName = folderPath + "\\thumb\\"+ fileData.FileName;
//                new ImageResizer().Resize(fileData.InputStream, outputFileName, "117");
//            }
//            return Json(new {Upload=folderName});
        }

        [HttpPost]  
        [ValidateInput(false)]
        public ActionResult PostAd(AdvertismentDetails advertisementDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    advertisementDetails.PostedDate = DateTime.Now;
                    var relPath = ConfigurationManager.AppSettings["DirAddImages"]; 
                    //"/Content/AdImages";

                    string guidstring = Guid.NewGuid().ToString();

                    string directory = Server.MapPath(relPath);
                    string filePath = System.IO.Path.Combine(directory, guidstring + "_1" + ".");
                    advertisementDetails.Image3 = "";
                    advertisementDetails.Image2 = "";
                    advertisementDetails.Image1 = "";
                    HttpPostedFileBase file = Request.Files["Image1"];

                    string filename = "";
                    if (file != null && file.ContentLength > 0)
                    {

                        filename = file.FileName;

                        string[] strfile = filename.Split(".".ToCharArray());

                        int a = strfile.Length;

                        filePath = filePath + strfile[a - 1];

                        if (System.IO.Directory.Exists(directory))
                        {
                            file.SaveAs(filePath);

                            advertisementDetails.Image1 =  "/" + System.IO.Path.GetFileName(filePath);
                        }

                        
                    }

                    filePath = System.IO.Path.Combine(directory, guidstring + "_2" + ".");

                     file = Request.Files["Image2"];

                     filename = "";
                    if (file != null && file.ContentLength > 0)
                    {

                        filename = file.FileName;

                        string[] strfile = filename.Split(".".ToCharArray());

                        int a = strfile.Length;

                        filePath = filePath + strfile[a - 1];

                        if (System.IO.Directory.Exists(directory))
                        {
                            file.SaveAs(filePath);

                            advertisementDetails.Image2 =  "/" + System.IO.Path.GetFileName(filePath);
                        }


                    }


                    filePath = System.IO.Path.Combine(directory, guidstring + "_3" + ".");

                    file = Request.Files["Image3"];

                    filename = "";
                    if (file != null && file.ContentLength > 0)
                    {

                        filename = file.FileName;

                        string[] strfile = filename.Split(".".ToCharArray());

                        int a = strfile.Length;

                        filePath = filePath + strfile[a - 1];

                        if (System.IO.Directory.Exists(directory))
                        {
                            file.SaveAs(filePath);

                            advertisementDetails.Image3 = "/" + System.IO.Path.GetFileName(filePath);
                        }


                    }
                    advertisementDetails.Title = HtmlRemoval.StripTagsCharArray(advertisementDetails.Title);
                    advertisementDetails.Description = HtmlRemoval.StripTagsCharArray(advertisementDetails.Description);
                    advertisementDetails.Location = HtmlRemoval.StripTagsCharArray(advertisementDetails.Location);

                    _Repository.SaveAd(advertisementDetails);
                    //send an Email to admin
                    if (Boolean.Parse(ConfigurationManager.AppSettings["SendEmail"]))
                    {
                        //var mailMessage = new MailMessage();
                        //mailMessage.To =  advertisementDetails.Email;
                        //mailMessage.From = ConfigurationManager.AppSettings["FromEmail"];
                        //mailMessage.Subject=   advertisementDetails.Title;
                        //mailMessage.Body =    advertisementDetails.Description;
                        //SendEmail(mailMessage);    
                        AdvertismentDetails ad = _Repository.GetAdvertDetails(advertisementDetails.AdId);
                        //http://beta.ninjalista.co.uk/details/Ag%C3%AAncias%20de%20viagem/agencias+de+viagem+teste+01/4
                        string link = "<a href='http://beta.ninjalista.co.uk/details/" + ad.Category.ToLower().Replace(" ", "-") + "/" + ad.SubCategory.ToLower().Replace(" ", "-") + "/" + ad.Title.ToLower().Replace(" ", "-") + "/" + advertisementDetails.AdId + "'>" +
                            "http://beta.ninjalista.co.uk/details/" + ad.Category + "/" + ad.SubCategory + "/" + advertisementDetails.Title + "/" + advertisementDetails.AdId + "</a>";
                        MailMessage message = new MailMessage();
                        message.To.Add(advertisementDetails.Email);
                        message.IsBodyHtml = true;
                        message.Subject = "Anúncio postado: " + advertisementDetails.Title;
                        message.Body = "Parabéns, o seu anúncio foi postado com sucesso, para visualiza-lo click no link abaixo: <br/>"
                            + link + ".  <br/><br/> Obrigado por usar o <a href='http://www.ninjalista.com'>Ninjalista.com</a>"; 
                            //+ advertisementDetails.Description;
                        System.Net.Mail.SmtpClient smtp = new SmtpClient();
                        smtp.Send(message);
                    }
                    TempData["Title"] = "Anúncio postado!";
                    TempData["Body"] = "Parabéns, o seu anúncio foi postado!";
                    TempData["Body1"] = "<p>Um email de confirmação foi enviado para o seu email fornecido, e seu anúncio estara disponível em nosso site dentro de alguns minutos.</p>";
                    return RedirectToAction("Confirmation", "Home");
                }

                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return View("Index");
                }
            }            
            advertisementDetails.SubCategories = _Repository.GetAllSubCategories();
            advertisementDetails.Categories = _Repository.GetAllCategory();
            return View(advertisementDetails);
            
        }


        public ActionResult AdResults(string categoryName,string subcategory,int Id, int page = 1)
        {
            //int id = 0;
            int pageSize = 10;

            //id = _Repository.GetCategoryId(categoryName);
            //if (id == 0)
            SubCategory sc = _Repository.GetSubCategorybyId(Id);
           var advertList = new NinjaLista.Views.Models.AdvertListModel();
           advertList.subcatlist = _Repository.GetPopularCategoriesList();
           advertList.Id = sc.CategoryId;
           //advertList.type = "";
           var adverts = _Repository.GetAllPostAds(Id);
            var advertsTotalCount = adverts.Count;
            advertList.adverts = (adverts).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            advertList.CurrentCategory = sc.SubCategoryName;
            advertList.PagingInfo = new NinjaLista.Views.Models.PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = advertsTotalCount,
                CurrentCategory = sc.CategoryName,
                SubCurrentCategory = sc.SubCategoryName,
                type = ""// categoryName
            };
            return View(advertList);
        }

        public ActionResult AdResultsByCategory(string categoryName, int Id, int page = 1)
        {
            //int id = 0;
            int pageSize = 10;

            //id = _Repository.GetCategoryId(categoryName);
            //if (id == 0)
            Category c = _Repository.GetCategorybyId(Id);
            var advertList = new NinjaLista.Views.Models.AdvertListModel();
            advertList.subcatlist = _Repository.GetPopularCategoriesList();
            advertList.Id = c.CategoryId;
            //advertList.type = "cat";
            var adverts = _Repository.GetAllPostAdsByCategory(Id);
            var advertsTotalCount = adverts.Count;
            advertList.adverts = (adverts).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            advertList.CurrentCategory = c.CategoryName;
            advertList.PagingInfo = new NinjaLista.Views.Models.PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = advertsTotalCount,
                CurrentCategory = c.CategoryName,
                SubCurrentCategory = "",
                type = "cat"
            };
            return View("AdResults",advertList);
        }

        public ActionResult termsAndConditions()
        {
            return View();
        }

       public ActionResult policypage()
        {
            PageModel vm = new PageModel();
            vm.page = _Repository.GetPageByName("policypage");

            return View(vm);
        }

       public ActionResult Page(string page)
       {
           PageModel vm = new PageModel();
           vm.page = _Repository.GetPageByName(page);

           return View(vm);
       }
       public ActionResult PreviewAd(AdvertismentDetails AdDetails)
       {
           return View();
       }


        public ActionResult Captcha()
        {
            string captchaString = captchaService.GenerateRandomString();

            Bitmap c = captchaService.GetCaptcha(captchaString, 200, 100);

            System.IO.MemoryStream imageStream = new System.IO.MemoryStream();
            c.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            Session["CaptchaString"] = captchaString;

            return new FileContentResult(imageStream.ToArray(), "image/jpg");
        }

        public ActionResult ValidateCaptcha(string captchaString)
        {
            if (string.IsNullOrEmpty(captchaString))
            {
                return Json(false);
            }
            if (("" + Session["CaptchaString"]).ToLower() != captchaString.ToLower())
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        public ActionResult SearchResults(string keyword, int page = 1)
        {


            //AdvertListModel vm = new AdvertListModel();
            

            //int id = 0;
            int pageSize = 10;
            keyword = keyword.Replace("_$_","").Replace("-"," ");
            //id = _Repository.GetCategoryId(categoryName);
            //if (id == 0)
            //SubCategory sc = _Repository.GetSubCategorybyId(Id);
            var advertList = new NinjaLista.Views.Models.AdvertListModel();
            advertList.subcatlist = _Repository.GetPopularCategoriesList();
            //advertList.Id = sc.CategoryId;
            //advertList.type = "";
            var adverts = _Repository.GetSearchResults(keyword);
            var advertsTotalCount = adverts.Count;
            TempData["keyword"] = keyword   ;
            advertList.adverts = (adverts).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            //advertList.CurrentCategory = sc.SubCategoryName;
            advertList.PagingInfo = new NinjaLista.Views.Models.PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = advertsTotalCount,
                CurrentCategory = keyword == "" ?"_$_":keyword,//"search",
                //SubCurrentCategory = keyword,
                type = "search"// categoryName
            };
            return View(advertList);
        }

        public ActionResult SignupNewsLetter(string email)
        {
            _Repository.SaveEmailAddress(email);
            TempData["Title"] = "Thank you for Signup";
            TempData["Body"] = "Parabéns, sua mensagem foi enviada com sucesso!";
            TempData["Body1"] = "";
            return RedirectToAction("Confirmation", "Home");
        }
    }
 }

