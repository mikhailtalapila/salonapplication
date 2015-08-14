
'use strict';
App.controller('NewCustomerCtrl', ['$scope','$state','$http','$stateParams','customerDataFactory','Notification', 'FileUploader',
	function ($scope,$state,$http,$stateParams,customerDataFactory,Notification,FileUploader){
    
    $scope.customer={};
    $scope.gender={};
    var uploader = $scope.uploader = new FileUploader({
        url: './api/img/customers'
    });
  
    $scope.genders=[
    	{gender:'male',code:'m'},
    	{gender:'female',code:'f'}
    ];
    
    $scope.info = function() {
    Notification.info('Customer added');
  	};

    $scope.addNewCustomer=function() {
  	 $scope.customer.gender=$scope.gender.selected.code;
  	 customerDataFactory.insertCustomer($scope.customer)
  	 	.success(function() {
  	 		$scope.info();
  	 		clearAllFields();
  	 	})
  	 	.error(function(error) {
  	 		$scope.status="Unable to add customer: "+error.message;
  	 	})
  	};

  	function clearAllFields() {
  	$scope.customer.firstName="";
  	$scope.customer.lastName="";
  	$scope.customer.phoneNumber="";
  	$scope.customer.alternatePhoneNumber="";
  	$scope.customer.email="";
  	$scope.customer.remarks="";
  };

}]);