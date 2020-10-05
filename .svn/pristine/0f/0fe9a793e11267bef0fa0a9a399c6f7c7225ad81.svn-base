app.service("APIService", function ($http) {
    this.getHotelDetails = function () {
     //  var url = "http://hotels.tag2travel.com:4585/api/HotelBooking/getHotelDetails";
         var url = "/api/HotelBooking/getHotelDetails";
        return $http.get(url).then(function(response) {
            return response.data;
        });
    };
    
});