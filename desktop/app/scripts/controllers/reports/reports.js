'use strict';
angular.module('desktopApp')
	.controller('ReportsCtrl',['$scope','$state', function ($scope,$state) {
		$scope.$on('$stateChangeSuccess',function(){
			if ($state.is('reports'))
				$state.go('reports.list');
		});
	}]);