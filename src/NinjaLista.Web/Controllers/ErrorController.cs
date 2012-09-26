﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NinjaLista.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Error()
        {
            return View("Error");
        }

        public ActionResult PageNotFound()
        {
            return View("PageNotFound");
        }
    }
}
