#region Using

#endregion

namespace LifeLike.Common.Extensions;

public static class DateTimeExtensions
{
    #region Public Methods

    #region Unix Timestamp

    public static long ToUnixTimestamp(this DateTime date)
    {
        return (long)Math.Floor((date.ToUniversalTimeWhenUnspecified() - DateTimeOffset.UnixEpoch).TotalSeconds);
    }

    public static long? ToUnixTimestamp(this DateTime? date)
    {
        if (date.HasValue)
        {
            return (long)Math.Floor((date.Value.ToUniversalTimeWhenUnspecified() - DateTimeOffset.UnixEpoch).TotalSeconds);
        }

        return null;
    }

    public static DateTime FromUnixTimestamp(this long unixTimeStamp)
    {
        return DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
    }

    public static DateTime? FromUnixtimeStamp(this long? unixTimeStamp)
    {
        if (unixTimeStamp.HasValue)
        {
            return unixTimeStamp.Value.FromUnixTimestamp();
        }

        return null;
    }

    #endregion

    #region ToUniversalTimeWhenUnspecified

    private static DateTime ToUniversalTimeWhenUnspecified(this DateTime date)
    {
        return date.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(date, DateTimeKind.Utc) : date.ToUniversalTime();
    }

    #endregion

    #endregion
}