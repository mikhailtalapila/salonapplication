'use strict';
angular.module('desktopApp')
  .controller('CustomersCtrl', ['$scope','$http',function($scope,$http){
  	$scope.results=null;
  	$scope.populateCustomers=function(){
  		$http.get('http://localhost:60606/api/customer')
  			.success(function(response){
  				if(response.length!=0){
  					$scope.customers=response;
  				}
  			});  				
  	};
  }]);

