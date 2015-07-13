'use strict';
angular.module('desktopApp')
  .controller('ServicesCtrl', ['$scope','$http',function($scope,$http){
  	$scope.results=null;
  	$scope.populateServices=function(){
  		$http.get('http://localhost:60606/api/service')
  			.success(function(response){
  				if(response.length!=0){
  					$scope.services=response;
  				}
  			});  				
  	};
  }]);