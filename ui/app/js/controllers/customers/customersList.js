'use strict';
App.controller('CustomersListCtrl', ['$http','$scope','$state','$modal','modalService','customerDataFactory',function ($http,$scope,$state,$modal,modalService,customerDataFactory){
  	
    $scope.$on('$stateChangeSuccess',function(){
      if ($state.is('app.customers.list'))
        getCustomers();
    });

    function getCustomers() {
      customerDataFactory.getCustomers()
        .success(function(custs){
          $scope.customers=custs;
          if($scope.customers!=null && $scope.customers!==undefined) {
            angular.forEach($scope.customers,function(customer) {
              if(customer.gender==='m'){
                customer.imageSource='app/img/customers/unknownmale.jpg';
              } else {
                customer.imageSource='app/img/customers/unknownfemale.jpg';
              }
            });
          }
        })
        .error(function(error){
          $scope.status='Unable to load customer data: '+error.message;
        });
    };

  	

    $scope.updateCustomer=function(id) {
      var cust;
      for (var i = 0; i < $scope.customers.length; i++) {
        var currCust=$scope.customers[i];
        if(currCust.customerId===id) {
          cust=currCust;
          break;
        }
      }

      customerDataFactory.updateCustomer(cust)
        .success(function () {
          $scope.status='Updated Customer! Refreshing customer list';
        })
        .error(function(error){
          $scope.status='Unable to update customer: '+error.message;
        });
    };

    $scope.viewDetails=function(id){
      $state.go('app.customers.details',{id:id})
    };


    $scope.showCreateNewCustomerDialog=function() {
      var modalInstance=$modal.open({
        templateUrl:'createNewCustomer.html',
        animation: false,
        size:'lg',
        controller:'ModalInstanceCtrl',
        resolve: {
          items: function () {
            return $scope.customer;
          }
        }
      });
      modalInstance.result.then(function(customer) {
        $scope.customer=customer;
        console.log($scope.customer);
      });
    };

    $scope.insertCustomer=function() {
      var cust= {
        customerId:10,
        firstName:'Kim',
        lastName:'Smith'
      };
      customerDataFactory.insertCustomer(cust)
        .success(function() {
          $scope.status='Inserted Customer! Refreshing customer list';
          $scope.customers.push(cust);
        })
        .error(function(error) {
          $scope.status='Unable to insert customer: '+error.message;
        });
    };

    $scope.deleteCustomer=function(id) {
      customerDataFactory.deleteCustomer(id)
        .success(function(){
          $scope.status='Deleted Customer! Refreshing customer list';
          for (var i = 0; i < $scope.customers.length; i++) {
            var cust=$scope.customers[i];
            if(cust.customerId===id) {
              $scope.customers.splice(i,1);
              break;
            }            
          }
          $scope.appointments=null;
        })
        .error(function(error) {
          $scope.status='Unable to delete customer: '+error.message;
        });
    };


    $scope.getAppointments=function(id) {
       customerDataFactory.getAppointments(id)
        .success(function(appointments){
          $scope.status='Retrieved appointments!';
          $scope.appointments=appointments;
        })
        .error(function(error){
          $scope.status='Error retrieving appointments '+error.message;
        });
    };   

    
  }]);
