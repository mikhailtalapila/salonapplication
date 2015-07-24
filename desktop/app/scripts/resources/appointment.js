'use strict';
angular.module('desktopApp')
	.factory('Appointment',['$resource',function ($resource) {
		return $resource('/api/Appointments/:id', {id:'@id'},
			{
				query: {
					method:'GET',
					isArray:true,
					transformResponse: function (data) {
						return JSON.parse(data).items;
					}
				},
				queryOData: {
					method:'GET',
					isArray: false,
					transformResponse: function (data) {
						return JSON.parse(data);
					}
				},
				someothertask: {method: 'POST', isArray: false, url: '/api/appointment/someotheruri'}
			});
	}]);