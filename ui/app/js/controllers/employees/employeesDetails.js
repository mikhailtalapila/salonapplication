'use strict';
App.controller('EmployeesDetailsCtrl', ['$scope','$state','$stateParams','employeeDataFactory',function ($scope,$state,$stateParams,employeeDataFactory){
  	$scope.employeeId=$stateParams.id;
  	function getEmployee() {
  		employeeDataFactory.getEmployee($stateParams.id)
  			.success(function(emp){
  				$scope.employee=emp;
  			})
  			.error(function(error){
  				$scope.status='Unable to get employee: '+error.message;
  			});
  	};
  	getEmployee();
 }]);