'use strict';
angular.module('desktopApp')
  .controller('ServicesListCtrl', ['$scope','$http','$state',function($scope,$http,$state){
  	$scope.results=null;
  	$scope.populateServices=function(){
  		$http.get('http://localhost:60606/api/service')
  			.success(function(response){
  				if(response.length!=0){
  					$scope.services=response;
  				}
  			});  				
  	};

    $scope.$on('$stateChangeSuccess',function(){
      if($state.is('services.list'))
        $scope.populateServices();
    });

    $scope.viewDetails=function(id){
      $state.go('services.details',{id:id})
    };
  }]);