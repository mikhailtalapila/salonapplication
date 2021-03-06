'use strict';
App.factory('employeeScheduleDataFactory',['$http',function ($http) {
		var urlBase='http://localhost:60606/api/employeeSchedules';
		var employeeScheduleDataFactory={};

		employeeScheduleDataFactory.getEmployeeSchedules=function() {
			return $http.get(urlBase);
		};

		employeeScheduleDataFactory.getEmployeeSchedule=function(id) {
			return $http.get(urlBase+'/'+id);
		};

		employeeScheduleDataFactory.insertEmployeeSchedule=function(empSched) {
			return $http.post(urlBase);
		};

		employeeScheduleDataFactory.updateEmployeeSchedule=function(empSched) {
			return $http.put(urlBase+'/'+empSched.employeeScheduleId);
		};

		employeeScheduleDataFactory.deleteEmployeeSchedule=function(id) {
			return $http.delete(urlBase+'/'+id);
		};
        return employeeScheduleDataFactory;
	}]);