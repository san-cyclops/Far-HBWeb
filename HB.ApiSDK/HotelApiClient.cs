using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using HB.ApiModel.auto.messages;
using HB.ApiSDK.types;
using Newtonsoft.Json;

namespace HB.ApiSDK
{
    /// <summary>
    /// </summary>
    public class HotelApiClient
    {
        //https://developer.hotelbeds.com/docs/read/apitude_booking/

        /// <summary>
        ///     CONSTANTS
        /// </summary>
        private const int REST_TEMPLATE_READ_TIME_OUT = 5000;

        private readonly string apiKey;

        /// <summary>
        ///     Atributos
        /// </summary>
        private readonly string basePath;

        private readonly string sharedSecret;
        private readonly HotelApiVersion version;
        private string environment;

        public HotelApiClient()
        {
            apiKey = GetHotelApiKeyFromConfig();
            sharedSecret = GetHotelSharedSecretFromConfig();
            version = new HotelApiVersion(HotelApiVersion.versions.V1);
            basePath = GetEnvironment();
            CheckHotelApiClientConfig();
        }

        public HotelApiClient(HotelApiVersion version)
        {
            apiKey = GetHotelApiKeyFromConfig();
            sharedSecret = GetHotelSharedSecretFromConfig();
            this.version = version;
            basePath = GetEnvironment();
            CheckHotelApiClientConfig();
        }

        public HotelApiClient(string apiKey, string sharedSecret)
        {
            this.apiKey = apiKey;
            this.sharedSecret = sharedSecret;
            version = new HotelApiVersion(HotelApiVersion.versions.V1);
            basePath = GetEnvironment();
            CheckHotelApiClientConfig();
        }

        public HotelApiClient(HotelApiVersion version, string apiKey, string sharedSecret)
        {
            this.apiKey = apiKey;
            this.sharedSecret = sharedSecret;
            this.version = version;
            basePath = GetEnvironment();
            CheckHotelApiClientConfig();
        }

        private void CheckHotelApiClientConfig()
        {
            if (string.IsNullOrEmpty(apiKey) || version == null || string.IsNullOrEmpty(basePath) ||
                string.IsNullOrEmpty(sharedSecret))
                throw new Exception(
                    "HotelApiClient cannot be created without specifying an API key, Shared Secret, the Hotel API version and the service you are connecting to.",
                    new ArgumentNullException());
        }

