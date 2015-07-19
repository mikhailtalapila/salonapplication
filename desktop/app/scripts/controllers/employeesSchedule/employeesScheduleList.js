'use strict';
angular.module('desktopApp')
  .controller('EmployeesScheduleListCtrl', ['$http','$scope','$state','$stateParams',function($http,$scope,$state,$stateParams){
  	
  	$scope.populateEmployeesSchedules=function(){
  		$http.get('http://localhost:60606/api/employeeschedule')
  			.success(function(response){
  				if(response.length!=0){
  					$scope.employeesSchedules=response;
  				}
  			});  				
  	};

    $scope.$on('$stateChangeSuccess',function(){
      if($state.is('employeesSchedule.list'))
        $scope.populateEmployeesSchedules();
    });

  }]);