#region Usings

using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

#endregion

namespace LifeLike.Common.Api.Swagger;

public class LowercaseDocumentFilter : IDocumentFilter
{
    #region Apply

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc.Paths;

        var newPaths = new Dictionary<string, OpenApiPathItem>();
        var removeKeys = new List<string>();
        foreach (var path in paths)
        {
            var sb = new StringBuilder();

            var parts = path.Key.Split("/").Where(s => !string.IsNullOrEmpty(s));

            foreach (var part in parts)
            {
                sb.Append('/');
                sb.Append(part.StartsWith('{') ? part : part.ToLower());
            }

            var newKey = sb.ToString();
            if (newKey != path.Key)
            {
                removeKeys.Add(path.Key);
                newPaths.Add(newKey, path.Value);
            }
        }

        foreach (var path in newPaths)
        {
            swaggerDoc.Paths.Add(path.Key, path.Value);
        }

        foreach (var key in removeKeys)
        {
            swaggerDoc.Paths.Remove(key);
        }
    }

    #endregion
}