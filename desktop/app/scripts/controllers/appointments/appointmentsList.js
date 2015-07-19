'use strict';

angular.module('desktopApp')
  .controller('AppointmentsListCtrl', ['$scope','$state','$http', function ($scope,$state,$http) {
    $scope.$on('$stateChangeSuccess',function(){
     	if ($state.is('appointments.list'))
        	$scope.populateAppointmentsList();
    	});

    	$scope.populateAppointmentsList=function(){
  			$http.get('http://localhost:60606/api/appointment')
  				.success(function(response){
  					if(response.length!==0){
  						$scope.appointments=response;
  					}
  				});
  		};
  		
  		$scope.viewDetails=function(id){
    		  $state.go('appointments.details',{id:id})
    	};

}]);
