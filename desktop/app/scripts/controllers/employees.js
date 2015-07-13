'use strict';
angular.module('desktopApp')
  .controller('EmployeesCtrl', ['$scope','$http',function($scope,$http){
  	$scope.results=null;
  	$scope.populateEmployees=function(){
  		$http.get('http://localhost:60606/api/employee')
  			.success(function(response){
  				if(response.length!=0){
  					$scope.employees=response;
  				}
  			});  				
  	};
  }]);

