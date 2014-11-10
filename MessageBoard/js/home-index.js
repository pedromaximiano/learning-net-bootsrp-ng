// home-index.js
var angularFormsApp = angular.module("messageBoardApp", []);

angularFormsApp.controller("homeIndexController", function homeIndexController($scope, $http) {
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