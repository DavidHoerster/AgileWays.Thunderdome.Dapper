dapperBall.controller('searchController', ['$scope', '$routeParams', '$http', '$location',
    function ($scope, $routeParams, $http, $location) {
        $scope.search = function () {
            var players = {
                params: {
                    player1: $scope.playerid1,
                    player2: $scope.playerid2
                }
            };
            $http.get('/api/player/list', players)
                .success(function (data) {
                    $scope.results = data;
                })
                .error(function () { alert('ooops'); });
        };
    }
]);