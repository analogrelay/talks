using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Razor;
using ConfigFreeExtensibility.Helpers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ConfigFreeExtensibility.App_Start.ConfigureRazor), "Start")]

namespace ConfigFreeExtensibility.App_Start
{
    public static class ConfigureRazor
    {
        public static void Start()
        {
            RazorBuildProvider.CompilingPath += (sender, args) =>
            {
                args.Host.NamespaceImports.Add(typeof(MyHelpers).Namespace);
            };
        }
    }
}