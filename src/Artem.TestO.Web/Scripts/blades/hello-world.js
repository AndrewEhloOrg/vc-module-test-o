angular.module('Artem.TestO')
    .controller('Artem.TestO.helloWorldController', ['$scope', 'Artem.TestO.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = 'TestO';

        blade.refresh = function () {
            api.get(function (data) {
                blade.title = 'TestO.blades.hello-world.title';
                blade.data = data.result;
                blade.isLoading = false;
            });
        };

        blade.refresh();
    }]);
