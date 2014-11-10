dapperBall.controller('navController', ['$scope', '$http', '$location', '$resource',
    function ($scope, $http) {
        function init() {
            $('.search input').click(function (e) { e.stopPropagation(); });
        }

        $scope.search = function () {
            $http.get('/api/search?q=' + $scope.searchText)
                .success(function (data) {
                    $scope.searchText = '';
                    $scope.searchResults = data;
                });
        };

        init();
    }]);