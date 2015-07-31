'use strict';
App.controller('EmployeesDetailsCtrl', ['$scope','$state','$stateParams','employeeDataFactory',function ($scope,$state,$stateParams,employeeDataFactory){
  	$scope.employeeId=$stateParams.id;
  	$scope.employee=employeeDataFactory.getEmployee($stateParams.id);
  	
  }]);