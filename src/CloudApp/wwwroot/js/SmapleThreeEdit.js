﻿$(".select2").css("width", "100%");
//ControlTab For Edit
function getstattab1() {

    if ($("#nex1").prop('checked')) {
        $(".l0").removeClass('active').addClass('completed');
        $("#tab2-1").removeClass('active');
        $("#tab2-2").addClass('active');
        $(".l1").addClass('active');
    }
}
function getstattab2() {
    if ($("#nex2").prop('checked')) {
        $(".l1").removeClass('active').addClass('completed');
        $("#tab2-2").removeClass('active');
        //same
        $("#tab2-3").addClass('active');
        $(".l2").addClass('active');
    }
}
function getstattab3() {
    if ($("#nex3").prop('checked')) {
        $(".l2").removeClass('active').addClass('completed');
        $("#tab2-3").removeClass('active');
        //same
        $("#tab2-4").addClass('active');
        $(".l3").addClass('active');
    }
}
function getstattab4() {
    if ($("#nex4").prop('checked')) {
        $(".l3").removeClass('active').addClass('completed');
        $("#tab2-4").removeClass('active');
        $("#tab2-5").addClass('active');
        $(".l4").addClass('active');
    }
}

function getstattab5() {
    if ($("#nex5").prop('checked')) {
        $(".l4").removeClass('active').addClass('completed');

    }
}

setTimeout(function () {
    $("#root").ready(function () {
        getstattab1();
        getstattab2();
        getstattab3();
        getstattab4();
        getstattab5();
    });
}, 300);
//End

//Contorl Tab In Clint
$("#nex1").change(function () {
    if (this.checked) {

        $(".l0").removeClass('active').addClass('completed');

    } else {

        $(".l0").removeClass('completed').addClass('active');

    }
});
$("#nex2").change(function () {
    if (this.checked) {

        $(".l1").removeClass('active').addClass('completed');

    } else {

        $(".l1").removeClass('completed').addClass('active');

    }
});
$("#nex3").change(function () {
    if (this.checked) {

        $(".l2").removeClass('active').addClass('completed');

    } else {

        $(".l2").removeClass('completed').addClass('active');

    }
});
$("#nex4").change(function () {
    if (this.checked) {

        $(".l3").removeClass('active').addClass('completed');

    } else {

        $(".l3").removeClass('completed').addClass('active');

    }
});
$("#nex5").change(function () {
    if (this.checked) {

        $(".l4").removeClass('active').addClass('completed');

    } else {

        $(".l4").removeClass('completed').addClass('active');

    }
});
//End

//DropZone Logic
var imguids = "";
var ob = $("#myId").dropzone({
    url: "/R2Smaple/UploadFile",
    success: function (file, response) {
        imguids += response + ";";
    },
    addRemoveLinks: true,
    removedfile: function (file) {

        $.get("http://" + "@Context.Request.Host.ToString()" + "/R2Smaple/RemoveFile?name=" + file.id,
            function () {
                alert("تم حذف الملف بنجاح!");
            });
        var _ref;
        return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
    }
});

var files = $("#imgs").text().split(';');
var hostname = $("#hosname").text();
for (var i = 0; i < files.length - 1; i++) {
    var filepath = "";
    var mockFile = { name: 'ملف', size: 13450, id: files[i] };
    ob[0].dropzone.emit("addedfile", mockFile);
    ob[0].dropzone.emit("thumbnail", mockFile, hostname + files[i] + ".jpg");
    ob[0].dropzone.emit("complete", mockFile);
}

$("#root").submit(function () {
    $("#ids").val(imguids);
});
//End


//GoogleMap Logic
var pos;
var map;
var geocoder;
var infowindowc;
function getlog() {

    // begin of Get Current Locations
    var infoWindow = new google.maps.InfoWindow({ map: map });
    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            infoWindow.setPosition(pos);
            infoWindow.setContent('هذا هو الموقع الحالي لك !');

            var myLatLng = { lat: Number($("#Latute").val()), lng: Number($("#Longtute").val()) };
            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                title: 'موقع العقار'
            });

            map.setCenter(pos);
        }, function () {

            handleLocationError(true, infoWindow, map.getCenter());
        }, {
            enableHighAccuracy: false,
            timeout: 30000,
            maximumAge: 30000
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
    // End of get Current Locations
}

