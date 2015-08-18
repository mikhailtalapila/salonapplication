'use strict';
App.controller('ServicesDetailsCtrl', ['$scope','$state','$stateParams','serviceDataFactory','Notification','ngDialog',
  function($scope,$state,$stateParams,serviceDataFactory,Notification,ngDialog){
  	getService();
  	$scope.serviceId=$stateParams.id;
  	$scope.service=serviceDataFactory.getService($stateParams.id);  	
  	
  	function getService() {
  		serviceDataFactory.getService($stateParams.id)
  			.success(function(serv) {
  				$scope.service=serv;  				
  			})
  			.error(function(error) {
  				$scope.status='Unable to get service: '+error.message;
  			});
  	}

    $scope.info = function() {

     Notification.info('Qualification edited');
    };

    $scope.editQualifications=function() {
      $scope.info();
      console.log('clicked');
    }
       

    $scope.deleteService = function (id) {
    ngDialog.openConfirm({
      template: 'modalDialogId',
      className: 'ngdialog-theme-default'
    }).then(function () {
      serviceDataFactory.deleteService(id)
        .success(function() {
          Notification.error('Service is deleted.');
          $state.go('app.services.list');
        })
        .error(function(error) {
          Notification.error('Unable to delete service: '+error.message);
        });
    }, function () {
      
    });
  };

  }]);