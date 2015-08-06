'use strict';
App.controller('CustomersDetailsCtrl', ['$scope',  '$http','$state','$stateParams','customerDataFactory','editableOptions', 'editableThemes', '$filter',
  function($scope,  $http, $state, $stateParams, customerDataFactory, editableOptions, editableThemes, $filter) {

  	getCustomer();
    editableOptions.theme = 'bs3';

    editableThemes.bs3.inputClass = 'input-sm';
    editableThemes.bs3.buttonsClass = 'btn-sm';
    editableThemes.bs3.submitTpl = '<button type="submit" class="btn btn-success"><span class="fa fa-check"></span></button>';
    editableThemes.bs3.cancelTpl = '<button type="button" class="btn btn-default" ng-click="$form.$cancel()">'+
                                     '<span class="fa fa-times text-muted"></span>'+
                                   '</button>';

    $scope.genders = [
      {value: 1, text: 'female'},
      {value: 2, text: 'male'}
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
      return ($scope.customer.gender && selected.length) ? selected[0].text : 'Not set';
    };

    


    $scope.$watch('user3.id', function(newVal, oldVal) {
      if (newVal !== oldVal) {
        var selected = $filter('filter')($scope.groups, {id: $scope.user3.id});
        $scope.user3.text = selected.length ? selected[0].text : null;
      }
    });


}]);
