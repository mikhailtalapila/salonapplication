'use strict';

/**
 * @ngdoc overview
 * @name desktopApp
 * @description
 * # desktopApp
 *
 * Main module of the application.
 */
angular
  .module('desktopApp', [
    'ngAnimate',
    'ngAria',
    'ngCookies',
    'ngMessages',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'ui.router',
    'ngToast'
  ])
  .config(['$stateProvider','$urlRouterProvider','$httpProvider','ngToastProvider',
    function ($stateProvider,$urlRouterProvider,$httpProvider,ngToastProvider) {
      ngToastProvider.configure({
        dismissalButton:true
      });

      $urlRouterProvider.otherwise('/appontments');

      $stateProvider
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
angular.element(document).ready(function(){
  window.ApiUrl='http://localhost:60606';
});

