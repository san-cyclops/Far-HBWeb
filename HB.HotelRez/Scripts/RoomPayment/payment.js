﻿var app;
(function () {

    app = angular.module("RoomPayment", ['ui.bootstrap']);

})();
app.service('RoomService', function ($http) {

    this.setRoomDetails = function (sub) {

        return $http({
            data: sub,
            method: "post",
            contentType: "application/json; charset=utf-8",
            url: "/home/PostHotelPaymentData",


        });


    }; post.then(function (d) {

        console.log("success");
        $window.location.reload(true);
    },
        function (d) {
            $window.alert("Oops!! Something went wrong!!!!.");
        });

});


app.controller('payController', function ($scope, $http) {


    $scope.bno = "";
    //$scope.roomid = "";
    $scope.total = 0;
    $scope.tax = 0;
    $scope.amount = 0;

    $scope.rid = "";
    $scope.booking = "";
    $scope.name = "";
    $scope.telephoneno = "";
    $scope.email = "";
    $scope.creditno = "";
    $scope.BookingNo = "";
    $scope.RoomID = "";
    $scope.DateFrom = "";
    $scope.DateTo = "";
    $scope.Adult1FirstName = "";
    $scope.Adult1Telephone = "";
    $scope.Adult1Email = "";
    $scope.Adult1NICNo = "";






    //$scope.bno = ['b1', 'b2', 'b3', 'b4', 'b5'];
    //$scope.roomid = ['r001','r002','r003','r004','r005'];

    //start paging
    $scope.filteredTodos = [];
    $scope.currentPage = 1;
    $scope.numPerPage = 10;
    $scope.maxSize = 5;
    //End paging

    function roombookingdetails() {

        $scope.updatedata = "";
        var post = $http({
            method: "POST",
            url: "/Home/GetBookingDetails",
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        });

        post.then(function (d) {

            console.log("success");
            $scope.updatedata = d.data;
    

        },
        function (d) {
            $window.alert("Oops!! Something went wrong!!!!.");
        });
    }

    roombookingdetails();

    //Get dataCount
    //function roombookingdata() {

    //    $scope.datacount = "";
    //    var post = $http({
    //        method: "POST",
    //        url: "/Home/GetBookingDetailsCount",
    //        dataType: 'json',
    //        headers: { "Content-Type": "application/json" }
    //    });

    //    post.then(function (d) {

    //        console.log("success");

    //        $scope.datacount = d.data;

    //    },
    //    function (d) {
    //        $window.alert("Oops!! Something went wrong!!!!.");
    //    });
    //}




    $scope.numPages = function () {
        return Math.ceil($scope.updatedata.length / $scope.numPerPage);

    };

    $scope.$watch('currentPage + numPerPage', function () {
        var begin = (($scope.currentPage - 1) * $scope.numPerPage)
        end = begin + $scope.numPerPage;

        $scope.filteredTodos = $scope.updatedata.slice(begin, end);
    });

    $scope.paid = function () {


        if ($scope.rid == "")
        {
            alert("Please select Room ID.");
            return false;
        }
        if ($scope.amount == "")
        {
            alert("Please enter Amount.");
            return false;
        }
        if ($scope.amount <= 0) {
            alert("Please enter valid Amount.");
            return false;
        }
        if ($scope.tax == "")
        {
            alert("Please enter Tax.");
            return false;
        }
        if ($scope.tax < 0) {
            alert("Please enter valid Tax.");
            return false;
        }
        if ($scope.total == "")
        {
            alert("Please enter Total.");
            return false;
        }
        if ($scope.total <= 0) {
            alert("Please enter valid Total Amount.");
            return false;
        }


        var sub = {
            BookingNo: $scope.bno,
            Amount: $scope.amount,
            Tax: $scope.tax,
            Total: $scope.total,
            RoomID: $scope.rid,
            Booking: $scope.booking,
            Name: $scope.name,
            TelephoneNo: $scope.telephoneno,
            Email: $scope.email,
            CreditCardNo: $scope.creditno,
        }


        var post = $http({
            method: "POST",
            url: "/Home/PostHotelPaymentData",
            dataType: 'json',
            data: sub,
            headers: { "Content-Type": "application/json" }
        });

        post.then(function (d) {

            console.log("success");
            $window.alert(d.data);
            location.reload();
            

            
        },
        function (d) {
            $window.alert("Oops!! Something went wrong!!!!.");
        });


    }



    $scope.processData = function (updatedata) {
        console.log(updatedata)

        $scope.bno = updatedata.BookingNo;
        $scope.amount = updatedata.Price;
        $scope.rid = updatedata.RoomID;
        $scope.name = updatedata.Adult1FirstName;
        $scope.telephoneno = updatedata.Adult1Telephone;
        $scope.email = updatedata.Adult1Email;
        $scope.creditno = updatedata.Adult1NICNo;

        $scope.tax = (($scope.amount) * 0.03);
        $scope.total = (amount + tax);

    }

});




