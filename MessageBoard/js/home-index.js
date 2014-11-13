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

    $routeProvider.when("/message/:id", {
        controller: "singleTopicController",
        templateUrl: "/templates/singleTopicView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

// dataService angular custom service
angularFormsApp.factory("dataService", function ($http, $q) {
    var _topics = [];
    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    };

    var _getTopics = function () {
        var deferred = $q.defer();

        $http.get("/api/v1/topics?includeReplies=true").then(
            function (result) {
                // Success
                angular.copy(result.data, _topics);
                _isInit = true;
                deferred.resolve();
            },
            function () {
                // Error
                deferred.reject();
            });

        return deferred.promise;
    };

    var _addTopic = function (newTopic) {
        var deferred = $q.defer();

        $http.post("/api/v1/topics", newTopic).then(
            function (result) {
                // Success
                var createdTopic = result.data;

                _topics.splice(0, 0, createdTopic);
                deferred.resolve(createdTopic);
            }, function () {
                // Error
                deferred.reject();
            });

        return deferred.promise;
    };

    var _getTopicById = function(topicId) {
        var deferred = $q.defer();

        if (_isReady) {
            var topic = _findTopic(topicId);
            
            if (topic) {
                
            }
        }
        $http.get("/api/v1/topics?includeReplies=true").then(
            function (result) {
                // Success
                angular.copy(result.data, _topics);
                _isInit = true;
                deferred.resolve();
            },
            function () {
                // Error
                deferred.reject();
            });

        return deferred.promise;
    };
    

    return {
        topics: _topics,
        getTopics: _getTopics,
        addTopic: _addTopic,
        isReady: _isReady,
        getTopicById: _getTopicById
    };
});

angularFormsApp.controller("topicsController", function topicsController($scope, dataService) {
    $scope.dataCount = 0;
    $scope.data = dataService;
    $scope.isBusy = false;

    if (dataService.isReady() == false) {
        $scope.isBusy = true;
        dataService.getTopics().then(
            function () {
                // Success
            },
            function () {
                // Error
                alert("could not load topics");
            }).then(function () {
                $scope.isBusy = false;
            });
    }
});

angularFormsApp.controller("newTopicController", function newTopicController($scope, $window, dataService) {
    $scope.newTopic = {};
    $scope.save = function () {
        dataService.addTopic($scope.newTopic).then(
            function () {
                // Success
                $window.location = "#/";
            }, function () {
                // Error
                alert("Error saving the new topic");
            });
    };
});

angularFormsApp.controller("singleTopicController", function singleTopicController($scope, $window, dataService, $routeParams) {
    $scope.topic = null;
    $scope.newReply = {};

    dataService.getTopicById($routeParams.id).then(
        function (topic) {
            // Success
            $scope.topic = topic;

        }, function () {
            // Error
            $window.location = "#/";
        });
    $scope.addReply = function() {
               
    };
});