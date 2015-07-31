'use strict';
App.controller('CustomersDetailsCtrl', ['$scope','$state','$stateParams','customerDataFactory',function ($scope,$state,$stateParams,customerDataFactory){
  	$scope.customerId=$stateParams.id;
  	$scope.customer=customerDataFactory.getCustomer($stateParams.id);
  }]);