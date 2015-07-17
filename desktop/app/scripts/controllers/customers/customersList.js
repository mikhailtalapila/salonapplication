'use strict';
angular.module('desktopApp')
  .controller('CustomersListCtrl', ['$http','$scope','$state',function ($http,$scope,$state){
  	
    $scope.$on('$stateChangeSuccess',function(){
      if ($state.is('customers.list'))
        $scope.populateCustomers();
    });

  	$scope.populateCustomers=function(){
  		$http.get('http://localhost:60606/api/customer')
  			.success(function(response){
  				if(response.length!=0){
  					$scope.customers=response;
  				}
  			});  				
  	};

    $scope.viewDetails=function(id){
      $state.go('customers.details',{id:id})
    };
  }]);
