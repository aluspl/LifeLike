using System;

namespace LifeLike.Shared.Enums
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