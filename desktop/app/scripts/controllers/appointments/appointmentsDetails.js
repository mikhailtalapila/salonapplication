'use strict';
angular.module('desktopApp')
	.controller('AppointmentsDetailsCtrl',['$scope','$state', '$stateParams', 'Appointment', function ($scope,$state,$stateParams,Appointment) {


		$scope.appointmentId=$stateParams.id;
  		$scope.appointment=Appointment.get({id:$stateParams.id});

	}]);