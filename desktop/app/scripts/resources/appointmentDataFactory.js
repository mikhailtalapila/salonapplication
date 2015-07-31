'use strict';
angular.module('desktopApp')
	.factory('appointmentDataFactory',['$http',function($http){
		var urlBase='/api/appointments';
		var appointmentsDataFactory={};

		appointmentsDataFactory.getAppointments=function() {
			return $http.get(urlBase);
		};

		appointmentsDataFactory.getAppointment=function(id) {
			return $http.get('urlBase'+'/'+id);
		};

		appointmentsDataFactory.insertAppointment=function(appt) {
			return $http.post(urlBase,appt);
		};

		appointmentsDataFactory.updateAppointment=function(appt) {
			return $http.put(urlBase+'/'+appt.appointmentId,appt);
		};

		appointmentsDataFactory.deleteAppointment=function(id) {
			return $http.delete(urlBase+'/'+id);
		};

		return appointmentsDataFactory;
	}]);