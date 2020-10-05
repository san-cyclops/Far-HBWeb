app.service("APIService", function($http) {
    this.hotelavailability = function (subID) {
        //var url = "http://hotels.tag2travel.com:4585/api/HotelBooking/GethotelView?DestinationCode=" + subID;
        var url = "/api/HotelBooking/GethotelView?DestinationCode=" + subID;
        return $http.get(url).then(function (response) {
            return response.data;
        });
    };

});
 
