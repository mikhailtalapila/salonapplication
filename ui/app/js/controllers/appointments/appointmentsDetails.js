'use strict';
App.controller('AppointmentsDetailsCtrl',['$scope','$state', '$stateParams', 'appointmentDataFactory', function ($scope,$state,$stateParams,appointmentDataFactory) {


		$scope.appointmentId=$stateParams.id;
  		$scope.appointment=appointmentDataFactory.getAppointment($stateParams.id);

	}]);