#region Usings

using System;

#endregion

namespace LifeLike.Common.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        #region Constructor(s)

        public InvalidConfigurationException(string message)
            : base(message)
        {
        }

        #endregion
    }
}
