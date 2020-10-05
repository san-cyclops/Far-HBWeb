
var app = angular.module('userForm', []);
app.controller('userController', function ($scope, $http, $window) {
    $scope.username = "";
    $scope.usertype = "";
    $scope.password = "";
    $scope.cpassword = "";
    $scope.rspData = "";
    $scope.hcode = "";

    $scope.change = function (IsActive) {
        if (!IsActive) {
            var sub1 = {

                UserName: this.username,


            };
            var post = $http({
                method: "POST",
                url: "/Home/GetUserDetails",
                dataType: 'json',
                data: sub1,
                headers: { "Content-Type": "application/json" }
            });

            console.log("suc");
            //  post.then   
                post.then(function (d) {
                $scope.rspData = d.data;
                $scope.username = d.data.UserName,
                $scope.password = d.data.Password,
                $scope.cpassword = d.data.Password,
                $scope.usertype = d.data.UserType,
                $scope.hcode = d.data.HotelCode
                console.log("Succss");

                $scope.loaded = true;
            }, function (error) {
                console.log("Oops! Something went wrong while fetching the data.");
            });
        };
    }
    $scope.save = function ()
    {


       var pass1 = document.getElementById("ppassword").value;
       var pass2 = document.getElementById("cpassword").value;

       if (pass1 != pass2) {
            alert("Passwords Do not match");
            document.getElementById("ppassword").style.borderColor = "#E34234";
            document.getElementById("cpassword").style.borderColor = "#E34234";
         
        }
        else {
            alert("Passwords Match!!!");
        }

     if ($scope.username == "" || $scope.usertype == "" || $scope.password == ""|| $scope.cpassword == "") {
            alert("Please fill out this field.");
            return false;


        }
        var sub = {
            UserName: $scope.username,
            UserType: $scope.usertype,
            Password: $scope.password,
            HotelCode: $scope.hcode,
        };
   
        var post = $http({
            method: "POST",
            url: "/Home/GetUserFormData",
            dataType: 'json',
            data: sub,
            headers: { "Content-Type": "application/json" }
        });

        post.then(function (d) {

            console.log("success");
            $window.alert(d.data);

        }, function (d) {
            $window.alert("Oops!! Something went wrong!!!!.");
        });


    }

});