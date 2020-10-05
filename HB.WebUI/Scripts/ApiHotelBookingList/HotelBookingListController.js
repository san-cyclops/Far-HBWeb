﻿var app = angular.module('HotelBookingModule', []);

app.service('hotelBookingService', function ($http) {

    this.getList = function (sub) { 

        return $http({
            method: "POST",
            data: sub,
            contentType: "application/json; charset=utf-8",
           url: "/api/HotelBooking/getBookingList"
          // url: "http://hotels.tag2travel.com:4585/api/HotelBooking/getBookingList"
        });


    };



    this.getDetailList = function (Reference) {

        return $http({
            method: "POST",
            data: Reference,
            contentType: "application/json; charset=utf-8",
            url: "/api/HotelBooking/getBookingDetailList?reference=" + Reference
           
            //url: "http://hotels.tag2travel.com:4585/api/HotelBooking/getBookingDetailList?reference=" + Reference
        });


    };


  
    
});

app.controller('HotelBooikingCtrl', function ($scope, $http, $window, hotelBookingService) {

   
    //$scope.start = new Date().toString("yyyy-MM-dd");
    //$scope.end = new Date().toString("yyyy-MM-dd");;
    $scope.statuslist = ['ALL', 'CONFIRMED', 'CANCELLED'];
    $scope.filterTypeOption = ['CHECKIN', 'CREATION'];
    $scope.from = 1;
    $scope.to = 100;
    $scope.clientReference = "";
    $scope.country = "";
    $scope.destination = "";
    $scope.hotel = "";
 
    $scope.status = "ALL";
    $scope.filterType = "CREATION";
   
    $scope.respData = [];
    $scope.htlData = [];
    $scope.showDetail = false;
    $scope.showBooking = false;


    $scope.getHotelBooking = function () {

            var sub = {
                start: $scope.start,
                end: $scope.end,
                status: $scope.status,
                filterType: $scope.filterType,
                from: $scope.from,
                to: $scope.to,
                clientReference: $scope.clientReference,
                country: $scope.country,
                destination: $scope.destination,
                hotel: $scope.hotel,

            };

            var getHotelBooking = hotelBookingService.getList(sub)


            getHotelBooking.then(function (d) {

            console.log("Succss");

            $scope.respData = d.data.bookings;

            if (d.data.bookings.bookings.length > 0)
            {
                if (!$scope.respData) {
                    $scope.showBooking = false;

                } else {
                    $scope.showBooking = true;
                }
            }
            else
            {
                $scope.showBooking = false;

            }


           
        }, function (error) {
            console.log("Oops! Something went wrong while fetching the data.");
        });
    }


    $scope.getHotelBookingDetails = function (Reference) {
        $scope.showDetail = false;

        var getHotelBookingDetails = hotelBookingService.getDetailList(Reference)


        getHotelBookingDetails.then(function (s) {

            console.log("Succss");

            $scope.htlData = s.data;

            if (!$scope.htlData) {
                $scope.showDetail = false;                
            } else {
                $scope.showDetail = true;
            }

           

        }, function (error) {
            console.log("Oops! Something went wrong while fetching the data.");
        });
    }

});