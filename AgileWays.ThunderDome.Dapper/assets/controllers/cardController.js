dapperBall.controller('cardController', ['$scope', '$routeParams', '$http', '$location',
    function ($scope, $routeParams, $http, $location) {
        
        var playerid = $routeParams.playerid || 'aardsda01';

        $scope.selectedPlayer = null;

        $http.get('api/player/' + playerid)
            .success(function (data) {
                $scope.player = data;
                $http.get('api/player/lookup')
                    .success(function (dl) {
                        $scope.playerLookup = dl;
                    })
                    .error(function () { alert('lookup oops!'); });
            })
            .error(function () {
                alert('oops');
            });

        $scope.getPlayer = function () {
            $location.path('/card/' + $scope.selectedPlayer);
        }
    }
]);