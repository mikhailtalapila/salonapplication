'use strict';
App.controller('EmployeesScheduleCtrl',['$scope','$state',function ($scope,$state){
		$scope.$on('$stateChangeSuccess',function(){
			if($state.is('app.employeesSchedule'))
				$state.go('app.employeesSchedule.list');
		});
	}]);