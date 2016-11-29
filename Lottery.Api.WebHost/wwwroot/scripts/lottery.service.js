(function () {
    'use strict';

    angular
        .module('lottery')
        .factory('lotteryService', lotteryService);

    lotteryService.$inject = ['$http'];

    function lotteryService($http) {
        var svc = this,
            service = {
                createDraw: createDraw,
                findByDrawDate: findByDrawDate,
                specifyWinningNumbers: specifyWinningNumbers,
                handleError: handleError
            };

        svc.http = $http;

        function handleError(response) {
            alert(response.data);
        }

        function createDraw(lotteryDraw) {
            return svc.http.post('api/lottery/draw', lotteryDraw);
        };

        function getConfig() {
            var config = {
                primaryNumbers: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49],
                secondaryNumbers: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
            };

            return {
                primary: {
                    maxWinningNumbers: 6,
                    numbers: config.primaryNumbers.map(function (n) { return { value: n, isSelected: false }; })
                },
                secondary: {
                    maxWinningNumbers: 2,
                    numbers: config.secondaryNumbers.map(function (n) { return { value: n, isSelected: false }; })
                }
            };
        }

        function findByDrawDate(drawDate) {
            var d = new Date(drawDate)

            return svc.http.get('api/lottery/draw/' + d.toJSON());
        };

        function specifyWinningNumbers(model) {
            return svc.http.put('api/lottery/draw/' + escape(model.name) + '/winningNumbers', { primary: model.winningPrimaryNumbers, secondary: model.winningSecondaryNumbers });
        };

        return service;
    }

})();