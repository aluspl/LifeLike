#region Usings

using System.ComponentModel.DataAnnotations;
using LifeLike.Common.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace LifeLike.Common.Api.Extensions;

public static class ConfigExtensions
{
    public static T BindConfigurationWithValidation<T>(this IServiceCollection services, IConfiguration configuration, string sectionName)
        where T : class, new()
    {
        var config = new T();
        configuration.GetSection(sectionName).Bind(config);

        var vc = new ValidationContext(config);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(config, vc, results, true);

        if (!isValid)
        {
            foreach (var error in results)
            {
                throw new InvalidConfigurationException(error.ToString());
            }
        }

        services.AddOptions<T>()
            .Bind(configuration.GetSection(sectionName));

        return config;
    }
}