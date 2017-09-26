using BundlingSpike.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BundlingSpike.Web.Controllers
{
    public class BundlesController : BaseController
    {
        [HttpGet]
        public ActionResult Index(Guid siteId)
        {
            var userId = User.Identity.GetUserId();
            var site = Context.Sites.SingleOrDefault(x => x.Id == siteId && x.UserId == userId);

            if (site == null)
                return View("Error");

            var model = new BundleGridViewModel
            {
                SiteId = site.Id,
                SiteName = site.Name,
                SiteDescription = site.Description,
                Items = site.Bundles.Select(x => new BundleViewModel
                {
                    Id = x.Id,
                    Type = x.Type.ToString(),
                    Description = x.Description
                }).ToArray()
            };

            return View(model);
        }
    }
}