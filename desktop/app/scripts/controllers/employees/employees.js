'use strict';
angular.module('desktopApp')
	.controller('EmployeesCtrl',['$scope','$state',function ($scope,$state){
		$scope.$on('$stateChangeSuccess',function(){
			if($state.is('employees'))
				$state.go('employees.list');
		});
	}]);