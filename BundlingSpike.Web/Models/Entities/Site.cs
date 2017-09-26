using System;
using System.Collections.Generic;

namespace BundlingSpike.Web.Models.Entities
{
    public class Site
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Bundle> Bundles { get; set; } = new HashSet<Bundle>();
    }
}
