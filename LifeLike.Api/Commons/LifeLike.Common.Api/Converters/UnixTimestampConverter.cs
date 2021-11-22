#region Usings

using System;
using System.Globalization;
using LifeLike.Common.Extensions;
using Newtonsoft.Json;

#endregion

namespace LifeLike.Common.Api.Converters
{
    public class UnixTimestampConverter : JsonConverter
    {
        #region Consts

        public const long UnixMaxValue = 253402300799;

        public const long UnixMinValue = -62135596800;

        #endregion

        #region Public Methods

        public override bool CanConvert(Type objectType)
        {
            return typeof(DateTime) == objectType || typeof(DateTime?) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;

            if (value is null)
            {
                if (Nullable.GetUnderlyingType(objectType) is null)
                {
                    throw new JsonSerializationException("Null value is not allowed.");
                }

                return default;
            }

            if (value is not long seconds)
            {
                if (!long.TryParse(value.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out seconds))
                {
                    throw new JsonSerializationException($"Unable to parse {value} to number.");
                }
            }

            if (seconds < UnixMinValue || seconds > UnixMaxValue)
            {
                throw new JsonSerializationException(
                    $"Value {seconds} is out of allowed range from {UnixMinValue} to {UnixMaxValue}.");
            }

            return DateTimeOffset.FromUnixTimeSeconds(seconds).DateTime;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime dateTime)
            {
                writer.WriteValue(dateTime.ToUnixTimestamp());
            }
        }

        #endregion
    }
}
