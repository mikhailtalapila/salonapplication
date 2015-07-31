'use strict';
App.controller('CustomersCtrl',['$scope','$state',function ($scope,$state) {
		$scope.$on('$stateChangeSuccess',function(){
			if ($state.is('app.customers'))
				$state.go('app.customers.list');
		});
	}]);