using System.Collections.Generic;
using System.Net.Http;
using HB.ApiModel.auto.messages;

namespace HB.ApiSDK.types
{
    public class HotelApiPaths<T> where T : AbstractGenericResponse
    {
        public enum Paths
        {
            AVAILABILITY,
            BOOKING_LIST,
            BOOKING_DETAIL,
            BOOKING_CONFIRM,
            BOOKING_CANCEL,
            CHECK_AVAIL,
            STATUS
        }

        private readonly HttpMethod httpMethod; // TODO: Convertir string en tipo httpMethod java
        private readonly T responseClass;
        private readonly string urlTemplate;

        private Paths path;

        private Dictionary<Paths, string> urlTemplates;

        private HotelApiPaths(string urlTemplate, HttpMethod httpMethod, T responseClass, Paths path)
        {
            this.urlTemplate = urlTemplate;
            this.httpMethod = httpMethod;
            this.responseClass = responseClass;
            this.path = path;
        }

        private void loadUrls()
        {
            urlTemplates.Add(Paths.AVAILABILITY, "${path}/${version}/hotels");
            urlTemplates.Add(Paths.BOOKING_LIST,
                "${path}/${version}/bookings?from=${from}&to=${to}&includeCancelled=${includeCancelled}&filterType=${filterType}");
            urlTemplates.Add(Paths.BOOKING_DETAIL, "${path}/${version}/bookings/${bookingId}");
        }

        public string getUrlTemplate()
        {
            return urlTemplate;
        }

        public T getResponseClass()
        {
            return responseClass;
        }

        public HttpMethod getHttpMethod()
        {
            return httpMethod;
        }

        public string getUrl(string basePath, HotelApiVersion version, Dictionary<string, string> param)
        {
            if (param == null)
            {
                param = new Dictionary<string, string>();
            }

            param.Add("path", basePath);
            param.Add("version", version.version.ToString());

            return string.Empty;
        }
    }
}