using BundlingSpike.Web.Models;
using BundlingSpike.Web.Models.Entities;
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
                    SiteId = x.SiteId,
                    Type = x.Type.ToString(),
                    Description = x.Description
                }).ToArray()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(Guid siteId)
        {
            var userId = User.Identity.GetUserId();
            var site = Context.Sites.SingleOrDefault(x => x.Id == siteId && x.UserId == userId);

            populateBundleTypeSelectList();
            return View(new BundleViewModel { Id = default(Guid), SiteId = site.Id });
        }

        [HttpPost]
        public ActionResult Add(Guid siteId, BundleViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.SiteId != siteId)
                    return View("Error");

                var userId = User.Identity.GetUserId();
                var site = Context.Sites.SingleOrDefault(x => x.Id == siteId && x.UserId == userId);
                var bundle = new Bundle
                {
                    Type = (BundleType)Enum.Parse(typeof(BundleType), model.Type),
                    Description = model.Description,
                    Site = site
                };

                Context.Bundles.Add(bundle);
                Context.SaveChanges();

                return RedirectToRoute("Default", new { controller = "Sites", action = "Details", Id = site.Id });
            }

            populateBundleTypeSelectList();
            return View(model);
        }

        private void populateBundleTypeSelectList()
        {
            ViewBag.BundleTypes = Enum.GetNames(typeof(BundleType)).Select(x => new SelectListItem { Text = x, Value = x });
        }
    }
}