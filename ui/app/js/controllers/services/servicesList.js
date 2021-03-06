'use strict';
App.controller('ServicesListCtrl', ['$scope','$http','$state','serviceDataFactory','RouteHelpers',function ($scope,$http,$state,serviceDataFactory,RouteHelpers){
  	
    $scope.$on('$stateChangeSuccess',function(){
      if($state.is('app.services.list'))
        getServices();
    });     

    function getServices() {
      serviceDataFactory.getServices()
        .success(function(services){
          $scope.services=services;
        })
        .error(function(error){
          $scope.status='Unable to get services: '+error.message;
        });
    };

    $scope.updateService=function(id) {
      var serv={};
      for (var i = 0; i < $scope.services.length; i++) {
        var currServ=$scope.services[i];
        if(currServ.serviceId===id) {
          serv=currServ;
          break;
        }
      }

      serviceDataFactory.updateService(serv)
        .success(function(){
          $scope.status='Updated service! Refreshing service list';
        })
        .error(function(error){
          $scope.status='Unable to update service: '+error.message;
        });
    };

    $scope.viewDetails=function(id){
      $state.go('app.services.details',{id:id});
    };
    $scope.viewEmployeeDetails=function(id) {
      $state.go('app.employees.details',{id:id});
    }

    $scope.insertService=function() {
      var serv={
        id:1
      };
      serviceDataFactory.insertService(serv)
        .success(function(){
          $scope.status='Service was added! Refreshing service list.';
        })
        .error(function(error){
          $scope.status='Unable to add service: '+error.message;
        });
    };

    
  }]);
