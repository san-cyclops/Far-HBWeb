using System;
using System.Collections.Generic;
using System.Linq;

using HB.WebApiModel;
using HB.ApiModel.Content;
using HB.ApiContentSDK;
using HB.ApiModel.auto.messages;
using HB.ApiSDK;


namespace HB.Service
{
    public class HotelContentService
    {
        public HotelsRS TestBooking(int[] hotellist)
        {
            var x = new HotelApiClient();
            var status = x.status();
            var client = new HotelApiContentClient();
            HotelsRQ hotelsRq = new HotelsRQ();
            var responseAvail = client.GetHotel(hotellist, "Eng", false);
            return responseAvail;
        }

        public DestinationsRS getDestinations(string DestinationCode)
        {
            var x = new HotelApiClient();
            var status = x.status();
            var client = new HotelApiContentClient();
            DestinationsRS destination = new DestinationsRS();
            destination = client.GetDestination(DestinationCode, "Eng", false);
            return destination;
        }
        public DestinationsRS getDestinations(int from, int to)
        {
            var x = new HotelApiClient();
            var status = x.status();
            var client = new HotelApiContentClient();
            DestinationsRS destination = new DestinationsRS();
            destination = client.GetDestination(from, to);
            return destination;
        }

        public RateCommentsRS getRateComments(int from, int to)
        {
            var client = new HotelApiContentClient();
            RateCommentsRS rateCommentsRS = new RateCommentsRS();
            rateCommentsRS = client.GetRateComments(from, to);
            return rateCommentsRS;
        }

        public HotelsRS getHotels(string DestinationCode)
        {
            var client = new HotelApiContentClient();
            HotelsRS hotelsRs = new HotelsRS();
            hotelsRs = client.GetHotels(DestinationCode, "Eng", false);
            return hotelsRs;
        }

        public HotelsRS getHotels(int from, int to)
        {
            var client = new HotelApiContentClient();
            HotelsRS hotelsRs = new HotelsRS();
            hotelsRs = client.GetHotels(from, to);
            return hotelsRs;
        }
        public HotelsRS getHotelsfromCode(int from, int to)
        {
            var client = new HotelApiContentClient();
            HotelsRS hotelsRs = new HotelsRS();
            hotelsRs = client.GetHotelsfromCode(from, to);
            return hotelsRs;
        }
        public CountriesRS getCountries(int from, int to)
        {
            var client = new HotelApiContentClient();
            CountriesRS countriesRs = new CountriesRS();
            countriesRs = client.GetCountries(from, to);
            return countriesRs;
        }

        public SegmentsRS getSegments(int from, int to)
        {
            var client = new HotelApiContentClient();
            SegmentsRS segmentsRs = new SegmentsRS();
            segmentsRs = client.GetSegments(from, to);
            return segmentsRs;
        }

        public AccommodationsRS getAccommodations(int from, int to)
        {
            var client = new HotelApiContentClient();
            AccommodationsRS accommodationrRs = new AccommodationsRS();
            accommodationrRs = client.GetAccommodations(from,to);
            return accommodationrRs;
        }

        public BoardsRS GetBoards(int from, int to)
        {
            var client = new HotelApiContentClient();
            BoardsRS boardsRs = new BoardsRS();
            boardsRs = client.GetBoards(from, to);
            return boardsRs;
        }

        public CategoriesRS Getcategories(int from, int to)
        {
            var client = new HotelApiContentClient();
            CategoriesRS categoriesRs = new CategoriesRS();
            categoriesRs = client.Getcategories(from, to);
            return categoriesRs;
        }

        public ChainsRS Getchains(int from, int to)
        {
            var client = new HotelApiContentClient();
            ChainsRS chainsRs = new ChainsRS();
            chainsRs = client.Getchains(from, to);
            return chainsRs;
        }

