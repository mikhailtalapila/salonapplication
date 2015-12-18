'use strict';
App.factory('appointmentDataFactory',['$http',function($http){
		var urlBase='http://localhost:60606/api/appointments';
		var appointmentsDataFactory={};

		appointmentsDataFactory.getAppointments=function() {
			return $http.get(urlBase+'/?StartTime=2015-09-01&EndTime=2015-09-02');
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