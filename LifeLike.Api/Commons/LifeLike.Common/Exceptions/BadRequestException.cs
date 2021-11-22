#region Usings

using System;
using System.Runtime.Serialization;

#endregion

namespace LifeLike.Common.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        #region Constructor(s)

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private BadRequestException()
        {
        }

        #endregion
    }
}