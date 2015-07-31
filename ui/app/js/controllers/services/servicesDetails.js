'use strict';
App.controller('ServicesDetailsCtrl', ['$scope','$state','$stateParams','serviceDataFactory',function($scope,$state,$stateParams,serviceDataFactory){
  	$scope.serviceId=$stateParams.id;
  	$scope.service=serviceDataFactory.getService($stateParams.id);  	
  	    
  }]);