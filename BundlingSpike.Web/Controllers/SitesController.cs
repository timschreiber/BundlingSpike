using BundlingSpike.Web.Models;
using BundlingSpike.Web.Models.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BundlingSpike.Web.Controllers
{
    [Authorize]
    public class SitesController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var model = Context.Sites
                .Where(x => x.UserId == userId)
                .Select(x => new SiteViewModel {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToArray();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new SiteViewModel { Id = default(Guid) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var site = new Site
                {
                    UserId = userId,
                    Name = model.Name,
                    Description = model.Description
                };

                Context.Sites.Add(site);
                Context.SaveChanges();

                return RedirectToAction("Index", "Sites");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var userId = User.Identity.GetUserId();

            var model = Context.Sites
                .Where(x => x.Id == id && x.UserId == userId)
                .Select(x => new SiteViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).SingleOrDefault();

            if(model == null)
                return View("Error");

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SiteViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var site = Context.Sites.SingleOrDefault(x => x.Id == model.Id && x.UserId == userId);
                if (site == null)
                    return View("Error");

                site.Name = model.Name;
                site.Description = model.Description;

                Context.SaveChanges();

                return RedirectToAction("Index", "Sites");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var userId = User.Identity.GetUserId();

            var model = Context.Sites
                .Where(x => x.Id == id && x.UserId == userId)
                .Select(x => new SiteViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).SingleOrDefault();

            if (model == null)
                return View("Error");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SiteViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var siteId = model?.Id ?? default(Guid);

            var site = Context.Sites.SingleOrDefault(x => x.Id == siteId && x.UserId == userId);
            if (site == null)
                return View("Error");

            Context.Sites.Remove(site);
            Context.SaveChanges();

            return RedirectToAction("Index", "Sites");
        }
    }
}