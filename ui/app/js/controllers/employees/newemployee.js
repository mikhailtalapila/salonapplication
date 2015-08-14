'use strict';
App.controller('NewEmployeeCtrl', ['$scope','$state','$http','$stateParams','employeeDataFactory','Notification', 'FileUploader',
	function ($scope,$state,$http,$stateParams,employeeDataFactory,Notification,FileUploader){
  
    $scope.employee={};
    $scope.gender={};
  
    $scope.genders=[
    	{gender:'male',code:'m'},
    	{gender:'female',code:'f'}
    ];

    var uploader = $scope.uploader = new FileUploader({
        url: './api/img/employees'
    });

    $scope.info = function() {
    Notification.info('Employee added');
  	};

    $scope.addNewEmployee=function() {
  	 $scope.employee.gender=$scope.gender.selected.code;
  	 employeeDataFactory.insertEmployee($scope.employee)
  	 	.success(function() {
  	 		$scope.info();
  	 		clearAllFields();
  	 	})
  	 	.error(function(error) {
  	 		$scope.status="Unable to add employee: "+error.message;
  	 	})
  	};

  	function clearAllFields() {
  	    $scope.employee.firstName="";
  	    $scope.employee.lastName="";
  	    $scope.employee.lastInitial="";
  	    $scope.employee.phoneNumber="";
  	    $scope.employee.alternatePhoneNumber="";
  	    $scope.employee.address="";
  	    $scope.employee.title="";
  	    $scope.employee.remarks="";
    };
  
}]);