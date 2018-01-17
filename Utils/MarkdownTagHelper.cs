using System.Threading.Tasks;
using HeyRed.MarkdownSharp;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LifeLike.Utils
{
    [HtmlTargetElement("p", Attributes = "markdown")]
    [HtmlTargetElement("markdown")]
    [OutputElementHint("p")]
    public class MarkdownTagHelper : TagHelper
    {
        public ModelExpression Content { get; set; }
       
        
        [HtmlAttributeName("text")]
        public string Text { get; set; }

        [HtmlAttributeName("source")]
        public ModelExpression Source { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var markdownTransformer = new Markdown();
            if (Source != null)
            {
                Text = Source.Model.ToString();
            }

            var result = markdownTransformer.Transform(Text);
            output.TagName = "div";
            output.Content.SetHtmlContent(result);
            output.TagMode = TagMode.StartTagAndEndTag;
        }

//         public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
//         {
//            if (output.TagName == "markdown")
//            {
//                output.TagName = null;
//            }
//            output.Attributes.RemoveAll("markdown");
//            var markdownTransformer = new Markdown();
//            
//             var content = await GetContent(output);
//
//             var result = markdownTransformer.Transform(content);
//             //output.TagName = "div";
//             output.Content.SetHtmlContent(result);
//             output.TagMode = TagMode.StartTagAndEndTag;
//            
//        }
        private async Task<string> GetContent(TagHelperOutput output)
        {
                return Content == null ? (await output.GetChildContentAsync()).GetContent() : Content.Model?.ToString();
        }
    }
}