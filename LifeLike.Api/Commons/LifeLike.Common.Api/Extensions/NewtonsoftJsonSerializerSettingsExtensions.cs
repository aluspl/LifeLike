#region Usings

using System;
using LifeLike.Common.Api.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace LifeLike.Common.Api.Extensions
{
    public static class NewtonsoftJsonSerializerSettingsExtensions
    {
        public static void SetupJsonSettings(this JsonSerializerSettings jsonSerializerSettings)
        {
            if (jsonSerializerSettings is null)
            {
                throw new ArgumentNullException(nameof(jsonSerializerSettings));
            }

            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Include;
            jsonSerializerSettings.Converters.Add(
                new StringEnumConverter
                {
                    AllowIntegerValues = false,
                });
            jsonSerializerSettings.Converters.Add(new UnixTimestampConverter());
        }
    }
}
