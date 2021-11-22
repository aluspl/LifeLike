using System;

namespace LifeLike.Common.Enums
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