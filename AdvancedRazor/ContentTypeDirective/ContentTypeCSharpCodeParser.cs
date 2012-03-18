using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc.Razor;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Tokenizer.Symbols;

namespace ContentTypeDirective
{
    public class ContentTypeCSharpCodeParser : MvcCSharpRazorCodeParser
    {
        public ContentTypeCSharpCodeParser()
            : base()
        {
            MapDirectives(ContentTypeDirective, "contentType");
        }

        private void ContentTypeDirective()
        {
            // We want to parse things like:
            // @contentType Text.Html
            AssertDirective("contentType"); // Make sure we're on "contentType"
            AcceptAndMoveNext();
            AcceptWhile(CSharpSymbolType.WhiteSpace); // Accept whitespace
            Output(SpanKind.MetaCode); // Output "meta-code" node (meta-code is used by syntax highlighting)

            // Now we are here ($):
            // @contentType ($)Text.Html
            
            // Accept until the end of the line
            AcceptUntil(CSharpSymbolType.NewLine);

            // We are here ($): 
            // @contentType Text.Html($)

            // If there's a newline, accept it and notify the editor that we can't accept any more
            AcceptedCharacters accepts = AcceptedCharacters.Any;
            if (Optional(CSharpSymbolType.NewLine))
            {
                accepts = AcceptedCharacters.None;
            }

            // Set up code generation
            // ContentTypeCodeGenerator will be called when we are generating code for this part of the parse tree.
            Span.CodeGenerator = new ContentTypeCodeGenerator();

            // Output the node as Code
            Output(SpanKind.Code, accepts); // "code" is used by syntax highlighting
        }
    }
}