        public RateCommentsRS GetRateComments(int from, int to)
        {
            var client = new HotelApiContentClient();
            RateCommentsRS reateCommentsRs = new RateCommentsRS();
            reateCommentsRs = client.GetRateComments(from, to);
            return reateCommentsRs;
        }
        public RateCommentsRS GetRateCommentDetails(string rateCommentsId)
        {
            var client = new HotelApiContentClient();
            RateCommentsRS reateCommentsRs = new RateCommentsRS();
            reateCommentsRs = client.GetRateCommentDetails(rateCommentsId);
            return reateCommentsRs;
        }
        public CurrenciesRS Getcurrencies(int from, int to)
        {
            var client = new HotelApiContentClient();
            CurrenciesRS currenciesRs = new CurrenciesRS();
            currenciesRs = client.Getcurrencies(from, to);
            return currenciesRs;
        }

        public FacilitiesRS Getfacilities(int from, int to)
        {
            var client = new HotelApiContentClient();
            FacilitiesRS facilitiesRs = new FacilitiesRS();
            facilitiesRs = client.Getfacilities(from, to);
            return facilitiesRs;
        }

        public FacilityGroupsRS Getfacilitygroups(int from, int to)
        {
            var client = new HotelApiContentClient();
            FacilityGroupsRS facilityGroupsRs = new FacilityGroupsRS();
            facilityGroupsRs = client.Getfacilitygroups(from, to);
            return facilityGroupsRs;
        }

        public FacilityTypologiesRS Getfacilitytypologies(int from, int to)
        {
            var client = new HotelApiContentClient();
            FacilityTypologiesRS facilityTypologiesRs = new FacilityTypologiesRS();
            facilityTypologiesRs = client.Getfacilitytypologies(from, to);
            return facilityTypologiesRs;
        }

        public IssuesRS Getissues(int from, int to)
        {
            var client = new HotelApiContentClient();
            IssuesRS issuesRs = new IssuesRS();
            issuesRs = client.Getissues(from, to);
            return issuesRs;
        }

        public LanguagesRS Getlanguage(int from, int to)
        {
            var client = new HotelApiContentClient();
            LanguagesRS languagesRs = new LanguagesRS();
            languagesRs = client.Getlanguage(from, to);
            return languagesRs;
        }

        public PromotionsRS Getpromotions(int from, int to)
        {
            var client = new HotelApiContentClient();
            PromotionsRS promotionsRs = new PromotionsRS();
            promotionsRs = client.Getpromotions(from, to);
            return promotionsRs;
        }

        public RoomsRS Getrooms(int from, int to)
        {
            var client = new HotelApiContentClient();
            RoomsRS roomsRs = new RoomsRS();
            roomsRs = client.Getrooms(from, to);
            return roomsRs;
        }

        public SegmentsRS GetSegments(int from, int to)
        {
            var client = new HotelApiContentClient();
            SegmentsRS segmentsRs = new SegmentsRS();
            segmentsRs = client.GetSegments(from, to);
            return segmentsRs;
        }

        public TerminalsRS Getterminals(int from, int to)
        {
            var client = new HotelApiContentClient();
            TerminalsRS terminalsRs = new TerminalsRS();
            terminalsRs = client.Getterminals(from, to);
            return terminalsRs;
        }

        public ImageTypesRS Getimagetypes(int from, int to)
        {
            var client = new HotelApiContentClient();
            ImageTypesRS imageTypesRs = new ImageTypesRS();
            imageTypesRs = client.Getimagetypes(from, to);
            return imageTypesRs;
        }

        public GroupCategoriesRS Getgroupcategories(int from, int to)
        {
            var client = new HotelApiContentClient();
            GroupCategoriesRS groupCategoriesRs = new GroupCategoriesRS();
            groupCategoriesRs = client.Getgroupcategories(from, to);
            return groupCategoriesRs;
        }

        public RateCommentDetailsRS Getratecommentdetails(int from, int to)
        {
            var client = new HotelApiContentClient();
            RateCommentDetailsRS rateCommentDetailsRs = new RateCommentDetailsRS();
            rateCommentDetailsRs = client.Getratecommentdetails(from, to);
            return rateCommentDetailsRs;
        }
    }
}