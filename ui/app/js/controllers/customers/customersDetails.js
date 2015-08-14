'use strict';
App.controller('CustomersDetailsCtrl', ['$scope',  '$http','$state','$stateParams','customerDataFactory','editableOptions', 'editableThemes', '$filter',
  function($scope,  $http, $state, $stateParams, customerDataFactory, editableOptions, editableThemes, $filter) {

  	getCustomer();
    editableOptions.theme = 'bs3';

    editableThemes.bs3.inputClass = 'input-lg';
    editableThemes.bs3.buttonsClass = 'btn-lg';
    editableThemes.bs3.submitTpl = '<button type="submit" class="btn btn-success"><span class="fa fa-check"></span></button>';
    editableThemes.bs3.cancelTpl = '<button type="button" class="btn btn-default" ng-click="$form.$cancel()">'+
                                     '<span class="fa fa-times text-muted"></span>'+
                                   '</button>';

    $scope.genders = [
      {value: 'f', text: 'female'},
      {value: 'm', text: 'male'}
    ];

    $scope.customerId=$stateParams.id;
  	function getCustomer() {
  		customerDataFactory.getCustomer($stateParams.id)
  			.success(function(cust) {
  				$scope.customer=cust;  				
  			})
  			.error(function(error) {
  				$scope.status='Unable to get customer: '+error.message;
  			});
  	}
  	$scope.showGender = function() {
      			var selected = $filter('filter')($scope.genders, {value: $scope.customer.gender});
      			console.log('here');
      			return ($scope.customer.gender && selected.length) ? selected[0].text : 'Not set';      			
    			};

  	$scope.$watch('customer.gender', function(newVal, oldVal) {
    if (newVal !== oldVal) {
      var selected = $filter('filter')($scope.genders, {value: $scope.customer.gender});
      $scope.customer.gender = selected.length ? selected[0].value : null;
      $scope.updateCustomer();
      //console.log($scope.customer.gender);
    }
  	});


  	$scope.updateCustomer=function() {
  		return customerDataFactory.updateCustomer($scope.customer);
  	}
  	

    

 

}]);
