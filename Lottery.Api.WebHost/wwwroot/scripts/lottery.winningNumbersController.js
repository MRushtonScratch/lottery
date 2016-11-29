(function () {
    'use strict';

    angular
        .module('lottery')
        .controller('winningNumbersController', lotteryWinningNumbersController);

    lotteryWinningNumbersController.$inject = ['lotteryService'];

    function lotteryWinningNumbersController(lotterySvc) {
        var vm = this;

        vm.findDrawByDate = function () {
            var self = this;
            lotterySvc.findByDrawDate(self.drawDate).then(function (response) {                
                self.model = response.data;
                self.model.primaryNumbers = self.model.primaryNumbers.map(function (n) { return { value: n, isSelected: self.model.winningPrimaryNumbers.indexOf(n) !== -1 }; })
                self.model.secondaryNumbers = self.model.secondaryNumbers.map(function (n) { return { value: n, isSelected: self.model.winningSecondaryNumbers.indexOf(n) !== -1 }; })
            }, lotterySvc.handleError);
        }

        vm.selectPrimary = function (number) {
            setWinningNumber(vm.model.winningPrimaryNumbers, vm.model.totalAmountOfPrimaryNumbers, number);
            vm.canSubmit = validateWinningNumbers.call(vm);
        }

        vm.selectSecondary = function (number) {
            setWinningNumber(vm.model.winningSecondaryNumbers, vm.model.totalAmountOfSecondaryNumbers, number);
            vm.canSubmit = validateWinningNumbers.call(vm);
        }

        function validateWinningNumbers() {
            return vm.model.winningPrimaryNumbers.length === vm.model.totalAmountOfPrimaryNumbers &&
                vm.model.winningSecondaryNumbers.length === vm.model.totalAmountOfSecondaryNumbers;
        }

        vm.specifyWinningNumbers = function () {
            lotterySvc.specifyWinningNumbers(vm.model).then(function () {
                alert('Winning Numbers Saved');
                vm.model = {};
            }, lotterySvc.handleError);  
        }

        function setWinningNumber(winningNumbers, max, number) {
            var idx = winningNumbers.indexOf(number.value);

            if (winningNumbers.length >= max && !number.isSelected) {
                return;
            }

            number.isSelected = !number.isSelected;
            if (number.isSelected && idx === -1) {
                winningNumbers.push(number.value);
            } else {
                winningNumbers.splice(idx, 1);
            }
        }

    }
})();
