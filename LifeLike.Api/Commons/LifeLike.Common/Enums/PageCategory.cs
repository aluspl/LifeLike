namespace LifeLike.Common.Enums;

[Flags]
public enum PageCategory
{
    App, Game,
    Tutorial,
    Page,
    Post,
    Projects = App | Game
}