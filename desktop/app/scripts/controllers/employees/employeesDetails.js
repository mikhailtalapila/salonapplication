'use strict';
angular.module('desktopApp')
  .controller('EmployeesDetailsCtrl', ['$scope','$state','$stateParams','Employee',function($scope,$state,$stateParams,Employee){
  	$scope.employeeId=$stateParams.id;
  	$scope.employee=Employee.get({id:$stateParams.id});
  	$scope.viewEmployeePicture=function(id){
      return '/images/employees/'+id;
    };
  }]);