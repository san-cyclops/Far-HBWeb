﻿
var app;

(function () {

    app = angular.module("BookingModule", ["ui.bootstrap"]);

})();

//angular.module('app', ['gm.datepickerMultiSelect'])

app.controller('MyController', function ($scope, $http, $window) {

    $scope.adult = "";
    $scope.child = "";
    $scope.roomId = "";
    $scope.datefrom = "";
    $scope.dateto = "";
    $scope.Adult1FirastName = "";
    $scope.Adult1LastName = "";
    $scope.Adult1Telephone = "";
    $scope.Adult1Email = "";
    $scope.Adult1NICNo = "";
    $scope.Adult1Address = "";
    $scope.Adult2FirastName = "";
    $scope.Adult2LastName = "";
    $scope.Adult3FirastName = "";
    $scope.Adult3LastName = "";
    $scope.Child1Name = "";
    $scope.Child1Age = "";
    $scope.Child2Name = "";
    $scope.Child2Age = "";
    $scope.Child3Name = "";
    $scope.Child3Age = "";
    $scope.Child4Name = "";
    $scope.Child4Age = "";

    $("#adults2").hide();
    $("#adults3").hide();
    $("#child1").hide();
    $("#child2").hide();
    $("#child3").hide();
    $("#child4").hide();
    $("#name1").hide();
    $("#name2").hide();
    $("#name3").hide();
    $("#name4").hide();

    $("#lblAge1").hide();
    $("#lblAge2").hide();
    $("#lblAge3").hide();
    $("#lblAge4").hide();

    $('#txtAdults1').on('change', function () {

        if (this.value == '1') {
            $("#adults1").show();
            $("#adults2").hide();
            $("#adults3").hide();

        }

        if (this.value == '2') {
            $("#adults1").show();
            $("#adults2").show();
            $("#adults3").hide();
        }
        if (this.value == '3') {
            $("#adults1").show();
            $("#adults2").show();
            $("#adults3").show();
        }
    });

    $('#txtChild1').on('change', function () {
        if (this.value == '0') {
            $("#child1").hide();
            $("#child2").hide();
            $("#child3").hide();
            $("#child4").hide();
            $("#name1").hide();
            $("#name2").hide();
            $("#name3").hide();
            $("#name4").hide();
            $("#lblAge1").hide();
            $("#lblAge2").hide();
            $("#lblAge3").hide();
            $("#lblAge4").hide();
            console.log("x");
        }
        if (this.value == '1') {
            $("#child1").show();
            $("#child2").hide();
            $("#child3").hide();
            $("#child4").hide();
            $("#name1").show();
            $("#name2").hide();
            $("#name3").hide();
            $("#name4").hide();
            $("#lblAge1").show();
            $("#lblAge2").hide();
            $("#lblAge3").hide();
            $("#lblAge4").hide();
            console.log("y");
        }

        if (this.value == '2') {
            $("#child1").show();
            $("#child2").show();
            $("#child3").hide();
            $("#child4").hide();
            $("#name1").show();
            $("#name2").show();
            $("#name3").hide();
            $("#name4").hide();
            $("#lblAge1").show();
            $("#lblAge2").show();
            $("#lblAge3").hide();
            $("#lblAge4").hide();
            console.log("z");
        }
        if (this.value == '3') {
            $("#child1").show();
            $("#child2").show();
            $("#child3").show();
            $("#child4").hide();
            $("#name1").show();
            $("#name2").show();
            $("#name3").show();
            $("#name4").hide();
            $("#lblAge1").show();
            $("#lblAge2").show();
            $("#lblAge3").show();
            $("#lblAge4").hide();
            console.log("w");
        }

        if (this.value == '4') {
            $("#child1").show();
            $("#child2").show();
            $("#child3").show();
            $("#child4").show();
            $("#name1").show();
            $("#name2").show();
            $("#name3").show();
            $("#name4").show();
            $("#lblAge1").show();
            $("#lblAge2").show();
            $("#lblAge3").show();
            $("#lblAge4").show();
            console.log("p");
        }


    });


    $scope.dateOptions = {
        formatYear: 'yyyy',
        startingDay: 1
    };

    var a = [];

    $scope.formats = ['MM/dd/yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];

    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };
    function convert(str) {
        var date = new Date(str),
            mnth = ("0" + (date.getMonth() + 1)).slice(-2),
            day = ("0" + date.getDate()).slice(-2);
        //  return [date.getFullYear(), mnth, day].join("/");
        return [mnth, day, date.getFullYear()].join("/");
    }
    $scope.change = function (IsActive) {
        if (!IsActive) {
            var sub1 = {

                RoomId: this.roomId,


            };
            var post1 = $http({
                method: "POST",
                url: "/Home/GetunAvailableDates",
                dataType: 'json',
                data: sub1,
                headers: { "Content-Type": "application/json" }
            });

            console.log("suc");

            post1.then(function (d) {

                if (d) {


                    for (var i = 0; i < d.data.length; i++) {
                        console.log(i);
                        console.log("dsfdfdfgf");
                        //   a.push(d.data[i].valueOf(Text).Text)

                    }
                }
                console.log("successsssss");

            }, function (d) {
                $window.alert("Oops!! Something went wrong!!!!.");
            });
            this.selectedDates = a;
            console.log("sucme");

        }
        else {

        }
    };


    $scope.save = function () {


        if ($scope.roomId == "") {
            alert("Please enter Room ID");
            return false;
        }
        if ($scope.datefrom == "") {
            alert("Please enter Date From");
            return false;
        }
        if ($scope.dateto == "") {
            alert("Please enter Date To");
            return false;
        }

        if ($scope.adult == 1) {
            if ($scope.Adult1FirastName == "") {
                alert("please enter adult1 first name");
                return false;
            }
            if ($scope.Adult1LastName == "") {
                alert("please enter adult1 last name");
                return false;
            }
            if ($scope.Adult1Telephone == "") {
                alert("please enter adult1 telephone number");
                return false;
            }
            if ($scope.Adult1Email == "") {
                alert("please enter adult1 email");
                return false;
            }
            var email = document.getElementById("validemail").value;
            var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

            if (!re.test(email)) {
                window.alert("Please enter the Valid EmailAddress");
                return false;
            }
            if ($scope.Adult1NICNo == "") {
                alert("please enter adult1 nic no");
                return false;
            }
            if ($scope.Adult1Address == "") {
                alert("please enter adult1 address");
                return false;
            }
        }

        if ($scope.adult == 2) {
            if ($scope.Adult1FirastName == "") {
                alert("please enter adult1 first name");
                return false;
            }
            if ($scope.Adult1LastName == "") {
                alert("please enter adult1 last name");
                return false;
            }
            if ($scope.Adult1Telephone == "") {
                alert("please enter adult1 telephone number");
                return false;
            }
            if ($scope.Adult1Email == "") {
                alert("please enter adult1 email");
                return false;
            }
            var email = document.getElementById("validemail").value;
            var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

            if (!re.test(email)) {
                window.alert("Please enter the Valid EmailAddress");
                return false;
            }
            if ($scope.Adult1NICNo == "") {
                alert("please enter adult1 nic no");
                return false;
            }
            if ($scope.Adult1Address == "") {
                alert("please enter adult1 adress");
                return false;
            }
            if ($scope.Adult2FirastName == "") {
                alert("please enter adult2 first name");
                return false;
            }
            if ($scope.Adult2LastName == "") {
                alert("please enter adult2 last name");
                return false;
            }

        }

        if ($scope.adult == 3) {
            if ($scope.Adult1FirastName == "") {
                alert("please enter adult1 first name");
                return false;
            }
            if ($scope.Adult1LastName == "") {
                alert("please enter adult1 last name");
                return false;
            }
            if ($scope.Adult1Telephone == "") {
                alert("please enter adult1 telephone number");
                return false;
            }
            if ($scope.Adult1Email == "") {
                alert("please enter adult1 email");
                return false;
            }
            var email = document.getElementById("validemail").value;
            var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

            if (!re.test(email)) {
                window.alert("Please enter the Valid EmailAddress");
                return false;
            }
            if ($scope.Adult1NICNo == "") {
                alert("please enter adult1 nic no");
                return false;
            }
            if ($scope.Adult1Address == "") {
                alert("please enter adult1 adress");
                return false;
            }
            if ($scope.Adult2FirastName == "") {
                alert("please enter adult2 first name");
                return false;
            }
            if ($scope.Adult2LastName == "") {
                alert("please enter adult2 last name");
                return false;
            }
            if ($scope.Adult3FirastName == "") {
                alert("please enter adult3 first name");
                return false;
            }
            if ($scope.Adult3LastName == "") {
                alert("please enter adult3 last name");
                return false;
            }
        }


        if ($scope.child == 0) {
            if ($scope.Adult1FirastName == "") {
                alert("please enter adult1 first name");
                return false;
            }
            if ($scope.Adult1LastName == "") {
                alert("please enter adult1 last name");
                return false;
            }
            if ($scope.Adult1Telephone == "") {
                alert("please enter adult1 telephone number");
                return false;
            }
            if ($scope.Adult1Email == "") {
                alert("please enter adult1 email");
                return false;
            }
            var email = document.getElementById("validemail").value;
            var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

            if (!re.test(email)) {
                window.alert("Please enter the Valid EmailAddress");
                return false;
            }
            if ($scope.Adult1NICNo == "") {
                alert("please enter adult1 nic no");
                return false;
            }
            if ($scope.Adult1Address == "") {
                alert("please enter adult1 adress");
                return false;
            }
        }

        if ($scope.child == 1) {
            if ($scope.Adult1FirastName == "") {
                alert("please enter adult1 first name");
                return false;
            }
            if ($scope.Adult1LastName == "") {
                alert("please enter adult1 last name");
                return false;
            }
            if ($scope.Adult1Telephone == "") {
                alert("please enter adult1 telephone number");
                return false;
            }
            if ($scope.Adult1Email == "") {
                alert("please enter adult1 email");
                return false;
            }
            var email = document.getElementById("validemail").value;
            var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

            if (!re.test(email)) {
                window.alert("Please enter the Valid EmailAddress");
                return false;
            }
            if ($scope.Adult1NICNo == "") {
                alert("please enter adult1 nic no");
                return false;
            }
            if ($scope.Adult1Address == "") {
                alert("please enter adult1 adress");
                return false;
            }
            if ($scope.Child1Name == "") {
                alert("please enter child1 name");
                return false;
            }
            if ($scope.Child1Age == "") {
                alert("please enter child1 age");
                return false;
            }
        }
        if ($scope.child == 2) {
            if ($scope.Adult1FirastName == "") {
                alert("please enter adult1 first name");
                return false;
            }
            if ($scope.Adult1LastName == "") {
                alert("please enter adult1 last name");
                return false;
            }
            if ($scope.Adult1Telephone == "") {
                alert("please enter adult1 telephone number");
                return false;
            }
            if ($scope.Adult1Email == "") {
                alert("please enter adult1 email");
                return false;
            }
            var email = document.getElementById("validemail").value;
            var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

            if (!re.test(email)) {
                window.alert("Please enter the Valid EmailAddress");
                return false;
            }
            if ($scope.Adult1NICNo == "") {
                alert("please enter adult1 nic no");
                return false;
            }
            if ($scope.Adult1Address == "") {
                alert("please enter adult1 adress");
                return false;
            }
            if ($scope.Child1Name == "") {
                alert("please enter child1 name");
                return false;
            }
            if ($scope.Child1Age == "") {
                alert("please enter child1 age");
                return false;
            }
            if ($scope.Child2Name == "") {
                alert("please enter child2 name");
                return false;
            }
            if ($scope.Child2Age == "") {
                alert("please enter child2 age");
                return false;
            }
        }
        if ($scope.child == 3) {
            if ($scope.Adult1FirastName == "") {
                alert("please enter adult1 first name");
                return false;
            }
            if ($scope.Adult1LastName == "") {
                alert("please enter adult1 last name");
                return false;
            }
            if ($scope.Adult1Telephone == "") {
                alert("please enter adult1 telephone number");
                return false;
            }
            if ($scope.Adult1Email == "") {
                alert("please enter adult1 email");
                return false;
            }
            var email = document.getElementById("validemail").value;
            var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

            if (!re.test(email)) {
                window.alert("Please enter the Valid EmailAddress");
                return false;
            }
            if ($scope.Adult1NICNo == "") {
                alert("please enter adult1 nic no");
                return false;
            }
            if ($scope.Adult1Address == "") {
                alert("please enter adult1 adress");
                return false;
            }
            if ($scope.Child1Name == "") {
                alert("please enter child1 name");
                return false;
            }
            if ($scope.Child1Age == "") {
                alert("please enter child1 age");
                return false;
            }
            if ($scope.Child2Name == "") {
                alert("please enter child2 name");
                return false;
            }
            if ($scope.Child2Age == "") {
                alert("please enter child2 age");
                return false;
            }
            if ($scope.Child3Name == "") {
                alert("please enter child3 name");
                return false;
            }
            if ($scope.Child3Age == "") {
                alert("please enter child3 age");
                return false;
            }
        }
        if ($scope.child == 4) {
            if ($scope.Adult1FirastName == "") {
                alert("please enter adult1 first name");
                return false;
            }
            if ($scope.Adult1LastName == "") {
                alert("please enter adult1 last name");
                return false;
            }
            if ($scope.Adult1Telephone == "") {
                alert("please enter adult1 telephone number");
                return false;
            }
            if ($scope.Adult1Email == "") {
                alert("please enter adult1 email");
                return false;
            }
            var email = document.getElementById("validemail").value;
            var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

            if (!re.test(email)) {
                window.alert("Please enter the Valid EmailAddress");
                return false;
            }
            if ($scope.Adult1NICNo == "") {
                alert("please enter adult1 nic no");
                return false;
            }
            if ($scope.Adult1Address == "") {
                alert("please enter adult1 adress");
                return false;
            }
            if ($scope.Child1Name == "") {
                alert("please enter child1 name");
                return false;
            }
            if ($scope.Child1Age == "") {
                alert("please enter child1 age");
                return false;
            }
            if ($scope.Child2Name == "") {
                alert("please enter child2 name");
                return false;
            }
            if ($scope.Child2Age == "") {
                alert("please enter child2 age");
                return false;
            }
            if ($scope.Child3Name == "") {
                alert("please enter child3 name");
                return false;
            }
            if ($scope.Child3Age == "") {
                alert("please enter child3 age");
                return false;
            }
            if ($scope.Child4Name == "") {
                alert("please enter child4 name");
                return false;
            }
            if ($scope.Child4Age == "") {
                alert("please enter child4 age");
                return false;
            }
        }
        //else {
        //    alert("Succesfully Saved!");
        //    return false;
        //}
        $scope.DateFrom = convert($scope.datefrom);
        $scope.DateTo = convert($scope.dateto);

        var sub = {

            RoomId: this.roomId,
            DateFrom: $scope.DateFrom,
            DateTo: $scope.DateTo,
            Adult1FirastName: $scope.Adult1FirastName,
            Adult1LastName: $scope.Adult1LastName,
            Adult1Telephone: $scope.Adult1Telephone,
            Adult1Email: $scope.Adult1Email,
            Adult1NICNo: $scope.Adult1NICNo,
            Adult1Address: $scope.Adult1Address,
            Adult2FirastName: $scope.Adult2FirastName,
            Adult2LastName: $scope.Adult2LastName,
            Adult3FirastName: $scope.Adult3FirastName,
            Adult3LastName: $scope.Adult3LastName,
            Child1Name: $scope.Child1Name,
            Child1Age: $scope.Child1Age,
            Child2Name: $scope.Child2Name,
            Child2Age: $scope.Child2Age,
            Child3Name: $scope.Child3Name,
            Child3Age: $scope.Child3Age,
            Child4Name: $scope.Child4Name,
            Child4Age: $scope.Child4Age,
        };


        var post = $http({
            method: "POST",
            url: "/Home/GetRoomBookingDetails",
            dataType: 'json',
            data: sub,
            headers: { "Content-Type": "application/json" }
        });

        post.then(function (d) {

            console.log("success");
            $window.alert(d.data);
            location.reload();

        }, function (d) {
            $window.alert("Oops!! Something went wrong!!!!.");
        });

    }
});

