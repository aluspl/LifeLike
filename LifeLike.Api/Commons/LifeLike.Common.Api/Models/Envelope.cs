#region Usings

using LifeLike.Common.Model;

#endregion

namespace LifeLike.Common.Api.Models;

public class Envelope<T>
{
    #region Constructor(s)

    public Envelope(T data)
    {
        Data = data;
    }

    public Envelope(IList<Error> errors)
    {
        Errors = errors;
    }

    private Envelope()
    {
    }

    #endregion

    #region Public Properties

    public T Data { get; set; }

    public IList<Error> Errors { get; set; } = new List<Error>();

    public bool HasErrors => Errors.Count > 0;

    #endregion
}