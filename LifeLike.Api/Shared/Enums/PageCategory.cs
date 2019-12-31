using System;

namespace LifeLike.Shared.Enums
{
    [Flags]
    public enum PageCategory
    {
        App, Game,
        Tutorial,
        Page,
        Post,
        Projects = App | Game
    }
}
