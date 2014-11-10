var dapperBall = angular.module('dapperBall', ['ngRoute', 'ngSanitize', 'ngResource', 'ngAnimate', 'ui.bootstrap']);

dapperBall.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/thunder', {
            templateUrl: '/assets/partials/search.html',
            controller: 'searchController'
        })
        .when('/card/:playerid', {
            templateUrl: '/assets/partials/card.html',
            controller: 'cardController'
        })
        .when('/create', {
            templateUrl: '/assets/partials/createPlayer.html',
            controller: 'playerController'
        });
}]);