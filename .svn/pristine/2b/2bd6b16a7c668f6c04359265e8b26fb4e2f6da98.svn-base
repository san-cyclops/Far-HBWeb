var app;

(function () {

    app = angular.module("HotelSupplier", []);

})();


app.controller('supplierController', function ($scope, $http, $window) {


    $scope.code = "";
    $scope.name = "";
    $scope.address = "";
    $scope.srating = "";
    $scope.cperson = "";
    $scope.owner = "";
    $scope.email = "";
    $scope.telephone = "";
    $scope.long = "";
    $scope.lat = "";
    $scope.description = "";
    $scope.files = "";
    //$scope.isinternetavailabe = "";
    $scope.selection = "";
    $scope.internettype = "";
    $scope.where = "";
    $scope.parkavailable = "";
    $scope.parkingType = "";
    $scope.reservation = "";
    $scope.price = "";
    $scope.cyes = "";
    $scope.cno = "";
    $scope.pets = "";
    $scope.language = "";
    $scope.alanguage = "";
    $scope.checkintime = "";
    $scope.checkouttime = "";
    $scope.UrlList = "";
    $scope.images = [];
    $scope.otherlanguages = [];
    $scope.var1 = "";
    $scope.var2 = "";
    $scope.inputs = "";
    $scope.parkingareas = "";
    $scope.files = [];

    $scope.anlanguage = ["Albanian", " Hindi", "Korean", "Polish", "Spanish", "Arabic", "French", "Hmong", "Laotian", "Portuguese", "Tagalog", "Armenian", "German", "Italian", "Lithuanian", "Punjabi", "Thai", "Bengali", "Greek", "Japanese", "Malay", "Romanian", "Turkish", "Burmese", "Haitian", "Creole", "Karen", "Mandarin", "Russian", "Vietnamese", "Cantonese", "Hebrew", "Khmer", "Nepali", "Somali"];
    $scope.inputs = ["Yes Free", "Yes Paid", "No"];

    $scope.save = function () {

        //var answer0 = document.getElementById("ssrating");
        //$scope.srating = answer0[answer0.selectedIndex].value;

        //var answer = document.getElementById("InternetAvailable");
        //$scope.isinternetavailabe = answer[answer.selectedIndex].value;

        //var answer1 = document.getElementById("TypeOfInternet");
        //$scope.internettype = answer1[answer1.selectedIndex].value;

        //var answer2 = document.getElementById("WhereIsInternet");
        //$scope.where = answer2[answer2.selectedIndex].value;

        //var answer3 = document.getElementById("IsParkingAvailable");
        //$scope.parkavailable = answer3[answer3.selectedIndex].value;

        //var answer4 = document.getElementById("IsReservationNeeded");
        //$scope.reservation = answer4[answer4.selectedIndex].value;

        //var answer6 = document.getElementById("petsAllowed");
        //$scope.pets = answer6[answer6.selectedIndex].value;

        if (document.getElementById('parkingTypePrivate').checked) { $scope.parkingType = document.getElementById('parkingTypePrivate').value; }
        if (document.getElementById('parkingTypeOnSite').checked) { $scope.parkingType = document.getElementById('parkingTypeOnSite').value; }

        if (document.getElementById('ChildrenAllowed').checked) { $scope.cyes = document.getElementById('ChildrenAllowed').value; }
        if (document.getElementById('ChildrenNotAllowed').checked) { $scope.cyes = document.getElementById('ChildrenNotAllowed').value; }

        $scope.var1 = document.getElementById("input1").value;
        $scope.var2 = document.getElementById("input2").value;

        if ($scope.name == "") {
            alert("please enter Hotel Name!");
            return false;
        }
        if ($scope.address == "") {
            alert("please enter Hotel Address!");
            return false;
        }
        if ($scope.srating == "") {
            alert("please enter Star Rating!");
            return false;
        }
        if ($scope.cperson == "") {
            alert("please enter Contact Person!");
            return false;
        }
        if ($scope.owner == "") {
            alert("please enter Owner Name!");
            return false;
        }
        if ($scope.email == "") {
            alert("please enter Email!");
            return false;
        }
        if ($scope.telephone == null) {
            alert("please enter Telephone Number!");
            return false;
        }
        if ($scope.long == "") {
            alert("please enter Longitude!");
            return false;
        }
        if ($scope.long <= 0) {
            alert("please enter valid Longitude!");
            return false;
        }
        if ($scope.lat == "") {
            alert("please enter Latitude!");
            return false;
        }
        if ($scope.lat <= 0) {
            alert("please enter valid Latitude!");
            return false;
        }
        if ($scope.description == "") {
            alert("please enter Description!");
            return false;
        }

        if ($scope.selection == "Yes Free") {

            if ($scope.internettype == "") {
                alert("please select internet availability!");
                return false;
            }
            if ($scope.where == "") {
                alert("please select where!");
                return false;
            }
        }
        if ($scope.selection == "Yes Paid") {

            if ($scope.internettype == "") {
                alert("please select internet availability!");
                return false;
            }
            if ($scope.where == "") {
                alert("please select where!");
                return false;
            }
        }
        
        if ($scope.parkavailable == "Yes Free") {
            if ($scope.reservation == "") {
                alert("please select parking details!");
                return false;
            }
        }
        if ($scope.parkavailable == "Yes Paid") {
            if ($scope.reservation == "") {
                alert("please select parking details!");
                return false;
            }

            if ($scope.price == "") {
                alert("please enter price!");
                return false;
            }
            if ($scope.price <= 0) {
                alert("please enter valid price!");
                return false;
            }
        }

        //if ($scope.parkingareas == "") {
        //    alert("please select parking options!");
        //    return false;
        //}
        if ($scope.parkingType == "") {
            alert("please select parking details");
            return false;
        }
        //if ($scope.reservation == "") {
        //    alert("please select parking details");
        //    return false;
        //}

        if ($scope.cyes == "") {
            alert("please select whether you acommodate children or not!");
            return false;
        }
        if ($scope.pets == "") {
            alert("please select whether you allow pets or not!");
            return false;
        }
        if ($scope.alanguage == "") {
            alert("please select a language!");
            return false;
        }

        if ($scope.var1 == "") {
            alert("please Select Checkin Time!");
            return false;
        }
        if ($scope.var2 == "") {
            alert("please Select Checkout Time!");
            return false;
        }

        var email = document.getElementById("validemail").value;
        var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;

        if (!re.test(email)) {
            window.alert("Please enter the Valid EmailAddress");
            return false;
        }
        //else {
        //    alert("Saved Succesfully!");
        //}

        //if ($scope.Code == "" || $scope.name == "" || $scope.address == "" || $scope.srating == "" || $scope.cperson == "" || $scope.owner == "" || $scope.email == "" || $scope.telephone == "" || $scope.long == "" || $scope.lat == "" ||
        //    $scope.description == "" || $scope.files == "" || $scope.internetavailabe == "" || $scope.internettype == "" || $scope.where == "" || $scope.parkavailable == "" || $scope.private == "" || $scope.onsite == "" || $scope.reservation == "" || $scope.price == ""
        //    || $scope.cyes == "" || $scope.cno == "" || $scope.pets == "" || $scope.language == "" || $scope.alanguage == "" || $scope.checkintime == "" || $scope.checkouttime == "") {
        //    alert("Please fill out this field.");
        //    return false;

        //}


        var sub = {
            HotelCode: $scope.code,
            HotelName: $scope.name,
            Address: $scope.address,
            StarRating: $scope.srating,
            Contactperson: $scope.cperson,
            OwnerName: $scope.owner,
            Email: $scope.email,
            Telephone: $scope.telephone,
            Long: $scope.long,
            Lat: $scope.lat,
            Description: $scope.description,
            IsInternetAvailable: $scope.isinternetavailabe,
            TypeOfInternet: $scope.internettype,
            WhereIsInternet: $scope.where,
            IsParkAvailable: $scope.parkavailable,
            ParkingPrivateOrOnSite: $scope.parkingType,
            ReservationNeedForParking: $scope.reservation,
            PriceForParking: $scope.price,
            AccomodateChildren: $scope.cyes,
            PetsAllowed: $scope.pets,
            SpeakingLanguage: $scope.language,
            OtherLanguages: $scope.otherlanguages,
            CheckInTime: $scope.var1,
            CheckOutTime: $scope.var2,
            UrlList: $scope.images,
        };


        //var getHotelSupplierDetails = "";


        var post = $http({
            method: "POST",
            url: "/Home/GetHotelSupplierData",
            dataType: 'json',
            accept: ' application/json',
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

    };

    $scope.parkingareas = '1';


    $scope.isCheckboxSelected = function (index) {
        return index === $scope.parkingareas;
    }


    $scope.Children = '1';


    $scope.isCheckboxSelected = function (index) {
        return index === $scope.Children;
    }

    var x = 0;

    $scope.Add = function () {
        if ($scope.alanguage == "") {
            alert("Please fill out this field.");
            return false;
        }

        console.log($scope.alanguage);

        if (x == 0) {
            $scope.otherlanguages.push($scope.alanguage);
            $scope.items = [{
                alanguage: $scope.alanguage,


            }];

        }
        else {
            $scope.otherlanguages.push($scope.alanguage);
            $scope.items.push({
                alanguage: $scope.alanguage,
            });

            console.log("dd");

        }

        x++;

    };


    $scope.removeitems = function (index) {
        $scope.items.splice(index, 1);
    };



    function previewImages() {

        var preview = document.querySelector('#preview');

        if (this.files) {
            [].forEach.call(this.files, readAndPreview);
        }

        function readAndPreview(file) {

            // Make sure `file.name` matches our extensions criteria
            if (!/\.(jpe?g|png|gif)$/i.test(file.name)) {
                return alert(file.name + " is not an image");
            } // else...

            var reader = new FileReader();

            reader.addEventListener("load", function () {
                var image = new Image();
                image.height = 100;
                image.title = file.name;
                image.src = this.result;
                $scope.foo = image.src;
                $scope.images.push($scope.foo);
                preview.appendChild(image);
            }, false);

            reader.readAsDataURL(file);

        }

    }

    document.querySelector('#file-input').addEventListener("change", previewImages, false);



});


app.directive('ngFileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.ngFileModel);
            var isMultiple = attrs.multiple;
            var modelSetter = model.assign;
            element.bind('change', function () {
                var values = [];
                angular.forEach(element[0].files, function (item) {
                    var value = {
                        // File Name 
                        name: item.name,
                        //File Size 
                        size: item.size,
                        //File URL to view 
                        url: URL.createObjectURL(item),
                        // File Input Value 
                        _file: item
                    };
                    values.push(value);
                });
                scope.$apply(function () {
                    if (isMultiple) {
                        modelSetter(scope, values);
                    } else {
                        modelSetter(scope, values[0]);
                    }
                });
            });
        }
    };
}]);
app.directive('datetimez', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            element.datetimepicker({
                language: 'en',
                pickDate: false,
            }).on('changeDate', function (e) {
                ngModelCtrl.$setViewValue(e.date);
                scope.$apply();
            });
        }
    };
});
