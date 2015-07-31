'use strict';
App.factory('serviceDataFactory',['$http', function ($http) {
		var urlBase='http://localhost:60606/api/services';
		var serviceDataFactory={};

		serviceDataFactory.getServices=function() {
			return $http.get(urlBase);
		};

		serviceDataFactory.getService=function(id) {
			return $http.get(urlBase+'/'+id);
		};

		serviceDataFactory.insertService=function(serv) {
			return $http.post(urlBase,serv);
		};

		serviceDataFactory.updateService=function(serv){
			return $http.put(urlBase+'/'+serv.serviceId,serv);
		};

		serviceDataFactory.deleteService=function(id) {
			return $http.delete(urlBase+'/'+id);
		};

		serviceDataFactory.getQualifications=function(id) {
			return $http.get(urlBase+'/'+id+'/qualifications');
		};
		
		return serviceDataFactory;
	}]);