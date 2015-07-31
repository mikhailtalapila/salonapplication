'use strict';

if(typeof $==='undefined') { throw new Error('This application\'s Javascript requires jQuery'); }

var App=angular
  .module('desktopApp', [
    'ngAnimate',    
    'ngStorage',
    'ngAria',
    'ngCookies',
    'pascalprecht.translate',
    'ngMessages',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'ui.router',
    'ngToast',
    'ui.bootstrap'
  ]);

App.run(['$rootScope', '$state', '$stateParams', '$window', '$templateCache', function ($rootScope, $state, $stateParams, $window, $templateCache) {
  $rootScope.$state=$state;
  $rootScope.$stateParams=$stateParams;
  $rootScope.$storage=$window.localStorage;

  $rootScope.app = {
    name:'Desktop app',
    description: 'Salon application',
    year: ((new Date()).getFullYear()),
    layout: {
      isFixed: true,
      isCollapsed: false,
      isBoxed: false,
      isRTL: false,
      horizontal: false,
      isFloat: false,
      asideHover: false,
      theme: null
    },
    useFullLayout: false,
    hiddenFooter: false,
    offsidebarOpen: false,
    asideToggled: false,
    viewAnimation: 'ng-fadeInUp'
  };

  $rootScope.user= {
  name: 'Mikhail',
  job: 'ng-developer',
  picture:'mikhail-developer-pic.jpg'
  };
}]);

App.config(['$stateProvider','$locationProvider','$urlRouterProvider','$httpProvider','ngToastProvider',
    function ($stateProvider, $locationProvider, $urlRouterProvider, $httpProvider, ngToastProvider) {
      'use strict';

      $locationProvider.html5Mode(false);

      ngToastProvider.configure({
        dismissalButton:true
      });

      $urlRouterProvider.otherwise('/app');

      $stateProvider
        .state('app', {
          url:'/app',
          templateUrl:'/views/app.html',
          controller:'AppController'
        })
        .state('login',{
          templateUrl:"views/login.html",
          controller:'LoginCtrl'
        })
        .state('appointments',{
            url:"/appointments",
            templateUrl:"/views/appointments/appointments.html",
            controller:'AppointmentsCtrl'
        })  
            .state('appointments.list',{
              url:'/appontmentslist',
              templateUrl:'/views/appointments/appointmentsList.html',
              controller:'AppointmentsListCtrl'
            })
            .state('appointments.details',{
              url:'/appointmentdetails/:id',
              templateUrl:'/views/appointments/appointmentsDetails.html',
              controller:'AppointmentsDetailsCtrl'
            })
        .state('employees',{
            url:"/employees",
            templateUrl:"/views/employees/employees.html",
            controller:'EmployeesCtrl'
        })
            .state('employees.list',{
              url: '/employeeslist',
              templateUrl:"/views/employees/employeesList.html",
              controller:'EmployeesListCtrl'
            })
            .state('employees.details',{
              url: '/employeedetails/:id',
              templateUrl: '/views/employees/employeesDetails.html',
              controller:'EmployeesDetailsCtrl'
            })
        .state('customers',{
            url:"/customers",
            templateUrl:"/views/customers/customers.html",
            controller:'CustomersCtrl'
        })
            .state('customers.list',{
              url:"/customerslist",
              templateUrl:'/views/customers/customersList.html',
              controller:'CustomersListCtrl'
            })
            .state('customers.details',{
              url:'/customersdetails/:id',
              templateUrl:'/views/customers/customersDetails.html',
              controller:'CustomersDetailsCtrl'
            })
        .state('services',{
            url:"/services",
            templateUrl:"/views/services/services.html",
            controller:'ServicesCtrl'
        })
            .state('services.list',{
              url:"/serviceslist",
              templateUrl:'/views/services/serviceslist.html',
              controller:'ServicesListCtrl'
            })
            .state('services.details',{
              url:"/servicesdetails/:id",
              templateUrl:'/views/services/servicesDetails.html',
              controller:'ServicesDetailsCtrl'
            })
        .state('employeesSchedule',{
          url:'/employeesSchedule',
          templateUrl:'/views/employeesSchedule/employeesSchedule.html',
          controller:'EmployeesScheduleCtrl'
        })
            .state('employeesSchedule.list',{
              url:'/employeesScheduleList',
              templateUrl:'/views/employeesSchedule/employeesschedulelist.html',
              controller:'EmployeesScheduleListCtrl'
            })
            .state('employeesSchedule.details',{
              url:'/employeesScheduleDetails/:id',
              templateUrl:'/views/employeesSchedule/employeesScheduleDetails.html',
              controller:'EmployeesScheduleDetailsCtrl'
            })
        .state('populateEmployeeSchedules',{
          url:'/populateEmployeeSchedules',
          templateUrl:'/views/employeesSchedule/populateEmployeeSchedules.html',
          controller:'PopulateEmployeeSchedulesCtrl'
        })
        .state('employeesManagement',{
          url:'/employeesManagement',
          templateUrl:'/views/employeesManagement/employeesManagement.html',
          controller:'EmployeesManagementCtrl'
        })
        .state('reports',{
          url:'/reports',
          templateUrl:'/views/reports/reports.html',
          controller:'ReportsCtrl'
        })
            .state('reports.list',{
              url:'/reportsList',
              templateUrl:'/views/reports/reportsList.html',
              controller:'ReportsListCtrl'
            })
            .state('reports.details',{
              url:'/reportsdetails',
              templateUrl:'/views/reports/reportsDetails.html',
              controller:'ReportsDetailsCtrl'
            });
          $httpProvider.interceptors.push('apiHttpInterceptor');
    
    }]);
