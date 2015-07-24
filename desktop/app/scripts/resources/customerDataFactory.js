'use strict';
angular.module('desktopApp')
	.factory('customerDataFactory',['$http', function ($http) {
		var urlBase='/api/customers';
		var customerDataFactory={};
		
		customerDataFactory.getCustomers=function() {
			return $http.get(urlBase);
		};

		customerDataFactory.getCustomer=function(id) {
			return $http.get(urlBase+'/'+id);
		};

		customerDataFactory.insertCustomer=function(cust) {
			return $http.post(urlBase,cust);
		};

		customerDataFactory.updateCustomer=function(cust) {
			return $http.put(urlBase+'/'+cust.customerId, cust);
		};

		customerDataFactory.deleteCustomer=function(id) {
			return $http.delete(urlBase+'/'+id);
		};

		customerDataFactory.getAppointments=function(id) {
			return $http.get(urlBase+'/'+id+'/appointments');
		};
		return customerDataFactory;
	}])