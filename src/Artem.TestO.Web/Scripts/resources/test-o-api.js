angular.module('Artem.TestO')
    .factory('Artem.TestO.webApi', ['$resource', function ($resource) {
        return $resource('api/test-o');
    }]);
