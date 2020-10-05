app.service("APIService", function($http) {
    

    this.hotelSearch = function (sub) {
        return $http({
            method: "post",
            data: sub,
            contentType: "application/json; charset=utf-8",
            url: "Home/Booking"
            
        });
    };

 
});