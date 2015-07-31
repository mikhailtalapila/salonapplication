'use strict';
App.controller('AppointmentsCtrl',['$scope','$state',function ($scope,$state) {
		$scope.$on('$stateChangeSuccess',function(){
			if ($state.is('app.appointments'))
				$state.go('app.appointments.list');
		});
	}]);