'use strict';
App.controller('ReportsCtrl',['$scope','$state', function ($scope,$state) {
		$scope.$on('$stateChangeSuccess',function(){
			if ($state.is('app.reports'))
				$state.go('app.reports.list');
		});
	}]);