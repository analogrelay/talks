using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc.Razor;
using System.Web.WebPages.Razor;

[assembly: PreApplicationStartMethod(typeof(ContentTypeDirective.Register), "Start")]

namespace ContentTypeDirective
{
    public static class Register
    {
        public static void Start()
        {
            RazorBuildProvider.CompilingPath += (sender, args) =>
            {
                if (args.Host is MvcWebPageRazorHost)
                {
                    args.Host = new ContentTypeHost(args.Host.VirtualPath, args.Host.PhysicalPath);
                }
            };
        }
    }
}
