
var app;

(function () {

    app = angular.module("RoomMaster", []);

})();

app.service('RoomService', function ($http) {

    this.setRoomDetails = function (sub) {

        return $http({
            data: sub,
            method: "post",
            contentType: "application/json; charset=utf-8",
            url: "/home/GetHotelRezData",

        });


    };
});

app.controller('demoController', function ($scope, $http, $window) {


    $scope.hname = "";
    $scope.address = "";
    $scope.roomid = "";
    $scope.refference = "";
    $scope.board = "";
    $scope.room = "";
    $scope.aminities = "";
    $scope.amitype = "";
    $scope.name = "";
    $scope.distance = "";
    $scope.price = "";
    $scope.aminitylist = [];


    $scope.roomtype = ["Deluxe Room", "Superior Room", "Executive Room", "Pacific Room", " Pacific Suite", "Deluxe Suite", "Executive Suite", "Presidential Suite"];
    $scope.aminity = ["Balcony", "Cable channels", "Telephone", "Flat-screen TV", "Iron", "Suit press", "Ironing facilities", "Sitting area", "Heating", "Sofa", "Soundproof", "Wardrobe/Closet", "Cleaning products", "Hairdrye", "WiFi", "Free toiletries", "Shower", "Toilet", "Bathroom", "Slippers", "Bathtub or shower", "Guest bathroom", "Bidet", "Toilet paper", "Dining area", "Electric kettle", "Barbecue", "Dining table", "Outdoor furniture", "Soundproof", "Outdoor dining area", "Wake-up service", "Towels/Sheets", "Linens", "Satellite channels", "Suit press", "Outdoor furniture", "Outdoor dining area", "Free Parking", "Wardrobe/Closet", "Non-smoking Rooms", "Airport Shuttle", "Family Rooms", "Tour Desk", "Room Service", "Very Good Breakfast"];
    $scope.btype = ["Full Board", "Half Board", "Room Only"];
    $scope.atype = ["Free", "Paid"];

   

    var p = 0;

    $scope.add1 = function () {
        if ($scope.aminities == "") {
            alert("Please select Aminities.");
            return false;
        }
        if ($scope.amitype == "") {
            alert("Please Aminity Type.");
            return false;
        }

        if (p == 0) {

            $scope.item1 = [{
                aminities: $scope.aminities,
                amitype: $scope.amitype,
            }];
        }
        else {

            $scope.item1.push({
                aminities: $scope.aminities,
                amitype: $scope.amitype,
            });
        }

        p++;

    };

    $scope.removeitem1 = function (index) {
        $scope.item1.splice(index, 1);
    };

    var x = 0;

    $scope.add = function () {
        if ($scope.name == "") {
            alert("Please enter nearby place.");
            return false;
        }
        if ($scope.distance == null) {
            alert("Please enter distance.");
            return false;
        }
        console.log($scope.name);

        if (x == 0) {

            $scope.items = [{
                name: $scope.name,
                distance: $scope.distance

            }];
        }
        else {

            $scope.items.push({

                name: $scope.name,
                distance: $scope.distance
            });

            console.log("dd");
        }

        x++;
    };

    $scope.removeitems = function (index) {
        $scope.items.splice(index, 1);
    };

    $scope.save = function () {

        if ($scope.address == "") {
            alert("Please enter Address.");
            return false;
        }
        if ($scope.roomid == "") {
            alert("Please enter Room ID.");
            return false;
        }
        if ($scope.reference == "") {
            alert("Please enter Reference.");
            return false;
        }
         if ($scope.board == "") {
            alert("Please select Board Type.");
            return false;
        }
       if ($scope.room == "") {
            alert("Please select Room Type.");
            return false;
        }
        if ($scope.price == 0) {
            alert("Please enter Price.");
            return false;
        }
        if ($scope.price < 0) {
            alert("Please enter valid Price.");
            return false;
        }

        if ($scope.aminities == "") {
            alert("Please select Aminities.");
            return false;
        }
        if ($scope.name == "") {
            alert("Please enter Nearby Place.");
            return false;
        }
        if ($scope.distance == "") {
            alert("Please enter Distance.");
            return false;
        }

        if ($scope.amitype == "") {
            alert("Please select Aminity Type.");
            return false;
        }
        //else  {

        //    alert("Successfully Saved!");
        //}
        
    //}
    var sub = {
        Address: $scope.address,
        RoomId: $scope.roomid,
        Refference: $scope.refference,
        BoardType: $scope.board,
        RoomType: $scope.room,
        Price: $scope.price,
        Aminities: $scope.aminities,
        NearbyName: $scope.name,
        NearbyDistance: $scope.distance,
        Aminitylist: $scope.item1,
        NearByPlaces: $scope.items

    };

    console.log($scope.aminitylist);
    console.log($scope.items);

    var getRoomDetails = "";
    // getRoomDetails = RoomService.setRoomDetails(sub);

    var post = $http({
        method: "POST",
        url: "/Home/GetHotelRezData",
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

    $scope.recall = function () {
        var sub = {
            RoomId: $scope.roomid,
        };

        var post = $http({
            method: "POST",
            url: "/Home/recallRoomMaster",
            dataType: 'json',
            data: sub,
            headers: { "Content-Type": "application/json" }
        });

        post.then(function (d) {
            console.log("success");
            //alert(d.data);
            $scope.address = d.data.Address;
            $scope.roomid = d.data.RoomId;
            $scope.refference = d.data.Refference;
            $scope.board = d.data.BoardType;
            $scope.room = d.data.RoomType;
            $scope.price = parseInt(d.data.Price);

            var sub1 = {
                RoomId: $scope.roomid,

            };
            var post = $http({
                method: "POST",
                url: "/Home/getNearByPlaces",
                dataType: 'json',
                data: sub1,
                headers: { "Content-Type": "application/json" }
            });

            post.then(function (d) {
                console.log("success");

                $scope.items = [];
                for (var i = 0; i < d.data.length; i++) {
                    $scope.items.push({

                        name: d.data[i].NearbyName,
                        distance: d.data[i].NearbyDistance
                    });

                    console.log("dd");

                }
                
            }, function (d) {

                alert("Oops!! Something went wrong.");

            });
            
          
            var post = $http({
                method: "POST",
                url: "/Home/getAminities",
                dataType: 'json',
                data: sub,
                headers: { "Content-Type": "application/json" }
            });

            post.then(function (d) {
                console.log("success");

                $scope.item1 = [];
                for (var i = 0; i < d.data.length; i++) {
                    $scope.item1.push({
                        aminities: d.data[i].Aminities,
                        amitype: d.data[i].AminityType
                    });

                    console.log("dd");

                }

            }, function (d) {

                alert("Oops!! Something went wrong.");

            });


        }, function (d) {

            alert("Oops!! Something went wrong.");

        });


    }
});




