'use strict';
App.controller('ServicesDetailsCtrl', ['$scope','$state','$stateParams','serviceDataFactory',function($scope,$state,$stateParams,serviceDataFactory){
  	getService();
  	$scope.serviceId=$stateParams.id;
  	$scope.service=serviceDataFactory.getService($stateParams.id);  	
  	
  	function getService() {
  		serviceDataFactory.getService($stateParams.id)
  			.success(function(serv) {
  				$scope.service=serv;  				
  			})
  			.error(function(error) {
  				$scope.status='Unable to get service: '+error.message;
  			});
  	}    
  }]);