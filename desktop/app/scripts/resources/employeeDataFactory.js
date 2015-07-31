'use strict';
angular.module('desktopApp')
	.factory('employeeDataFactory',['$http',function($http){
		var urlBase='/api/employees';
		var employeeDataFactory={};

		employeeDataFactory.getEmployees=function() {
			return $http.get(urlBase);
		};

		employeeDataFactory.getEmployee=function(id) {
			return $http.get(urlBase+'/'+id);
		};

		employeeDataFactory.insertEmployee=function(emp) {
			return $http.post(urlBase,emp);
		};

		employeeDataFactory.updateEmployee=function(emp) {
			return $http.put(urlBase+'/'+emp.employeeId,emp);
		};

		employeeDataFactory.deleteEmployee=function(id) {
			return $http.delete(urlBase+'/'+id);
		};

		employeeDataFactory.getAppointments=function(id) {
			return $http.get(urlBase+'/'+id+'/appointments');
		};

		return employeeDataFactory;
	}]);