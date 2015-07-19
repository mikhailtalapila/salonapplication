'use strict';
angular.module('desktopApp')
	.controller('ReportsListCtrl',['$scope','$state', function ($scope,$state) {

		$scope.$on('$stateChangeSuccess',function(){
     	if ($state.is('customers.list'))
        	$scope.populateReportsList();
    	});

    	$scope.populateReportsList=function(){
  		console.log('Reports List is populated');

  		$scope.viewReportsDetails=function () {
  			$state.go('reports.details');
  		}				
  	};
	}]);