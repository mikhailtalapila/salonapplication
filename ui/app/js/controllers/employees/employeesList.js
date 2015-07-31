'use strict';
App.controller('EmployeesListCtrl', ['$http','$scope','$state','employeeDataFactory','$modal',function ($http,$scope,$state,employeeDataFactory,$modal){
  	
  	$scope.$on('$stateChangeSuccess',function(){
      if($state.is('app.employees.list'))
        getEmployees();
    });

    function getEmployees() {
      employeeDataFactory.getEmployees()
        .success(function(emps){
          $scope.employees=emps;
        })
        .error(function(error){
          $scope.status='Unable to load employees data: '+error.message;
        });
    };

    $scope.updateEmployee=function(id) {
      var emp;
      for (var i = 0; i < $scope.employees.length; i++) {
        var currEmp=$scope.employees[i];
        if(currEmp.employeeId===id) {
          emp=currEmp;
          break;
        }
      }

      employeeDataFactory.updateEmployee(emp)
        .success(function(){
          $scope.status='Updated employee! Refreshing employee list';
        })
        .error(function(error){
          $scope.status='Unable to update employee: '+error.message;
        });
    };


    $scope.viewDetails=function(id){
      $state.go('app.employees.details',{id:id})
    };

    $scope.insertEmployee=function(){
      var emp=$scope.employee;
      employeeDataFactory.insertEmployee(emp)
        .success(function(){
          $scope.status='Employee was added! Refreshing employee list';
          $scope.employees.push(emp);
        })
        .error(function(error){
          $scope.status='Unable to add employee data '+error.message;
        });
    };

    $scope.deleteEmployee=function(id) {
      employeeDataFactory.deleteEmployee(id)
        .success(function() {
          $scope.status='Deleted Employee! Refreshing appointment list';
          for (var i = 0; i < $scope.employees.length; i++) {
            var emp=$scope.employees[i];
            if(emp.employeeId===id) {
              $scope.employees.splice(i,1);
              break;
            }
          }
        })
        .error(function(error){
          $scope.status='Unable to delete employee: '+error.message;
        });
    };

    $scope.employee={
      firstName:'Tammy',
      lastName:'Talapila',
      imageSource:'employee13.jpg',
      remarks:'Here are some remarks for Tammy Talapila, the employee'
    };0

    $scope.showForm=function() {
      var modalInstance=$modal.open({
        templateUrl:'/views/partials/newEmployeeModal.html',
        backdrop:true,
        animation: false,
        windowClass:'modal',
        controller:function($scope,$modalInstance,employee) {
          $scope.employee=employee;
          $scope.submit=function(){
            $modalInstance.close('closed');
          }
          $scope.cancel=function() {
            $modalInstance.dismiss('cancel');
          };
        },
        resolve: {
          employee: function() {
            return $scope.employee;
          }
        }
      });
      modalInstance.result.then(function(selectedEmployee){
        $scope.employee=selectedEmployee;
      }, function() {
        $scope.insertEmployee($scope.employee);
        console.log('Modal dismissed at '+new Date());
      });
    };

  }]);


