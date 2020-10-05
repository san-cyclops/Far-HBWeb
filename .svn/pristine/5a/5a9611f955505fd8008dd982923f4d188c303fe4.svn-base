app.controller("APIController", function ($scope,$window, $http, APIService) {
 
    $scope.datax = $window.data;
    getAll();
    $scope.overlay = true;

    function getAll() {
        var sub = $scope.datax.Des;
        var servCall = APIService.hotelavailability(sub);
        

        servCall.then(function (d) {
            $scope.overlay = false;
            $scope.respData = d.hotels;
        }, function (error) {
            console.log("Oops! Something went wrong while fetching the data.");
        });
    }

    $scope.createArray = function (n) {
        return new Array(n);
    }


    $scope.setTab = function (hotelcode, des, departureDate, returnDate, rooms, occupancy) {
        //$scope.HotelCode = hotelcode;
        //$scope.Des = des;
        //$scope.DepartureDate = departureDate;
        //$scope.ReturnDate = returnDate;
        //$scope.Rooms = rooms;
        //$scope.Occupancy = occupancy;

        mode = "edit";

        //debugger;
        //var url = '@Html.Raw(Url.Action("Hotel", "Home", new { HotelCode = "__hotelCode__", Destination = "__destination__", DepartureDate = "__departureDate__", ReturnDate = "__returnDate__",Rooms = "__rooms__",Occupancy = "__occupancy__"}))';
        //var params = url.replace('__hotelCode__', hotelcode).replace('__destination__', des).replace('__departureDate__', departureDate).replace('__returnDate__', returnDate).replace('__rooms__', rooms).replace('__occupancy__', occupancy);
        //window.location.href = params;
        $scope.x = "0";
 

     

        var url = 'Hotel';
        url += '?hotelCode=' + hotelcode + '&Rooms=' + '1' + '&Destination=' + des + '&DepartureDate=' + departureDate + '&ReturnDate=' + returnDate  + '&Adults1=' + '1' + '&Children1=' + '0' + '&C1Age1=' + '0' + '&C1Age2=' + '0' + '&C1Age4=' + '0' + '&Adults2=' + '0' + '&Children2=' + '0' + '&C2Age1=' + '0' + '&C2Age2=' + '0' + '&C2Age3=' + '0' + '&C2Age4=' + '0' + '&Adults3=' + '0' + '&C3Age1=' + '0' + '&C3Age2=' + '0' + '&C3Age3=' + '0' + '&C3Age4=' + '0';
        //window.location.href = url;
        

        window.open(url, '_blank' // <- This is what makes it open in a new window.
);
        //load('@Url.Action("Hotel", "Home")', { HotelCode: hotelcode, Destination: des, DepartureDate: departureDate, ReturnDate: returnDate, Rooms: rooms, Occupancy: occupancy });
    }
});


 
