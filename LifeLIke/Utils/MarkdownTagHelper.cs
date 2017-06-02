using System.Threading.Tasks;
using HeyRed.MarkdownSharp;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LifeLike.Utils
{
    [HtmlTargetElement("markdown", TagStructure = TagStructure.NormalOrSelfClosing)]
    [HtmlTargetElement(Attributes = "markdown")]
    public class MarkdownTagHelper : TagHelper
    {
        public ModelExpression Content { get; set; }


         public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
         {
            if (output.TagName == "markdown")
            {
                output.TagName = null;
            }
            output.Attributes.RemoveAll("markdown");
            var markdownTransformer = new Markdown();
            
             var content = await GetContent(output);

             var result = markdownTransformer.Transform(content);
             //output.TagName = "div";
             output.Content.SetHtmlContent(result);
             output.TagMode = TagMode.StartTagAndEndTag;
            
        }
        private async Task<string> GetContent(TagHelperOutput output)
        {
                return Content == null ? (await output.GetChildContentAsync()).GetContent() : Content.Model?.ToString();
        }
    }
}