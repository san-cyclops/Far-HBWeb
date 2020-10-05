angular.module('app', ['gm.datepickerMultiSelect'])
.controller('cancellationCtrl', function ($http, $scope) {
    this.activeDate;
    this.roomID;
    this.selectedDates = [new Date().setHours(0, 0, 0, 0)];
    $scope.respData = [];

    this.identity = angular.identity;
   
    this.getData = function () {
        this.activeDate;
        if (this.activeDate == "") {
            alert("Please select Date.");
            return false;
        }

        var sub = {
            selectedDate: this.activeDate,
           
        };

        var post = $http({
            method: "POST",
            url: "/Home/BookingList",
            dataType: 'json',
            data: sub,
            headers: { "Content-Type": "application/json" }
        });

        post.then(function (d) {

           
            $scope.respData = d.data;
           
           // alert(this.respData[0].BookingNo);
            console.log("success");
        }, function (d) {

            alert("Oops!! Something went wrong.");

        });


    }

    this.cancelBooking = function (bNo,rId) {
        var sub = {
            bookingNo: bNo,
            roomId:rId,
            sdate: $scope.respData[0].DateFrom

        };

        var post = $http({
            method: "POST",
            url: "/Home/cancelBooking",
            dataType: 'json',
                data: sub,
            headers: { "Content-Type": "application/json" }
        });

        post.then(function (d) {
            console.log("success");
            alert(d.data);
            
            var sub1 = {
                selectedDate: $scope.respData[0].DateFrom,

            };

            var post = $http({
                method: "POST",
                url: "/Home/BookingList",
                dataType: 'json',
                data: sub1,
                headers: { "Content-Type": "application/json" }
            });

            post.then(function (d) {
                $scope.respData = d.data;
                console.log("success");
            }, function (d) {
                console.log("Oops!! Something went wrong.");               

            });

        }, function (d) {

            alert("Oops!! Something went wrong.");

        });


    }
});