'use strict';
angular.module('desktopApp')
  .controller('EmployeesListCtrl', ['$http','$scope','$state','$stateParams',function($http,$scope,$state,$stateParams){
  	
  	$scope.populateEmployees=function(){
  		$http.get('http://localhost:60606/api/employees')
  			.success(function(response){
  				if(response.length!=0){
  					$scope.employees=response;
  				}
  			});  				
  	};

    $scope.$on('$stateChangeSuccess',function(){
      if($state.is('employees.list'))
        $scope.populateEmployees();
    });

    $scope.viewDetails=function(id){
      $state.go('employees.details',{id:id})
    };
  }]);