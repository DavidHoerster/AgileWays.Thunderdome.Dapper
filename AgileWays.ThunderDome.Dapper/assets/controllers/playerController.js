dapperBall.controller('playerController', ['$scope', '$routeParams', '$http', '$location',
        function ($scope, $routeParams, $http, $location) {
            
            $scope.create = function () {
                var player = {
                    PlayerId: $scope.newplayer.Id,
                    Name: {
                        First: $scope.newplayer.firstname,
                        Last: $scope.newplayer.lastname
                    },
                    Bats: $scope.newplayer.bats,
                    Throws: $scope.newplayer.throws,
                    Weight: $scope.newplayer.weight,
                    Height: $scope.newplayer.height
                };
                $http.post('/api/player', player)
                    .success(function (data) {
                        $location.path('/');
                    })
                    .error(function () { alert('oops'); });
            };
        }
]);