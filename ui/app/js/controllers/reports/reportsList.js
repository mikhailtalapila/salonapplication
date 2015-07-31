'use strict';
App.controller('ReportsListCtrl',['$scope','$state', function ($scope,$state) {

		$scope.$on('$stateChangeSuccess',function(){
     	if ($state.is('app.reports.list'))
        	$scope.populateReportsList();
    	});

    	$scope.populateReportsList=function(){
      };
  		$scope.viewReportsDetails=function () {
  			$state.go('app.reports.details');
  		};				
  	
	}]);