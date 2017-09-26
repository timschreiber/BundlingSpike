using System;
using System.ComponentModel.DataAnnotations;

namespace BundlingSpike.Web.Models
{
    public class SiteViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}