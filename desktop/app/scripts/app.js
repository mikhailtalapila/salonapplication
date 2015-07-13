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

      $urlRouterProvider.otherwise('/');

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
            templateUrl:"/views/employees.html",
            controller:'EmployeesCtrl'
        })
        .state('customers',{
            url:"/customers",
            templateUrl:"/views/customers.html",
            controller:'CustomersCtrl'
        })
        .state('services',{
            url:"/services",
            templateUrl:"/views/services.html",
            controller:'ServicesCtrl'
        });
    
    }]);

