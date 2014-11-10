// home-index.js
var angularFormsApp = angular.module("homeIndex", ["ngRoute"]);

angularFormsApp.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "topicsController",
        templateUrl: "/templates/topicsView.html"
    });

    $routeProvider.when("/newmessage", {
        controller: "newTopicController",
        templateUrl: "/templates/newTopicView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

angularFormsApp.controller("topicsController", function topicsController($scope, $http) {
    $scope.dataCount = 0;
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/api/v1/topics?includeReplies=true").then(
        function (result) {
            // Success
            angular.copy(result.data, $scope.data);
            $scope.dataCount = result.data.length;
        },
        function () {
            // Error
            alert("could not load topics");
        }).then(function () {
            $scope.isBusy = false;
        });
});

angularFormsApp.controller("newTopicController", function newTopicController($scope, $http, $window) {
    $scope.newTopic = {};
    $scope.save = function () {
        $http.post("/api/v1/topics", $scope.newTopic).then(
            function (result) {
                // Success
                var newTopic = result.data;
                
                //TODO: merge
                $window.location = "#/";
            }, function () {
                // Error
                alert("Error saving the new topic");
            });
    };
});