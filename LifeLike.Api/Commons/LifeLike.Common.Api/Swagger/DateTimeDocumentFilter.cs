#region Usings

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

#endregion

namespace LifeLike.Common.Api.Swagger;

public class DateTimeDocumentFilter : IDocumentFilter
{
    #region Apply

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var schema in swaggerDoc.Components.Schemas)
        {
            foreach (var property in schema.Value.Properties)
            {
                if (property.Value.Format == "date-time" && property.Value.Type == "string")
                {
                    property.Value.Format = "int64";
                    property.Value.Type = "integer";
                }
            }
        }
    }

    #endregion
}