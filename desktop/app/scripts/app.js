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

      $urlRouterProvider.otherwise('/main');

      $stateProvider
        .state('login',{
          templateUrl:"views/login.html",
          controller:'LoginCtrl'
        })
        .state('main',{
            url:"/main",
            templateUrl:"/views/main.html",
            controller:'MainCtrl'
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
            });
          $httpProvider.interceptors.push('apiHttpInterceptor');
    
    }]);
angular.element(document).ready(function(){
  window.ApiUrl='http://localhost:60606';
});

