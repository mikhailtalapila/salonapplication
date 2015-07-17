'use strict';
angular.module('desktopApp')
	.factory('Employee',['$resource',function ($resource) {
		return $resource('/api/employee/:id', {id:'@id'},
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
				someothertask: {method: 'POST', isArray: false, url: '/api/employee/someotheruri'}
			});
	}]);