function mapwork() {
    var mapProp = {
        center: new google.maps.LatLng(Number($("#Latute").val()), Number($("#Longtute").val())),
        zoom: 18
    };
    map = new google.maps.Map(document.getElementById("maptest"), mapProp);
    var myLatLng = { lat: Number($("#Latute").val()), lng: Number($("#Longtute").val()) };
    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'موقع العقار'
    });


    map.addListener('center_changed', function () {
        var obj = map.getCenter();
        $("#Latute").val(obj.lat());
        $("#Longtute").val(obj.lng());

    });


    geocoder = new google.maps.Geocoder;
    infowindowc = new google.maps.InfoWindow;

    var input = document.getElementById('pac-input');
    var searchBox = new google.maps.places.SearchBox(input);

    map.addListener('bounds_changed',
        function () {
            searchBox.setBounds(map.getBounds());
        });

    var markers = [];
    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed',
        function () {
            var places = searchBox.getPlaces();

            if (places.length == 0) {
                return;
            }

            // Clear out the old markers.
            markers.forEach(function (marker) {
                marker.setMap(null);
            });
            markers = [];

            // For each place, get the icon, name and location.
            var bounds = new google.maps.LatLngBounds();
            places.forEach(function (place) {
                if (!place.geometry) {
                    console.log("Returned place contains no geometry");
                    return;
                }
                var icon = {
                    url: place.icon,
                    size: new google.maps.Size(71, 71),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(17, 34),
                    scaledSize: new google.maps.Size(25, 25)
                };

                // Create a marker for each place.
                markers.push(new google.maps.Marker({
                    map: map,
                    icon: icon,
                    title: place.name,
                    position: place.geometry.location
                }));

                if (place.geometry.viewport) {
                    // Only geocodes have viewport.
                    bounds.union(place.geometry.viewport);
                } else {
                    bounds.extend(place.geometry.location);
                }
            });
            map.fitBounds(bounds);
        });

}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation
        ? 'Error: الخدمه فشلت في جلب الموقع'
        : 'Error: Your browser doesn\'t support geolocation.');
}

$("#is").click(function () {

    map.setCenter({ lat: Number($("#Latute").val()), lng: Number($("#Longtute").val()) });
    var myLatLng = { lat: Number($("#Latute").val()), lng: Number($("#Longtute").val()) };
    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'موقع العقار'
    });

    //  var obj = map.getCenter();
    //lng() lat()

});

//End
// multiple input 
$("#MeterPriceEarh").focusout(function () {
    var value = $("#AreaEarth").val() * $("#MeterPriceEarh").val();
    $("#TotalEarh").val(value);
});

$("#MeterPriceQabo").focusout(function () {
    var value = $("#AreaQabo").val() * $("#MeterPriceEarh").val();
    $("#TotalQabo").val(value);
});

$("#MeterPriceDorEarth").focusout(function () {
    var value = $("#AreaDorEarth").val() * $("#MeterPriceDorEarth").val();
    $("#TotalDorerath").val(value);
});

$("#MeterPriceFirstDoor").focusout(function () {
    var value = $("#AreaFirstDoor").val() * $("#MeterPriceFirstDoor").val();
    $("#TotalFirstDoor").val(value);
});

$("#MeterPriceReptDoor").focusout(function () {
    var value = $("#AreareptDoor").val() * $("#MeterPriceReptDoor").val();
    $("#TotalReptDoor").val(value);
});

$("#MeterPriceApendexErth").focusout(function () {
    var value = $("#AreaApnedxEarth").val() * $("#MeterPriceApendexErth").val();
    $("#TotalApendxEarth").val(value);
});

$("#MeterPriceapendxup").focusout(function () {
    var value = $("#AreaApendxup").val() * $("#MeterPriceapendxup").val();
    $("#Totalapendxup").val(value);
});

$("#MeterPriceAsawr").focusout(function () {
    var value = $("#AreaSwar").val() * $("#MeterPriceAsawr").val();
    $("#TotalAswar").val(value);
});


$("#MeterPricegarden").focusout(function () {
    var value = $("#Areagarden").val() * $("#MeterPricegarden").val();
    $("#Totalgarden").val(value);
});

$("#MeterPriceswiminpoo").focusout(function () {
    var value = $("#AreaSwimingpool").val() * $("#MeterPriceswiminpoo").val();
    $("#Totalswimingpool").val(value);
});

$("#MeterPriceCars").focusout(function () {
    var value = $("#AreaCars").val() * $("#MeterPriceCars").val();
    $("#TotalCars").val(value);
});

$("#MeterPriceothers").focusout(function () {
    var value = $("#AreaOthers").val() * $("#MeterPriceothers").val();
    $("#Totalothers").val(value);
});

$("#LastTaqeem").focusin(function () {
    var areatotal = parseInt($("#AreaEarth").val()) +
        parseInt($("#AreaQabo").val()) +
        parseInt($("#AreaDorEarth").val()) +
        parseInt($("#AreaFirstDoor").val()) +
        parseInt($("#AreareptDoor").val()) +
        parseInt($("#AreaApnedxEarth").val()) +
        parseInt($("#AreaApendxup").val()) +
        parseInt($("#AreaSwar").val()) +
        parseInt($("#Areagarden").val()) +
        parseInt($("#AreaSwimingpool").val()) +
        parseInt($("#AreaCars").val()) +
        parseInt($("#AreaOthers").val());

    var metertotal = parseInt($("#MeterPriceEarh").val()) +
        parseInt($("#MeterPriceQabo").val()) +
        parseInt($("#MeterPriceDorEarth").val()) +
        parseInt($("#MeterPriceFirstDoor").val()) +
        parseInt($("#MeterPriceReptDoor").val()) +
        parseInt($("#MeterPriceApendexErth").val()) +
        parseInt($("#MeterPriceapendxup").val()) +
        parseInt($("#MeterPriceAsawr").val()) +
        parseInt($("#MeterPricegarden").val()) +
        parseInt($("#MeterPriceswiminpoo").val()) +
        parseInt($("#MeterPriceCars").val()) +
        parseInt($("#MeterPriceothers").val());

    var total = areatotal * metertotal;
    $("#LastTaqeem").val(total);
});