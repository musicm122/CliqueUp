
require.config({
    paths: {
        jquery: 'Scripts/jquery-1.9.1',
        bootstrap: "Scripts/bootstrap",
        amplify: "Scripts/amplify",
        ko: "Scripts/knockout-2.2.0"
    }
});


require(["jquery", "bootstrap", "amplify"], function ($, bootstrap, amplify) {
    // Modules that do stuff on every page are instantiated here 
    $(document).ready(function () {

        $.get("/api/EventApi/", function (data) {
            $("#TopEvents").html(data);
        });

        var self = this;
        self.term = "";
        self.distance = 10;//in miles
        ////http://localhost:6552/api/EventApi/
        self.popEvent = function(guid){
            $.get("/api/EventApi/" + guid, function (data) {
                $("#eventDetails").html(data);
            });
        };

        $("#saveEventBtn").click(function (e) {
            var data = $('#addEventForm').serialize();
            $.post('/api/eventapi/', data);
        });

        $("#EventSearchBtn").click(function (e) {
            $("#searchText").val();
            //amplify.request("CreateEvent", {
            //    term: self.term,
            //    location: "",
            //    radius:self.distance
            //}, function (data) {

            //    $("#searchText").html();
            //});
        });

        //amplify.request.define("EventSearch", "ajax", {
        //    url: "/Search/{term}/{location}/{radius}/",
        //    dataType: "json",
        //    cache: true
        //});

        //amplify.request.define("CreateEvent", "ajax", {
        //    url: "/Search/{term}/{location}/{radius}/",
        //    dataType: "json",
        //    cache: true
        //});

        //amplify.request.define("SubscribeEvent", "ajax", {
        //    url: "/Search/{term}/{location}/{radius}/",
        //    dataType: "json",
        //    cache: true
        //});

        //amplify.request.define("UpdateEvent", "ajax", {
        //    url: "/Search/{term}/{location}/{radius}/",
        //    dataType: "json",
        //    cache: true
        //});
    });
});