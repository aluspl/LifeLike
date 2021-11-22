#region Usings

using System.Collections.Generic;
using Error = LifeLike.Common.Model.Error;

#endregion

namespace LifeLike.Common.Api.Models
{
    public class EmptyEnvelope : Envelope<EmptyData>
    {
        public EmptyEnvelope()
            : base(new EmptyData())
        {
        }

        public EmptyEnvelope(Error error)
            : base(new List<Error> { error })
        {
        }

        public EmptyEnvelope(IList<Error> errors)
            : base(errors)
        {
        }
    }
}
