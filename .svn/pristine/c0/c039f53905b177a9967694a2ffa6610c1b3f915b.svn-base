var app;

(function () {

    app = angular.module("loginApp", []);

})();

app.controller('loginController', function ($scope, $http, $window) {


    $scope.email = "";
    $scope.password = "";

    $scope.login = function () {

        var email = document.getElementById("validemail").value;
        var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

        if (!re.test(email)) {

            window.alert("Please enter the Valid EmailAddress");
            return false;

        }


        if (document.getElementById('validemail').value.length == 0) {
            alert("Please insert the Email!");
            e.preventDefault();
        }
        if (document.getElementById("password").value.length == 0) {
            alert("Please insert the password!");
            e.preventDefault();
        }



            sub = {
                email: $scope.email,
                password: $scope.password
            }

            var post = $http({
                method: "POST",
                url: "/Home/CheckAuth",
                dataType: 'json',
                accept: ' application/json',
                data: sub,
                headers: { "Content-Type": "application/json" }
            });
            post.then(function success(d) {
                var a = angular.fromJson(d.data)
                if (a == "0") {
                    $window.alert("Hi admin");
                    $window.open('/Home/HotelSearchIframe', '_top');
                }
                if (a == "1") {
                    $window.alert("Hi user");
                    $window.open('/Home/HotelSearch', '_top');
                } 
    
            }, function (error) {
                $window.alert("Oops!! Something went wrong!!!!.");
            });
        
    }
});
