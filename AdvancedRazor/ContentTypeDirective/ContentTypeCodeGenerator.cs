using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Razor.Generator;
using System.Web.Razor.Parser.SyntaxTree;

namespace ContentTypeDirective
{
    public class ContentTypeCodeGenerator : SpanCodeGenerator
    {
        public override void GenerateCode(Span target, CodeGeneratorContext context)
        {
            // We parsed: "@contentType Text.Html"
            // And we assigned this code generator to the "Text.Html" part
            // So this node's content should be "Text.Html"
            string contentType = target.Content;

            // The final code we want is something like
            // Response.ContentType = ContentTypes.Text.Html;

            // So, we start by injecting the "prolog" (this is compiler speak for the stuff before the user code)
            context.BufferStatementFragment("Response.ContentType = ContentTypes.");

            // Now we tell the code generator infrastructure that we're at the start of user code
            // This allows us to inject markers so the editor can light up.
            context.MarkStartOfGeneratedCode();

            // Here's our user code!
            context.BufferStatementFragment(contentType);

            // And we tell Razor we're finished with user code, again for the editor
            context.MarkEndOfGeneratedCode();

            // Finally, we inject the "epilog" (compiler speak for stuff after the user code)
            context.BufferStatementFragment(";");

            // And output the whole statement to the generated Execute method
            context.FlushBufferedStatement();
        }
    }
}
