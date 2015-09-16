'use strict';
App.controller('CalendarCtrl',['$scope','$state',function ($scope,$state) {
		$scope.$on('$stateChangeSuccess',function(){
			if ($state.is('app.calendar'))
				$state.go('app.calendar.dailyCalendar');
		});
	}]);
