'use strict';
App.controller('NewServiceCtrl', ['$scope','$state','$http','$stateParams','serviceDataFactory','serviceTypeDataFactory','Notification', 'FileUploader',
	function ($scope,$state,$http,$stateParams,serviceDataFactory,serviceTypeDataFactory,Notification,FileUploader){
  $scope.$on('$stateChangeSuccess',function(){
      if($state.is('app.newService'))
        getServiceTypes();
    });

  $scope.addButtonClicked=false;
  $scope.showAddButton=true;
  $scope.serviceType={};
  $scope.service={};

  function getServiceTypes() {
  	serviceTypeDataFactory.getServiceTypes()
  		.success(function(serviceTypes) {
  			$scope.serviceTypes=serviceTypes;  			
  		})
  		.error(function(error) {
  			$scope.status='Unable to get service types: '+error.message;
  		});
  };

  function clearAllFields() {
  	$scope.service.serviceName="";
  	$scope.service.price="";
  	$scope.service.description="";
  };
 
  $scope.info = function() {
    Notification.info('Service created');
  };

  $scope.clickAddServiceType=function() {  	
  	$scope.showAddButton=false;
  	$scope.addButtonClicked=true;
  };

  $scope.cancelAddServiceType=function() {
  	$scope.showAddButton=true;
  	$scope.addButtonClicked=false;
  };

  $scope.addNewServiceType=function() {
  	serviceTypeDataFactory.insertServiceType($scope.serviceType)
  		.success(function() {
  			$scope.cancelAddServiceType();
  			getServiceTypes();
  		})
  		.error(function(error) {
  			$scope.status="Unable to add service type: "+error.message;
  		})
  };

  $scope.addNewService=function() {
  	 $scope.service.serviceTypeId=$scope.serviceType.selected.serviceTypeId;
  	 serviceDataFactory.insertService($scope.service)
  	 	.success(function() {
  	 		$scope.info();
  	 		clearAllFields();
  	 	})
  	 	.error(function(error) {
  	 		$scope.status="Unable to add service: "+error.message;
  	 	})
  };


  // Uploader
  var uploader = $scope.uploader = new FileUploader({
        url: './api/img/services'
    });

    // FILTERS

    uploader.filters.push({
        name: 'customFilter',
        fn: function(item /*{File|FileLikeObject}*/, options) {
            return this.queue.length < 10;
        }
    });

    // CALLBACKS

    uploader.onWhenAddingFileFailed = function(item /*{File|FileLikeObject}*/, filter, options) {
        console.info('onWhenAddingFileFailed', item, filter, options);
    };
    uploader.onAfterAddingFile = function(fileItem) {
        console.info('onAfterAddingFile', fileItem);
    };
    uploader.onAfterAddingAll = function(addedFileItems) {
        console.info('onAfterAddingAll', addedFileItems);
    };
    uploader.onBeforeUploadItem = function(item) {
        console.info('onBeforeUploadItem', item);
    };
    uploader.onProgressItem = function(fileItem, progress) {
        console.info('onProgressItem', fileItem, progress);
    };
    uploader.onProgressAll = function(progress) {
        console.info('onProgressAll', progress);
    };
    uploader.onSuccessItem = function(fileItem, response, status, headers) {
        console.info('onSuccessItem', fileItem, response, status, headers);
    };
    uploader.onErrorItem = function(fileItem, response, status, headers) {
        console.info('onErrorItem', fileItem, response, status, headers);
    };
    uploader.onCancelItem = function(fileItem, response, status, headers) {
        console.info('onCancelItem', fileItem, response, status, headers);
    };
    uploader.onCompleteItem = function(fileItem, response, status, headers) {
        console.info('onCompleteItem', fileItem, response, status, headers);
    };
    uploader.onCompleteAll = function() {
        console.info('onCompleteAll');
    };

  
}]);