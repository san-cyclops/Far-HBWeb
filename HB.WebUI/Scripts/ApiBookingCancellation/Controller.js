var app = angular.module('mymodule', []);

app.controller('ctrl', function ($scope, $http) {


    $scope.referrenceNumber = "";
   
    $scope.cancelBooking = function ()    //**************************subscribe mail**************************
    {
        var referrenceNumber = $scope.referrenceNumber;

        
 
        {
            var r = confirm("Are you sure want to delete this booking?");
            if (r == true)
            {
                var url = "/api/HotelBooking/BookingCancellation?recid=" + referrenceNumber;
             //   var url = "http://hotels.tag2travel.com:4585/api/HotelBooking/BookingCancellation?recid=" + referrenceNumber;
                $http.get(url)
                   .success(function (val) {
                       if (val == "Invalid data. You cannot cancel a past booking") {
                           alert("Already cancelled!");
                           
                       }
                       else if (val == "Internal server error")
                       {
                           alert("Invalid referrence number!")
                       }
                       
                       else {
                           alert("Cancelled");
                           document.clear();
                       }
                       
                   })
            }
            else
            {
                return false;
            }
        
        }
 

    };

});