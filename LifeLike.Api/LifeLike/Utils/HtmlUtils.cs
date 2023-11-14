using LifeLike.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LifeLike.Utils;

public class HtmlUtils
{
    public static IEnumerable<SelectListItem> CategoryList
    {
        get
        {
            return Enum.GetValues(typeof(LinkCategory))
                .Cast<int>()
                .Select(e =>
                    new SelectListItem {Value = e.ToString(), Text = Enum.GetName(typeof(LinkCategory), e)});
        }
    }
}