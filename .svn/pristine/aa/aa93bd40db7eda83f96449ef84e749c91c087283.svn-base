app.controller("APIController", function ($scope, $window, $http) {


    
    $scope.saveSubs = function () {


        var sub = {
            UserName: $scope.username,
            Password: $scope.password
        };
        if ($scope.username === 'admin' && $scope.password === 'admin') {
            window.location.href = '/Home/HotelSearchRedirect';
        } else {
            $window.alert("User name or password wrong. please enter correct username or password.");
 
        }
    };

    
});

 