App.config(['$translateProvider',function($translateProvider) {
  $translateProvider.useStaticFilesLoader({
    prefix: 'app/i18n',
    suffix: '.json'
  });
  $translateProvider.preferredLanguage('en');
  $translateProvider.useLocalStorage();
  $translateProvider.usePostCompiling(true);   
}])
;

App.controller('AppController',['$rootScope','$scope','$state','$window','$localStorage','$timeout',
  function ($rootScope, $scope, $state, $window, $localStorage, $timeout) {
    'use strict';

    $rootScope.app.layout.horizontal= ($rootScope.$stateParams.layout=='app-h');

    var thBar;
    $rootScope.$on('$stateChangeStart', function(event, toState, toParams, fromState, fromParams) {
      if($('.wrapper>section').length)
          thBar=$timeout(function() {
            cfpLoadingBar.start();
          }, 0);
    });
    $rootScope.$on('$stateChangeSuccess',function(event, toState, toParams, fromState, fromParams) {
      event.targetScope.$watch("$viewContentLoaded", function () {
        $timeout.cancel(thBar);
        cfpLoadingBar.complete();
      });
    });

    $rootScope.$on('$stateNotFound',
        function(event, unfoundState, fromState, fromParams) {
          console.log(unfoundState.to);
          console.log(unfoundState.toParams);
          console.log(unfoundState.options);
        });

    $rootScope.$on('$stateChangeError',
      function(event, toState, toParams, fromState, fromParams, error) {
        $window.scrollTo(0,0);
        $rootScope.currTitle=$state.current.title;
      });

    $rootScope.currTitle=$state.current.title;

    $rootScope.pageTitle=function() {
      var title=$rootScope.app.name + ' - ' + ($rootScope.currTitle || $rootScope.app.description);
      document.title=title;
      return title;
    };

    $rootScope.$watch('app.layout.isCollapsed', function(newValue, oldValue) {
      if(newValue===false)
        $rootScope.$broadcast('closeSidebarMenu');
    });

    if(angular.isDefined($localStorage.layout))
      $scope.app.layout=$localStorage.layout;
    else
      $localStorage.layout=$scope.app.layout;

    $rootScope.$watch('app.layout', function() {
      $localStorage.layout=$scope.app.layout;
    }, true);

    $scope.toggleUserBlock=function() {
      $scope.$broadcast('toggleUserBlock');
    };

    $rootScope.cancel=function($event) {
      $event.stopPropagation();
    };

  }]);

angular.element(document).ready(function(){
  window.ApiUrl='http://localhost:60606';
});

