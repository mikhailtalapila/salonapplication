'use strict';

App.controller('DailyCalendarCtrl',['$scope','$state',function ($scope,$state) {
		moment.locale('en', {
  			week : {
   			 dow : 1 // Monday is the first day of the week
 			 }
		});
		$scope.test='Daily calendar';

		$scope.calendarView = 'day';

		$scope.currentDay=new Date(2015,9,15);
		$scope.events = [
		  {
		    title: 'Michaelle T', // The title of the event
		    type: 'info', // The type of the event (determines its color). Can be important, warning, info, inverse, success or special
		    startsAt: new Date(2015,9,15,8), // A javascript date object for when the event starts
		    endsAt: new Date(2015,9,15,8,20), // Optional - a javascript date object for when the event ends
		    editable: false, // If edit-event-html is set and this field is explicitly set to false then dont make it editable.
		    deletable: true, // If delete-event-html is set and this field is explicitly set to false then dont make it deleteable
		    draggable: true, //Allow an event to be dragged and dropped
		    resizable: true, //Allow an event to be resizable
		    incrementsBadgeTotal: true, //If set to false then will not count towards the badge total amount on the month and year view
		    recursOn: 'year', // If set the event will recur on the given period. Valid values are year or month
		    cssClass: 'a-css-class-name' //A CSS class (or more, just separate with spaces) that will be added to the event when it is displayed on each view. Useful for marking an event as selected / active etc
		  },
		  {
		    title: 'Lauren B', // The title of the event
		    type: 'info', // The type of the event (determines its color). Can be important, warning, info, inverse, success or special
		    startsAt: new Date(2015,9,15,8,20), // A javascript date object for when the event starts
		    endsAt: new Date(2015,9,15,8,40), // Optional - a javascript date object for when the event ends
		    editable: false, // If edit-event-html is set and this field is explicitly set to false then dont make it editable.
		    deletable: true, // If delete-event-html is set and this field is explicitly set to false then dont make it deleteable
		    draggable: true, //Allow an event to be dragged and dropped
		    resizable: true, //Allow an event to be resizable
		    incrementsBadgeTotal: true, //If set to false then will not count towards the badge total amount on the month and year view
		    recursOn: 'year', // If set the event will recur on the given period. Valid values are year or month
		    cssClass: 'a-css-class-name' //A CSS class (or more, just separate with spaces) that will be added to the event when it is displayed on each view. Useful for marking an event as selected / active etc
		  },
		  {
		    title: 'Kathy P', // The title of the event
		    type: 'info', // The type of the event (determines its color). Can be important, warning, info, inverse, success or special
		    startsAt: new Date(2015,9,15,8,40), // A javascript date object for when the event starts
		    endsAt: new Date(2015,9,15,9), // Optional - a javascript date object for when the event ends
		    editable: false, // If edit-event-html is set and this field is explicitly set to false then dont make it editable.
		    deletable: true, // If delete-event-html is set and this field is explicitly set to false then dont make it deleteable
		    draggable: true, //Allow an event to be dragged and dropped
		    resizable: true, //Allow an event to be resizable
		    incrementsBadgeTotal: true, //If set to false then will not count towards the badge total amount on the month and year view
		    recursOn: 'year', // If set the event will recur on the given period. Valid values are year or month
		    cssClass: 'a-css-class-name' //A CSS class (or more, just separate with spaces) that will be added to the event when it is displayed on each view. Useful for marking an event as selected / active etc
		  },
		  {
		    title: 'Barbara T', // The title of the event
		    type: 'info', // The type of the event (determines its color). Can be important, warning, info, inverse, success or special
		    startsAt: new Date(2015,9,15,9), // A javascript date object for when the event starts
		    endsAt: new Date(2015,9,15,9,15), // Optional - a javascript date object for when the event ends
		    editable: false, // If edit-event-html is set and this field is explicitly set to false then dont make it editable.
		    deletable: true, // If delete-event-html is set and this field is explicitly set to false then dont make it deleteable
		    draggable: true, //Allow an event to be dragged and dropped
		    resizable: true, //Allow an event to be resizable
		    incrementsBadgeTotal: true, //If set to false then will not count towards the badge total amount on the month and year view
		    recursOn: 'year', // If set the event will recur on the given period. Valid values are year or month
		    cssClass: 'a-css-class-name' //A CSS class (or more, just separate with spaces) that will be added to the event when it is displayed on each view. Useful for marking an event as selected / active etc
		  },
		  {
		    title: 'Monica B', // The title of the event
		    type: 'info', // The type of the event (determines its color). Can be important, warning, info, inverse, success or special
		    startsAt: new Date(2015,9,15,9,15), // A javascript date object for when the event starts
		    endsAt: new Date(2015,9,15,9,30), // Optional - a javascript date object for when the event ends
		    editable: false, // If edit-event-html is set and this field is explicitly set to false then dont make it editable.
		    deletable: true, // If delete-event-html is set and this field is explicitly set to false then dont make it deleteable
		    draggable: true, //Allow an event to be dragged and dropped
		    resizable: true, //Allow an event to be resizable
		    incrementsBadgeTotal: true, //If set to false then will not count towards the badge total amount on the month and year view
		    recursOn: 'year', // If set the event will recur on the given period. Valid values are year or month
		    cssClass: 'a-css-class-name' //A CSS class (or more, just separate with spaces) that will be added to the event when it is displayed on each view. Useful for marking an event as selected / active etc
		  },
		  {
		    title: 'Tami V', // The title of the event
		    type: 'info', // The type of the event (determines its color). Can be important, warning, info, inverse, success or special
		    startsAt: new Date(2015,9,15,9,30), // A javascript date object for when the event starts
		    endsAt: new Date(2015,9,15,9,45), // Optional - a javascript date object for when the event ends
		    editable: false, // If edit-event-html is set and this field is explicitly set to false then dont make it editable.
		    deletable: true, // If delete-event-html is set and this field is explicitly set to false then dont make it deleteable
		    draggable: true, //Allow an event to be dragged and dropped
		    resizable: true, //Allow an event to be resizable
		    incrementsBadgeTotal: true, //If set to false then will not count towards the badge total amount on the month and year view
		    recursOn: 'year', // If set the event will recur on the given period. Valid values are year or month
		    cssClass: 'a-css-class-name' //A CSS class (or more, just separate with spaces) that will be added to the event when it is displayed on each view. Useful for marking an event as selected / active etc
		  },
		  {
		    title: 'Gammi L', // The title of the event
		    type: 'info', // The type of the event (determines its color). Can be important, warning, info, inverse, success or special
		    startsAt: new Date(2015,9,15,9,45), // A javascript date object for when the event starts
		    endsAt: new Date(2015,9,15,10), // Optional - a javascript date object for when the event ends
		    editable: false, // If edit-event-html is set and this field is explicitly set to false then dont make it editable.
		    deletable: true, // If delete-event-html is set and this field is explicitly set to false then dont make it deleteable
		    draggable: true, //Allow an event to be dragged and dropped
		    resizable: true, //Allow an event to be resizable
		    incrementsBadgeTotal: true, //If set to false then will not count towards the badge total amount on the month and year view
		    recursOn: 'year', // If set the event will recur on the given period. Valid values are year or month
		    cssClass: 'a-css-class-name' //A CSS class (or more, just separate with spaces) that will be added to the event when it is displayed on each view. Useful for marking an event as selected / active etc
		  }
		];

		
	}]);

