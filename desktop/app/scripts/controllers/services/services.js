'use strict';
angular.module('desktopApp')
	.controller('ServicesCtrl',['$state','$scope', function ($state, $scope) {		
		$scope.$on('$stateChangeSuccess',function(){
			if($state.is('services'))
				$state.go('services.list');
		});
}]);

