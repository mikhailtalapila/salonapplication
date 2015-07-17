'use strict';
angular.module('desktopApp')
	.controller('CustomersCtrl',['$scope','$state',function ($scope,$state) {
		$scope.$on('$stateChangeSuccess',function(){
			if ($state.is('customers'))
				$state.go('customers.list');
		});
	}]);