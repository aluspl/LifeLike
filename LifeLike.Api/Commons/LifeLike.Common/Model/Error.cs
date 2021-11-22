#region Usings

#endregion

using LifeLike.Common.Enums;

namespace LifeLike.Common.Model
{
    public class Error
    {
        #region Constructor(s)

        public Error(
            ErrorType code,
            string message)
        {
            Code = code.ToString();
            Message = message;
        }

        public Error(
            string code,
            string message,
            bool validationError = false)
        {
            if (string.IsNullOrEmpty(code))
            {
                Code = ErrorType.Unexpected.ToString();
            }
            else
            {
                if (!code.StartsWith("invalid") && validationError)
                {
                    Code = $"invalid{code[0].ToString().ToUpper()}{code.Substring(1)}";
                }
                else
                {
                    Code = code[0].ToString().ToLower() + code.Substring(1);
                }
            }

            Message = message;
        }

        #endregion

        #region Public properties

        public string Code { get; }

        public string Message { get; }

        #endregion
    }
}
