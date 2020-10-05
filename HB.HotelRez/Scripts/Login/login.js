var app;

(function () {

    app = angular.module("loginApp", []);

})();



app.controller('loginController', function ($scope, $http, $window) {


    $scope.username = "";
    $scope.password = "";

    $scope.loginClick = function () {

        if (document.getElementById('inputName').value.length == 0) {
            alert("Please insert the username!");
            e.preventDefault();
        }
        else if (document.getElementById("inputPassword").value.length == 0) {
            alert("Please insert the password!");
            e.preventDefault();
        }

        else { 


        sub = {
            username:$scope.username,
            password:$scope.password
        }

        var post = $http({
            method: "POST",
            url: "/Home/login",
            dataType: 'json',
            accept:' application/json',
            data: sub,
            headers: { "Content-Type": "application/json" }
        });
        post.then(function success(d) {
            if (d.data == 0)
            {
                $window.alert("Hi admin");
                $window.open('/Home/Dashboard','_top');
            }
            else if (d.data == 1)
            {
                $window.alert("Hi user");
                $window.open('/Home/Dashboard','_top');
            }
            else if (d.data == 2) {
                $window.alert("Hi Guest");
                $window.open('/Home/Dashboard', '_top');
            }
            
            else{
                $window.alert(d.data);
                e.preventDefault();
            }
            

        }, function (error) {
            $window.alert("Oops!! Something went wrong!!!!.");
        });
        }
    }

});