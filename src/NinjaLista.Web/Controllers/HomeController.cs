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
using System.Web.Mail;
using System.Configuration;


namespace Ninjalista.Controllers
{
    [HandleError(View="Error")]
    public class HomeController : Controller
    {
        //
        private readonly IRepository _Repository = new Repository();
        //
        // GET: /Home/
        public HomeController(){}
        public HomeController(IRepository repository)
        {
            _Repository = repository;
        }

        public ActionResult Index()
        {
                        
            return View();
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
           
                var mailmessage = new MailMessage();
                mailmessage.From = emailDetails.EmailAddress;
                mailmessage.To = "admin@ninjalista.com";
                mailmessage.Subject = emailDetails.SelectedSubject;
                mailmessage.Body = emailDetails.Message;
                SmtpMail.SmtpServer = "auth.smtp.1and1.co.uk";
                SmtpMail.Send(mailmessage);
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
            replyad.ToEmailAddress = "admin@ninjalista.com";
            var adDetails = _Repository.GetAdvertDetails(id);
            replyad.AdTitle = adDetails.Title;
            replyad.Category = adDetails.Category;
            replyad.AdId = adDetails.AdId;
            return View(replyad);
        }

        [HttpPost]
        public ActionResult ReplyAd(ReplyAdDetails replyDetails)
        {
            if (!ModelState.IsValid)
                return View();
            var mailmessage = new MailMessage();
            mailmessage.From = replyDetails.FromEmail;
            mailmessage.To = replyDetails.ToEmailAddress;
            mailmessage.Subject = "Message for your Ad";
            mailmessage.Body = replyDetails.Message;
            SmtpMail.SmtpServer = "auth.smtp.1and1.co.uk";
            SmtpMail.Send(mailmessage);
            return RedirectToAction("Confirmation");
        }
       
        public ActionResult Details(string category, string title,int Id)
        {
            var details = new AdvertismentDetails();
            details = _Repository.GetAdvertDetails(Id);
            details.Category = category;
            return View(details);
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
            var advertisementDetails = new AdvertismentDetails();
            advertisementDetails.Guid = Guid.NewGuid();
            advertisementDetails.SubCategories = _Repository.GetAllSubCategories();
            advertisementDetails.Categories = _Repository.GetAllCategory();
            return View(advertisementDetails);
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
        public ActionResult PostAd(AdvertismentDetails advertisementDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _Repository.SaveAd(advertisementDetails);
                    //send an Email to admin
                    if (Boolean.Parse(ConfigurationManager.AppSettings["SendEmail"]))
                    {
                        var mailmessage = new MailMessage();
                        mailmessage.From = ConfigurationManager.AppSettings["AdminEmailAddress"];
                        mailmessage.To = ConfigurationManager.AppSettings["AdminEmailAddress"];
                        mailmessage.Subject = "New Advertisement Created";
                        mailmessage.Body = string.Format("{0} {1}", ConfigurationManager.AppSettings["NewAdvertCreatedMsg"], DateTime.Now.Date);
                        SmtpMail.SmtpServer = "auth.smtp.1and1.co.uk";
                        SmtpMail.Send(mailmessage);
                    }
                    return RedirectToAction("Confirmation", "Home");
                }

                catch (Exception ex)
                {
                    return View("Index");
                }
            }            
            advertisementDetails.SubCategories = _Repository.GetAllSubCategories();
            advertisementDetails.Categories = _Repository.GetAllCategory();
            return View(advertisementDetails);
            
        }


        public ActionResult AdResults(string categoryName, int page = 1)
        {
            int id = 0;
            int pageSize = 1;

            id = _Repository.GetCategoryId(categoryName);
            if (id == 0)
                id = _Repository.GetSubCategoryId(categoryName);
           var advertList = new NinjaLista.Views.Models.AdvertListModel();
           var adverts = _Repository.GetAllPostAds(id);
            var advertsTotalCount = adverts.Count;
            advertList.adverts = (adverts).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            advertList.CurrentCategory = categoryName;
            advertList.PagingInfo = new NinjaLista.Views.Models.PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = advertsTotalCount,
                CurrentCategory = categoryName
            };
            return View(advertList);
        }

        public ActionResult termsAndConditions()
        {
            return View();
        }

       public ActionResult policypage()
        {
            return View();
        }

       public ActionResult PreviewAd(AdvertismentDetails AdDetails)
       {
           return View();
       }
       
    }
 }

