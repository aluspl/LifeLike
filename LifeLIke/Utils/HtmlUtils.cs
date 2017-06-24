using LifeLike.ViewModel;

namespace LifeLIke.Utils
{
    public class HtmlUtils
    {
        public static string GenerateYoutube(LinkViewModel videoLink)
        {
            var format = string.Format("<div class='embed-responsive embed-responsive-16by9'>"
                                       +                         "<h2>{0}</h2>"+                                   
                                       "<iframe width='560' height='315' src='https://www.youtube.com/embed/{1}' " +
                                       "?rel'0' frameborder='0' allowfullscreen></iframe>" + 
                                       "</div>", videoLink.Name, videoLink.Link);
            return format;
        }
        public static string GenerateIcon(string icon)
        {
            var format = string.Format($"<span class='glyphicon glyphicon-{icon}' aria-hidden='true'> </span> ");
            return format;
        }
        
    }
}