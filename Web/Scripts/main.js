
require.config({
    paths: {
        jquery: 'Scripts/jquery-1.9.1',
        bootstrap: "Scripts/bootstrap",
        amplify:"Scripts/amplify"
    }

});


require(["jquery", "bootstrap", "amplify"], function ($, bootstrap, amplify) {
    // Modules that do stuff on every page are instantiated here 
    $(document).ready(function () {
        var self = this;

        amplify.request.define("EventSearch", "ajax", {
            url: "/Search/{term}/{location}/{radius}/",
            dataType: "json",
            cache: true
        });

        amplify.request.define("CreatEvent", "ajax", {
            url: "/Search/{term}/{location}/{radius}/",
            dataType: "json",
            cache: true
        });

        amplify.request.define("SubscribeEvent", "ajax", {
            url: "/Search/{term}/{location}/{radius}/",
            dataType: "json",
            cache: true
        });

        amplify.request.define("UpdateEvent", "ajax", {
            url: "/Search/{term}/{location}/{radius}/",
            dataType: "json",
            cache: true
        });
    });
});