        private string GetHotelApiKeyFromConfig()
        {
            try
            {
                var returnValue = ConfigurationManager.AppSettings.Get("ApiKey");

                return returnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GetHotelSharedSecretFromConfig()
        {
            try
            {
                var returnValue = ConfigurationManager.AppSettings.Get("SharedSecret");

                return returnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GetEnvironment()
        {
            try
            {
                var returnValue = string.Empty;
                environment = ConfigurationManager.AppSettings.Get("ENVIRONMENT");
                if (!string.IsNullOrEmpty(environment))
                {
                    returnValue = ConfigurationManager.AppSettings.Get(environment);
                }
                return returnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public StatusRS status()
        {
            var avail = new HotelApiPaths.STATUS();
            var status = callRemoteApi<StatusRS, object>(null, avail, null);
            return status;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AvailabilityRS doAvailability(AvailabilityRQ request)
        {
            try
            {
                var avail = new HotelApiPaths.AVAILABILITY();
                var response = callRemoteApi<AvailabilityRS, AvailabilityRQ>(request, avail, null);
                return response;
            }
            catch (HotelSDKException e)
            {
                throw e;
            }
        }

        public CheckRateRS doCheck(CheckRateRQ checkRateRQ)
        {
            try
            {
                var checkRate = new HotelApiPaths.CHECK_AVAIL();
                var response = callRemoteApi<CheckRateRS, CheckRateRQ>(checkRateRQ, checkRate, null);
                return response;
            }
            catch (HotelSDKException e)
            {
                throw e;
            }
        }

        public BookingRS confirm(BookingRQ bookingRQ)
        {
            try
            {
                var bookingConfirm = new HotelApiPaths.BOOKING_CONFIRM();
                var response = callRemoteApi<BookingRS, BookingRQ>(bookingRQ, bookingConfirm, null);
                return response;
            }
            catch (HotelSDKException e)
            {
                throw e;
            }
        }

        public BookingCancellationRS Cancel(List<Tuple<string, string>> param)
        {
            try
            {
                var bookingCancel = new HotelApiPaths.BOOKING_CANCEL();
                var response = callRemoteApi<BookingCancellationRS, Tuple<string, string>[]>(null, bookingCancel, param);
                return response;
            }
            catch (HotelSDKException e)
            {
                throw e;
            }
        }

        public BookingDetailRS Detail(List<Tuple<string, string>> param)
        {
            try
            {
                var bookingDetail = new HotelApiPaths.BOOKING_DETAIL();
                var response = callRemoteApi<BookingDetailRS, Tuple<string, string>[]>(null, bookingDetail, param);
                return response;
            }
            catch (HotelSDKException e)
            {
                throw e;
            }
        }

        public BookingListRS List(List<Tuple<string, string>> param)
        {
            try
            {
                var bookingList = new HotelApiPaths.BOOKING_LIST();
                var response = callRemoteApi<BookingListRS, Tuple<string, string>[]>(null, bookingList, param);
                return response;
            }
            catch (HotelSDKException e)
            {
                throw e;
            }
        }

        private T callRemoteApi<T, U>(U request, HotelApiPaths.HotelApiPathsBase path, List<Tuple<string, string>> param)
        {
            try
            {
                var response = default(T);

                using (var client = new HttpClient(
                    new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip
                    }))
                {
                    if (request == null && path.GetType() != typeof (HotelApiPaths.STATUS) &&
                        path.GetType() != typeof (HotelApiPaths.BOOKING_CANCEL) &&
                        path.GetType() != typeof (HotelApiPaths.BOOKING_DETAIL) &&
                        path.GetType() != typeof (HotelApiPaths.BOOKING_LIST))
                        throw new Exception("Object request can't be null");

                    client.BaseAddress = new Uri(path.getUrl(basePath, version));
                    client.DefaultRequestHeaders.Clear();
                    client.Timeout = new TimeSpan(0, 0, REST_TEMPLATE_READ_TIME_OUT);
                    client.DefaultRequestHeaders.Add("Api-Key", apiKey);

                    var ts =
                        (long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds/
                        1000;
                    var hashstring = SHA256.Create();
                    var hash = hashstring.ComputeHash(Encoding.UTF8.GetBytes(apiKey + sharedSecret + ts));
                    var signature = BitConverter.ToString(hash).Replace("-", "");
                    client.DefaultRequestHeaders.Add("X-Signature", signature);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                    // GET Method
                    if (path.getHttpMethod() == HttpMethod.Get)
                    {
                        var Uri = path.getEndPoint();

                        if (param != null)
                        {
                            Uri = path.getEndPoint(param);
                        }

                        var resp = client.GetAsync(Uri).Result;
                        response = resp.Content.ReadAsAsync<T>().Result;
                        return response;
                    }

                    // DELETE Method
                    if (path.getHttpMethod() == HttpMethod.Delete)
                    {
                        var Uri = path.getEndPoint();

                        if (param != null)
                        {
                            Uri = path.getEndPoint(param);
                        }

                        var resp = client.DeleteAsync(Uri).Result;
                        response = resp.Content.ReadAsAsync<T>().Result;
                        return response;
                    }

                    StringContent contentToSend = null;
                    if (request != null)
                    {
                        var objectSerialized = JsonConvert.SerializeObject(request, Formatting.Indented,
                            new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore});
                        contentToSend = new StringContent(objectSerialized, Encoding.UTF8, "application/json");
                    }

                    if (path.getHttpMethod() == HttpMethod.Post)
                    {
                        HttpResponseMessage resp = null;
                        if (param == null)
                            resp = client.PostAsync(path.getEndPoint(), contentToSend).Result;
                        else
                            resp = client.PostAsync(path.getEndPoint(param), contentToSend).Result;

                        response = resp.Content.ReadAsAsync<T>().Result;
                    }
                }

                return response;
            }
            catch (HotelSDKException e)
            {
                throw e;
            }
        }
    }
}