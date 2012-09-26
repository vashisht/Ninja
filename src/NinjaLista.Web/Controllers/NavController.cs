using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ninjalista.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Menu/

        public PartialViewResult Menu()
        {
            return PartialView("menu");
        }

    }
}
