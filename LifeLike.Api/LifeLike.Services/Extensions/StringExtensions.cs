using System.Linq;
using System.Text.RegularExpressions;

namespace LifeLike.Services.Extensions
{
    public static class StringExtensions
    {
        public static string Summary(this string item)
        {
            return string.IsNullOrEmpty(item) ? string.Empty : RemoveMarkdownTags(item.Length < 100 ? item : item.Substring(0, 100));
        }

        private static string RemoveMarkdownTags(string content)
        {
            // Headers
            content = Regex.Replace(content, "/\n={2,}/g", "\n");
            // Strikethrough
            content = Regex.Replace(content, "/~~/g", "");
            // Codeblocks
            content = Regex.Replace(content, "/`{3}.*\n/g", "");
            // HTML Tags
            content = Regex.Replace(content, "/<[^>]*>/g", "");
            // Remove setext-style headers
            content = Regex.Replace(content, "/^[=\\-]{2,}\\s*$/g", "");
            // Footnotes
            content = Regex.Replace(content, "/\\[\\^.+?\\](\\: .*?$)?/g", "");
            content = Regex.Replace(content, "/\\s{0,2}\\[.*?\\]: .*?$/g", "");
            // Images
            content = Regex.Replace(content, "/\\!\\[.*?\\][\\[\\(].*?[\\]\\)]/g", "");
            // Links
            content = Regex.Replace(content, "/\\[(.*?)\\][\\[\\(].*?[\\]\\)]/g", "$1");
            return content;
        }
        
        public static string GetYoutubeId(this string videoLink)
        {
            if (videoLink==null || videoLink==string.Empty) return null;
            return videoLink.Contains('=') ? videoLink.Split('=').LastOrDefault() : videoLink;
        }

        public static string ToHTML(this string content)
        {
            // Headers
            content = Regex.Replace(content, "/\n={2,}/g", "\n");
            // Strikethrough
            content = Regex.Replace(content, "/~~/g", "");
            // Codeblocks
            content = Regex.Replace(content, "/`{3}.*\n/g", "");
            // HTML Tags
            content = Regex.Replace(content, "/<[^>]*>/g", "");
            // Remove setext-style headers
            content = Regex.Replace(content, "/^[=\\-]{2,}\\s*$/g", "");
            // Footnotes
            content = Regex.Replace(content, "/\\[\\^.+?\\](\\: .*?$)?/g", "");
            content = Regex.Replace(content, "/\\s{0,2}\\[.*?\\]: .*?$/g", "");
            // Images
            content = Regex.Replace(content, "/\\!\\[.*?\\][\\[\\(].*?[\\]\\)]/g", "");
            // Links
            content = Regex.Replace(content, "/\\[(.*?)\\][\\[\\(].*?[\\]\\)]/g", "$1");
            return content;
        }
    
    }
}