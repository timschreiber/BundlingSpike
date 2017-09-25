using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundlingSpike.Core.Entities
{
    public class Bundle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SiteId { get; set; }
        public BundleType Type { get; set; }

        public virtual Site Site { get; set; }
        public virtual ICollection<File> Files { get; set; } = new HashSet<File>();

        public string FileName
        {
            get { return $"{Id}.{(Type == BundleType.StyleSheet ? "css" : "js")}"; }
        }

        public string Bundled
        {
            get { return string.Join("\n", Files.OrderBy(x => x.Order).ToArray().Select(x => x.Minified)); }
        }
    }

    public enum BundleType
    {
        StyleSheet,
        JavaScript
    }
}
