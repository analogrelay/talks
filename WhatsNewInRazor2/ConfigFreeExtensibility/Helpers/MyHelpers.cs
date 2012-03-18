using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfigFreeExtensibility.Helpers
{
    public static class MyHelpers
    {
        public static IHtmlString ExternalLink(this HtmlHelper self, string title, string url)
        {
            return new HtmlString(String.Format("<a class=\"ext\" href=\"{1}\">{0}</a>", title, url));
        }
    }
}