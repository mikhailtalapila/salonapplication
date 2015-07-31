'use strict';
App.controller('EmployeesCtrl',['$scope','$state',function ($scope,$state){
		$scope.$on('$stateChangeSuccess',function(){
			if($state.is('app.employees'))
				$state.go('app.employees.list');
		});
	}]);