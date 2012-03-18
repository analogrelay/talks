using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentTypeDirective
{
    public static class ContentTypes
    {
        public static class Text
        {
            public const string Plain = "text/plain";
            public const string Html = "text/html";
        }

        public static class Application
        {
            public const string Json = "application/json";
            public const string Xml = "application/xml";
        }
    }
}
