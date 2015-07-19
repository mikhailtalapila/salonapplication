'use strict';
angular.module('desktopApp')
	.controller('AppointmentsCtrl',['$scope','$state',function ($scope,$state) {
		$scope.$on('$stateChangeSuccess',function(){
			if ($state.is('appointments'))
				$state.go('appointments.list');
		});
	}]);