'use strict';
angular.module('desktopApp')
	.factory('apiHttpInterceptor',[function (){
		return {
			'request': function (config) {
				if (config.url.startsWith('/api') || config.url.startsWith('/Token')) {
					config.url = window.ApiUrl + config.url;
				}
				return config;
			}
		};
	}]);