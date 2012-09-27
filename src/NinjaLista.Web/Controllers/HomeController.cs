﻿using System;
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
using System.Net.Mail;
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

            var mailMessage = new MailMessage(emailDetails.EmailAddress, "admin@ninjalista.com", emailDetails.SelectedSubject,  emailDetails.Message);
            SendEmail(mailMessage);        
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
           replyad.AdId = id;
            return View(replyad);
        }

        [HttpPost]
        public ActionResult ReplyAd(ReplyAdDetails replyDetails)
        {
            if (!ModelState.IsValid)
                return View();
           // var details = _Repository.GetAdvertDetails(replyDetails.AdId);

            var subject = string.Format("{0} {1}","Reply For", replyDetails.AdTitle);
            var mailMessage = new MailMessage(replyDetails.FromEmail, replyDetails.ToEmailAddress, replyDetails.AdTitle, replyDetails.Message);
                      
            
            return RedirectToAction("Confirmation", "Home");
        }

       public void SendEmail(MailMessage msg)
        {
           var host = ConfigurationManager.AppSettings["host"];
           var userName = ConfigurationManager.AppSettings["userName"];
           var password = ConfigurationManager.AppSettings["password"];

            var smtp = new SmtpClient(host);
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential(userName, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;
            smtp.Send(msg);
        }
       
        public ActionResult Details(string category, string title,int Id)
        {
            var details = new AdvertismentDetails();
            details = _Repository.GetAdvertDetails(Id);
            details.Category = category;
            details.AdId = Id;
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
                       //functionality to send confirmation msg to client
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
            int pageSize = 10;

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

