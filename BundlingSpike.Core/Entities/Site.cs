using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundlingSpike.Core.Entities
{
    public class Site
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Bundle> Bundles { get; set; } = new HashSet<Bundle>();
    }
}
