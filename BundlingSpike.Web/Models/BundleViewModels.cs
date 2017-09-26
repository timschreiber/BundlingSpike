using System;
using System.ComponentModel.DataAnnotations;

namespace BundlingSpike.Web.Models
{
    public class BundleGridViewModel
    {
        public Guid SiteId { get; set; }
        public BundleViewModel[] Items { get; set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

        [Display(Name = "Site Description")]
        public string SiteDescription { get; set; }
    }

    public class BundleViewModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}