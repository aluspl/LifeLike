using System;

namespace LifeLike.Data.Models.Enums
{
    [Flags]
    public enum ConfigType
    {
        RSS,
        Text,
        Image,
        Video,
        URL,
    }
}