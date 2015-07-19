'use strict';
angular.module('desktopApp')
  .controller('ServicesDetailsCtrl', ['$scope','$state','$stateParams','Service',function($scope,$state,$stateParams,Service){
  	$scope.serviceId=$stateParams.id;
  	$scope.service=Service.get({id:$stateParams.id});  	
  	    
  }]);