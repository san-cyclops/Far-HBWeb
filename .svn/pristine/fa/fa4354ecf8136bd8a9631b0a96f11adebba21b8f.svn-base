var app = angular.module('mymodule', []);



app.service('studentService', function ($http) {
    

});

app.controller('ctrl', function ($scope, $q, $window, $http, studentService) {
     
    $scope.respData = [];
   
    $scope.rate = "";
   
    $scope.datax = $window.data;

    var x = $window.data.DepartureDate;
    var y = $window.data.ReturnDate;

    var myDepartureDate = new Date(parseInt(x.replace('/Date(', '')));
    var myReturnDate = new Date(parseInt(y.replace('/Date(', '')));


    $scope.Adults = $scope.datax.Adults1 + $scope.datax.Adults2 + $scope.datax.Adults3;
    $scope.Childrens = $scope.Children1 + $scope.Children2 + $scope.Children3;
    $scope.Name = "";
    $scope.HotelName="";
    $scope.HotelAddress="";
    $scope.HotelPhone="";
    $scope.DateFrom = $window.data.DepartureDate;
    $scope.DateTo = $window.data.ReturnDate;
    $scope.Pax = $scope.Adults + $scope.Childrens;
    $scope.Destination="";
    $scope.RoomType="";
    $scope.Board="";
    $scope.Price="";
    $scope.Description = "";
  


});
