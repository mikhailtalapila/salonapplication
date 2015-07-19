'use strict';
angular.module('desktopApp')
	.controller('EmployeesScheduleCtrl',['$scope','$state',function ($scope,$state){
		$scope.$on('$stateChangeSuccess',function(){
			if($state.is('employeesSchedule'))
				$state.go('employeesSchedule.list');
		});
	}]);