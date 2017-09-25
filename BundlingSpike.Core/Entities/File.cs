using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundlingSpike.Core.Entities
{
    public class File
    {
        public Guid FileId { get; set; }
        public Guid BundleId { get; set; }
        public string FileName { get; set; }
        public string Source { get; set; }
        public int Order { get; set; }

        public virtual Bundle Bundle { get; set; }

        public string Minified
        {
            get
            {
                var minifier = new Minifier();
                return Bundle.Type == BundleType.StyleSheet
                    ? minifier.MinifyStyleSheet(Source)
                    : minifier.MinifyJavaScript(Source);
            }
        }
    }
}
