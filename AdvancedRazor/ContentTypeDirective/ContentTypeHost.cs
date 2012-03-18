using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Razor;
using System.Web.Razor;
using System.Web.Razor.Parser;
using System.Web.WebPages.Razor;

namespace ContentTypeDirective
{
    public class ContentTypeHost : MvcWebPageRazorHost
    {
        public ContentTypeHost(string virtualPath, string physicalPath)
            : base(virtualPath, physicalPath)
        {
            NamespaceImports.Add(typeof(ContentTypes).Namespace);
        }

        public override ParserBase DecorateCodeParser(ParserBase incomingCodeParser)
        {
            // If we're parsing C#
            if (CodeLanguage is CSharpRazorCodeLanguage)
            {
                // Return our special C# code parser
                return new ContentTypeCSharpCodeParser();
            }
            else
            {
                return base.DecorateCodeParser(incomingCodeParser);
            }
        }
    }

    public class ContentTypeHostFactory : WebRazorHostFactory
    {
        public override WebPageRazorHost CreateHost(string virtualPath, string physicalPath)
        {
            return new ContentTypeHost(virtualPath, physicalPath);
        }
    }
}
