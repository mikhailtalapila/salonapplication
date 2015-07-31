'use strict';
App.controller('ServicesCtrl',['$state','$scope', function ($state, $scope) {		
		$scope.$on('$stateChangeSuccess',function(){
			if($state.is('app.services'))
				$state.go('app.services.list');
		});
}]);

