var app;

(function () {

    app = angular.module("Promotion", ["ui.bootstrap"]);

})();

app.controller('promoController', function ($scope, $http , $window) {


    $scope.protype = "";
    $scope.datefrom = "";
    $scope.dateto = "";
    $scope.roomidlist = [];
    $scope.roomid = "";
    $scope.rid = [];
    $scope.hours = "";
    $scope.departuredate1 = "";
    $scope.returndate1 = "";
    $scope.date = "";



    $("#lbldate").hide();
    $("#date").hide();
    $("#lblhrs").hide();
    $("#hrs").hide();
    $("#lblfrom1").hide();
    $("#datefrom1").hide();
    $("#lblto1").hide();
    $("#dateto1").hide();

    $('#ptype').on('change', function () {

        if (this.value == '1') {
            $("#lbldate").show();
            $("#date").show();
            $("#lblhrs").show();
            $("#hrs").show();
            $("#lblfrom1").hide();
            $("#datefrom1").hide();
            $("#lblto1").hide();
            $("#dateto1").hide();
        }
        else if (this.value == '2') {
            $("#lbldate").hide();
            $("#date").hide();
            $("#lblhrs").hide();
            $("#hrs").hide();
            $("#lblfrom1").show();
            $("#datefrom1").show();
            $("#lblto1").show();
            $("#dateto1").show();
        }
    });


    //$(document).ready(function () {

    //    var startDate = new Date();
    //    var date = new Date();
    //    var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
    //    var date_input = $('input[name="datefrom"]'); //our date input has the name "date"
    //    var date_input1 = $('input[name="dateto"]'); //our date input has the name "date"
    //    var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";

    //    date_input.datepicker({
    //        format: 'mm/dd/yyyy',
    //        container: container,
    //        todayHighlight: true,
    //        autoclose: true,
    //        startDate: today,

    //    }).on('changeDate', function (selected) {
    //        startDate = new Date(selected.date.valueOf());
    //        startDate.setDate(startDate.getDate(new Date(selected.date.valueOf())) + 1);
    //        $('#dateto').datepicker('setStartDate', startDate);

    //        $("#dateto").datepicker("show");
    //        var dateToBePrefilled = startDate;
    //        $("#dateto").datepicker("setDate", dateToBePrefilled);


    //    });


    //    var date_input1 = $('input[name="dateto"]'); //our date input has the name "date"
    //    var container1 = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";

    //    date_input1.datepicker({
    //        format: 'mm/dd/yyyy',
    //        container: container1,
    //        autoclose: true

    //    });



    //})
    //$("#date").on("dp.change", function () {

    //    $scope.selecteddate = $("#date").val();


    //});

    //$(function () {
    //    var dateFormat = "mm/dd/yy",
    //      from = $("#datefrom1")
    //        .datepicker({
    //            defaultDate: "+1w",
    //            changeMonth: true,          
    //        })
    //        .on("change", function () {
    //            to.datepicker("option", "minDate", getDate(this));
    //        }),
    //      to = $("#dateto1").datepicker({
    //          defaultDate: "+1w",
    //          changeMonth: true,         
    //      })
    //      .on("change", function () {
    //          from.datepicker("option", "maxDate", getDate(this));
    //      });
    //    function getDate(element) {
    //        var date;
    //        try {
    //            date = $.datepicker.parseDate(dateFormat, element.value);
    //        } catch (error) {
    //            date = null;
    //        }
    //        return date;
    //    }
    //});


    $scope.dateOptions = {
        formatYear: 'yyyy',
        startingDay: 1
    };

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


    $scope.remove = function (index) {
        $scope.rid.splice(index, 1);
    };

    var optionVal = new Array();
    function transfer(index) {
        for (x = 0; x < index.length; x++) {
            console.log($scope.rid[x].name);
            optionVal.push($scope.rid[x].name);
        }
    };

    $scope.submitPromo = function () {
        transfer($scope.rid);

        if (optionVal.length == 0) {
            alert("Please add rooms!");
            return false;
        }
        if ($scope.protype == "")
        {
            alert("Please select a promotion type!");
            return false;
        }
        
       if (($scope.protype == "1" && ($scope.Date == 0 || $scope.hours == 0)) || ($scope.protype == "2" && ($scope.datefrom == 0 || $scope.dateto == 0)))
        {
            alert("Please add promotion date and hour info!");
            return false;
        }
        if ($scope.dvalue == null ) {
            alert("Please insert a discount value!");
            return false;
        }
        if ($scope.dvalue <= 0) {
            alert("Please insert a valid discount value!");
            return false;
        }
        if ($scope.dpercentage == null) {
            alert("Please add a discount percentage!");
            return false;
        }
        if ($scope.dpercentage <= 0) {
            alert("Please insert a valid discount percentage!");
            return false;
        }
        
            //else if($scope.dpercentage== "")
            //{
            //    alert("Please insert the discount percentage!");
            //    return false;
            //}
            //else if ($scope.dvalue == "") {
            //    alert("Please insert the discount value!");
            //    return false;
            //}

        else {
            $scope.DateFrom = convert($scope.datefrom);
            $scope.DateTo = convert($scope.dateto);
            $scope.Date = convert($scope.date);

            sub = {
                PromotionType: $scope.protype,
                DateFrom: $scope.DateFrom,
                DateTo: $scope.DateTo,
                Hours: $scope.hours,
                DiscountValue: $scope.dvalue,
                DiscountPercentage: $scope.dpercentage,
                RoomID: optionVal,
                PromoDate: $scope.Date,
            };

            var post = $http({
                method: "POST",
                url: "/Home/SavePromotion",
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
    };

    var x = 0;
    $scope.add = function ()
    {
        if ($scope.roomId == null)
        {
            alert("Please select Room ID.");
            return false;
        }
       
        if (x == 0) {
            $scope.rid = [{
                name: $scope.roomId,
            }];
        }
        else {
            $scope.rid.push({
                name: $scope.roomId,
            });
            console.log("dd");
        }
        x++;
        //$event.preventDefault();
    };
    $scope.removerid = function (index) {
        $scope.rid.splice(index, 1);
    };

});