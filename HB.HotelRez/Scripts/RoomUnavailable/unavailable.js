﻿angular.module('app', ['gm.datepickerMultiSelect'])
.controller('roomUnavailableCtrl', function ($http,$windows) {
    this.activeDate;
    this.roomId = "";
    this.selectedDates = [new Date().setHours(0, 0, 0, 0)];
   // this.selectedDates = [1519669800000, 1520533800000, 1520965800000, 1521397800000, 1522002600000];
    this.identity = angular.identity;

    this.removeFromSelected = function (dt) {
        this.selectedDates.splice(this.selectedDates.indexOf(dt), 1);
        console.log("Succss");
   
    }
    this.saveDetails = function () {

        if (this.roomId == "") {
            alert("Please select room ID.");
            return false;
        }

        var sub = {
            RoomID: this.roomId,
            UnavailableDates: this.selectedDates,
        };

        var post = $http({
            method: "POST",
            url: "/Home/SaveToDatabase",
            dataType: 'json',
            data: sub,
            headers: { "Content-Type": "application/json" }
        });

        post.then(function (d) {

            console.log("success");
            $windows.alert(d.data);

        }, function (d) {

            alert("Oops!! Something went wrong.");

        });
        
    }

    this.loadUnavailableDatesList = function () {

        var sub = {
            RoomID: this.roomId,
        };

        var post = $http({
            method: "POST",
            url: "/Home/getUnavailableDateLst",
            dataType: 'json',
            data: sub,
            headers: { "Content-Type": "application/json" }
        });
        console.log("success");
        var a = [];
        post.then(function (d) {
            if (d) {
              

                for (var i = 0; i < d.data.length; i++) {
                   
                    a.push(d.data[i].valueOf(Text).Text)  
                    
                }               
            }
            console.log("success");

        }, function (d) {

            $window.alert("Oops!! Something went wrong.");

        });

        this.selectedDates=a;

    }
});

    

    
