using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BundlingSpike.Web.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            return View();
        }
    }
}