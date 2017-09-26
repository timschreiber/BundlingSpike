using BundlingSpike.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace BundlingSpike.Web.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationDbContext Context
        {
            get { return _context ?? (_context = HttpContext.GetOwinContext().Get<ApplicationDbContext>()); }
        }

        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>()); }
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? (_userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>()); }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }

                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}