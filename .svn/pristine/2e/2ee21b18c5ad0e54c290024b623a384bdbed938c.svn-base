 app.service("APIService", function($http) {

    this.hotelavailability = function(sub) {
        return $http({
            method: "post",
            data: sub,
            //contentType: "application/json; charset=utf-8;text/plain",
            timeout:30000,
            // url: "http://hotels.tag2travel.com:4585/api/HotelBooking/Availability"
            url: "/api/HotelBooking/Availability"
            
        });
    };
    this.hotelavailabilityFilter = function (sub) {
        return $http({
            method: "post",
            data: sub,
            contentType: "application/json; charset=utf-8",
        // url: "http://hotels.tag2travel.com:4585/api/HotelBooking/PostSearch"
           url: "/api/HotelBooking/PostSearch"

        });
    };
    this.showhotelselected = function (subselect) {
        return $http({
            method: "post",
            data: subselect,
            contentType: "application/json; charset=utf-8",
            url: "Home/HotelView"
        });
    };
 
});