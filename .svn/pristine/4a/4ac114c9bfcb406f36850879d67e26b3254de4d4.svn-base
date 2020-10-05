var app = angular.module('myApp', []);
app.controller("APIController", function ($scope) {

   
    $scope.softName = function () {
        $scope.sortExpression = "Name";
    };
    $scope.softPrice = function () {
        $scope.sortExpression = "Price";
    };


    $scope.mySortFunction = function (item) {
        if (isNaN(item[$scope.sortExpression]))
            return item[$scope.sortExpression];
        return parseInt(item[$scope.sortExpression]);
    }
});