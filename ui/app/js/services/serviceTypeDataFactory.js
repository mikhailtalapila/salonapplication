'use strict';
App.factory('serviceTypeDataFactory',['$http', function ($http) {
		var urlBase='http://localhost:60606/api/servicetypes';
		var serviceTypeDataFactory={};

		serviceTypeDataFactory.getServiceTypes=function() {
			return $http.get(urlBase);
		};

		serviceTypeDataFactory.getServiceType=function(id) {
			return $http.get(urlBase+'/'+id);
		};

		serviceTypeDataFactory.insertServiceType=function(servType) {
			return $http.post(urlBase,servType);
		};

		serviceTypeDataFactory.updateServiceType=function(servType){
			return $http.put(urlBase+'/'+servType.serviceTypeId,servType);
		};

		serviceTypeDataFactory.deleteServiceType=function(id) {
			return $http.delete(urlBase+'/'+id);
		};

		
		return serviceTypeDataFactory;
	}]);