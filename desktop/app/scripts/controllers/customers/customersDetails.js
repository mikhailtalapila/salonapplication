'use strict';
angular.module('desktopApp')
  .controller('CustomersDetailsCtrl', ['$scope','$state','$stateParams','Customer',function($scope,$state,$stateParams,Customer){
  	$scope.customerId=$stateParams.id;
  	$scope.customer=Customer.get({id:$stateParams.id});  	    
  }]);