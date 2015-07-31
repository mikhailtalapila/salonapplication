'use strict';
angular.module('desktopApp')
  .controller('EmployeesScheduleDetailsCtrl', ['$scope','$state','$stateParams','employeeScheduleDataFactory',function ($scope,$state,$stateParams,employeeScheduleDataFactory){
  	$scope.employeeScheduleId=$stateParams.id;
  	employeeScheduleDataFactory.getEmployeeSchedule($stateParams.id)
  		.success(function(emp){
  			$scope.employeeSchedule=emp;
  		})
  		.error(function(error){
  			$scope.status='Unable to get employee schedule: '+error.message; 
  		});
  }]);  	    