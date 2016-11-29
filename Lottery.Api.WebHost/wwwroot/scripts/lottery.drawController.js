(function () {
    'use strict';

    angular
        .module('lottery')
        .controller('drawController', lotteryDrawController);

    lotteryDrawController.$inject = ['lotteryService'];

    function lotteryDrawController(lotterySvc) {
        var vm = this;

        vm.lotterySvc = lotterySvc;
        vm.model = {};

        vm.createDraw = function () {
            lotterySvc.createDraw(vm.model).then(function (response) {
                alert('Lottery Draw Created');
                vm.model = {};
            }, lotterySvc.handleError)

        }
    }
})();
