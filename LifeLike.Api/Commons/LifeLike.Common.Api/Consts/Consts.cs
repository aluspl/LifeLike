#region Usings

using System.Collections.Generic;
using Microsoft.Extensions.Logging;

#endregion

namespace LifeLike.Common.Api.Consts
{
    public struct Consts
    {
        #region LoggingEvents

        public struct LoggingEvents
        {
            public static EventId UnhandledException = new EventId(100, "Unhandled exception has occurred.");
        }

        #endregion

        #region Uri

        public struct Uri
        {
            #region Private Members

            private const string GoogleMapsTimezoneApiUrl = "https://maps.googleapis.com/maps/api/timezone/json";
            private const string GoogleMapsLocationApiUrl = "https://maps.googleapis.com/maps/api/geocode/json";

            #endregion

            #region Public Properties

            public static System.Uri GoogleMapsTimezoneApiUri
            {
                get { return new System.Uri(GoogleMapsTimezoneApiUrl); }
            }

            public static System.Uri GoogleMapsLocationApiUri
            {
                get { return new System.Uri(GoogleMapsLocationApiUrl); }
            }

            #endregion
        }

        #endregion

        #region Headers

        public struct XParameters
        {
            public const string PageSize = "x-pageSize";
            public const string PageNumber = "x-pageNumber";
            public const string Query = "x-query";
            public const string Order = "x-order";
            public const string Desc = "x-desc";
            public const string Company = "x-company";
        }

        #endregion

        #region Api Groups

        public struct ApiGroups
        {
            public const string Tag = "company";
            public const string Admin = "admin";

            public static IDictionary<string, string> GetNameValueDictionary()
            {
                var ret = new Dictionary<string, string>();

                object structValue = default(ApiGroups);

                foreach (var group in typeof(ApiGroups).GetFields())
                {
                    var value = group.GetValue(structValue).ToString();
                    var name = group.Name;
                    ret.Add(name, value);
                }

                return ret;
            }
        }

        #endregion
    }
}
