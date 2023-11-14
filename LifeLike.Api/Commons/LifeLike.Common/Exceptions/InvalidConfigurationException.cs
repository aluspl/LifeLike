#region Usings

#endregion

namespace LifeLike.Common.Exceptions;

public class InvalidConfigurationException : Exception
{
    #region Constructor(s)

    public InvalidConfigurationException(string message)
        : base(message)
    {
    }

    #endregion
}