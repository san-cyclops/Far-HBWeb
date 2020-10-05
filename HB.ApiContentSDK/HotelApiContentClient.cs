using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using HB.ApiContentSDK.types;
using Newtonsoft.Json;
using HB.ApiModel.Content;
using HB.ApiModel.auto.messages;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace HB.ApiContentSDK
{
    public class HotelApiContentClient
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

        public HotelApiContentClient()
        {
            apiKey = GetHotelApiKeyFromConfig();
            sharedSecret = GetHotelSharedSecretFromConfig();
            version = new HotelApiVersion(HotelApiVersion.versions.V1);
            basePath = GetEnvironment();
            CheckHotelApiClientConfig();
        }

        public HotelApiContentClient(HotelApiVersion version)
        {
            apiKey = GetHotelApiKeyFromConfig();
            sharedSecret = GetHotelSharedSecretFromConfig();
            this.version = version;
            basePath = GetEnvironment();
            CheckHotelApiClientConfig();
        }
        public HotelApiContentClient(string apiKey, string sharedSecret)
        {
            this.apiKey = apiKey;
            this.sharedSecret = sharedSecret;
            version = new HotelApiVersion(HotelApiVersion.versions.V1);
            basePath = GetEnvironment();
            CheckHotelApiClientConfig();
        }
        public HotelApiContentClient(HotelApiVersion version, string apiKey, string sharedSecret)
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
                environment = ConfigurationManager.AppSettings.Get("ContentAPIENVIRONMENT");
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


        public HotelsRS GetHotel(int[] code, String language, bool useSecondaryLanguage)
        {
            HotelDetailsRQ request = new HotelDetailsRQ();

            string parameters = @"?fields=all&language=ENG&codes=";

            string param = "";
            for (int i = 0; i < code.Length; i++)
            {
                if (i == 0)
                {
                    param = code[0].ToString() + "%2C";
                }
                if (i == code.Length - 1)
                {
                    param = param + code[i].ToString();
                }

                else
                {
                    param = param + code[i].ToString() + "%2C";
                }

            }

            string fullurl = parameters + param + "&from=1&to=1000&useSecondaryLanguage=true";
            string basePath = GetEnvironment();
            var status = callRemoteApi<HotelsRS>(basePath+"/hotels",

                fullurl
                );


            return status;
        }


        public DestinationsRS GetDestination(string code, String language, bool useSecondaryLanguage)
        {
            string parameters = @"?fields=all&codes=";


            string fullurl = parameters + code + "&language=ENG&from=1&to=500&useSecondaryLanguage=false";

            var status = callRemoteApi<DestinationsRS>(basePath +"/locations/destinations",

                fullurl
                );


            return status;
        }

        public DestinationsRS GetDestination(int from, int to)
        {

            string parameters = @"?fields=all&";
            string fullurl = parameters + "&language=ENG&from=" + from + "&to=" + to + "&useSecondaryLanguage=false";
            var status = callRemoteApi<DestinationsRS>(basePath +"/locations/destinations",

                fullurl
                );


            return status;
        }

    
     
        public AccommodationsRS GetBoardss()
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<AccommodationsRS>(basePath +"/types/boards",

                fullurl
                );

            return status;
        }



        public HotelsRS GetHotels(string DestinationCode, String language, bool useSecondaryLanguage)
        {

            string parameters = @"?fields=all&destinationCode=";


            string fullurl = parameters + DestinationCode + "&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<HotelsRS>(basePath +"/hotels",

                fullurl
                );

            return status;
        }
        public HotelsRS GetHotels(int from, int to)
        {

            string parameters = @"?fields=all";


            string fullurl = parameters + "&language=ENG&from="+ from +"&to="+ to + "&useSecondaryLanguage=false";

            var status = callRemoteApi<HotelsRS>(basePath + "/1.0/hotels",

                fullurl
                );

            return status;
        }

        public HotelsRS GetHotelsfromCode(int from, int to)
        {

            string parameters = @"?fields=all";


            string fullurl = parameters + "&codes=" + from + "&" + to + "&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<HotelsRS>(basePath +"/hotels",

                fullurl
                );

            return status;
        }



        public CountriesRS GetCountries(int from, int to)
        {
 
            string fullurl =  @"?fields=all&language=ENG&from=" + from + "&to=" + to + "&useSecondaryLanguage=false";

            var status = callRemoteApi<CountriesRS>(basePath +"/locations/countries",

                fullurl
                );

            return status;
        }

       
        public HotelModel GetHotels(long HotelCode)
        {

            string fullurl = @"?language=ENG&useSecondaryLanguage=false";

            string hotelurl = basePath +"/hotels/" + HotelCode.ToString();

            var status = callRemoteApi<HotelModel>(hotelurl,

                fullurl
                );

            return status;
        }

        public AccommodationsRS GetAccommodations(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<AccommodationsRS>(basePath +"/types/accommodations",

                fullurl
                );

            return status;
        }

        public BoardsRS GetBoards(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<BoardsRS>(basePath +"/types/boards",

                fullurl
                );

            return status;
        }

        public CategoriesRS Getcategories(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<CategoriesRS>(basePath +"/types/categories",

                fullurl
                );

            return status;
        }

        public ChainsRS Getchains(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<ChainsRS>(basePath +"/types/chains",

                fullurl
                );

            return status;
        }

        public RateCommentsRS GetRateComments(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=" + from + "&to = " + to + "&useSecondaryLanguage=false";

            var status = callRemoteApi<RateCommentsRS>(basePath +"/types/ratecomments",

                fullurl
                );

            return status;
        }

        public RateCommentsRS GetRateCommentDetails(string rateCommentsId)
        {

            string fullurl = "code=" + rateCommentsId + "&fields=all&date=2016-03-18&language=CAS&from=1&to=100";

            var status = callRemoteApi<RateCommentsRS>(basePath +"/types/ratecommentdetails",

                fullurl
                );

            return status;
        }


        public CurrenciesRS Getcurrencies(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<CurrenciesRS>(basePath +"/types/currencies",

                fullurl
                );

            return status;
        }

        public FacilitiesRS Getfacilities(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=500&useSecondaryLanguage=false";

            var status = callRemoteApi<FacilitiesRS>(basePath +"/types/facilities",

                fullurl
                );

            return status;
        }

        public FacilityGroupsRS Getfacilitygroups(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<FacilityGroupsRS>(basePath +"/types/facilitygroups",

                fullurl
                );

            return status;
        }

        public FacilityTypologiesRS Getfacilitytypologies(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<FacilityTypologiesRS>(basePath +"/types/facilitytypologies",

                fullurl
                );

            return status;
        }

        public IssuesRS Getissues(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<IssuesRS>(basePath +"/types/issues",

                fullurl
                );

            return status;
        }

        public LanguagesRS Getlanguage(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<LanguagesRS>(basePath +"/types/language",

                fullurl
                );

            return status;
        }

        public PromotionsRS Getpromotions(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<PromotionsRS>(basePath +"/types/promotions",

                fullurl
                );

            return status;
        }

        public RoomsRS Getrooms(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<RoomsRS>(basePath +"/types/rooms",

                fullurl
                );

            return status;
        }

        public SegmentsRS GetSegments(int from, int to)
        {

            string fullurl = @"?fields=all&language=ENG&from=" + from + "&to=" + to + "&useSecondaryLanguage=false";

            var status = callRemoteApi<SegmentsRS>(basePath +"/types/segments",

                fullurl
                );

            return status;
        }

        public TerminalsRS Getterminals(int from, int to)
        {

            string fullurl = @"?fields=all&language=ENG&from=" + from + "&to=" + to + "&useSecondaryLanguage=false";

            var status = callRemoteApi<TerminalsRS>(basePath +"/types/terminals",

                fullurl
                );

            return status;
        }

        public ImageTypesRS Getimagetypes(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<ImageTypesRS>(basePath +"/types/imagetypes",

                fullurl
                );

            return status;
        }

        public GroupCategoriesRS Getgroupcategories(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<GroupCategoriesRS>(basePath +"/types/groupcategories",

                fullurl
                );

            return status;
        }

        public RateCommentDetailsRS Getratecommentdetails(int from, int to)
        {

            string fullurl = "?fields=all&language=ENG&from=1&to=100&useSecondaryLanguage=false";

            var status = callRemoteApi<RateCommentDetailsRS>(basePath +"/types/ratecommentdetails",

                fullurl
                );

            return status;
        }


        //***********************************************************************************

        public T callRemoteApi<T>(string URL, string urlParameters)
        {
            try
            {
                var responsenew = default(T);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                using (var client = new HttpClient(
                    new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip
                    }))
                {

                    client.BaseAddress = new Uri(URL);
                    client.DefaultRequestHeaders.Clear();
                    client.Timeout = new TimeSpan(0, 0, REST_TEMPLATE_READ_TIME_OUT);
                    client.DefaultRequestHeaders.Add("Api-Key", apiKey);

                    var ts =
                        (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds /
                        1000;
                    var hashstring = SHA256.Create();
                    var hash = hashstring.ComputeHash(Encoding.UTF8.GetBytes(apiKey + sharedSecret + ts));
                    var signature = BitConverter.ToString(hash).Replace("-", "");
                    client.DefaultRequestHeaders.Add("X-Signature", signature);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                    
                    // List data response.
                    HttpResponseMessage response = client.GetAsync(urlParameters).Result; // Blocking call!
                    if (response.IsSuccessStatusCode)
                    {
                        responsenew = response.Content.ReadAsAsync<T>().Result;
                    }
                    return responsenew;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }



}
