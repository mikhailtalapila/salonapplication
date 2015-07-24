'use strict';
angular.module('desktopApp')
	.factory('Customer',['$resource',function ($resource) {
		return $resource('/api/Customers/:id', {id:'@id'},
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
				update: {method: 'PUT', isArray: false},
				create: {method: 'POST'}
			});
	}]);