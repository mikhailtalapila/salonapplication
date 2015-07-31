'use strict';
angular.module('desktopApp')
  .controller('EmployeesScheduleListCtrl', ['$http','$scope','$state','employeeScheduleDataFactory',function($http,$scope,$state,employeeScheduleDataFactory){
  	
  	$scope.$on('$stateChangeSuccess',function(){
      if($state.is('employeesSchedule.list'))
        getEmployeeSchedules();
    });

    function getEmployeeSchedules() {
      employeeScheduleDataFactory.getEmployeeSchedules()
        .success(function(empScheds){
          $scope.employeeSchedules=empScheds;
        })
        .error(function(error){
          $scope.status='Unable to get employee schedules: '+error.message;
        });
    };

    $scope.updateEmployeeSchedule=function(id) {
      var empSched;
      for (var i = 0; i < $scope.employeeSchedules.length; i++) {
        var currEmpSched=$scope.employeeSchedules[i];
        if(currEmpSched.employeeScheduleId===id){
          empSched=currEmpSched;
          break;
        }
      }

      employeeScheduleDataFactory.updateEmployeeSchedule(empSched)
        .success(function(){
          $scope.status='Updated employee schedule! Refreshing employee schedule list'
        })
        .error(function(error){
          $scope.status='Unable to update employee schedule:'+ error.message;
        });
    };

    $scope.viewDetails=function(id){
      
      $state.go('employeesSchedule.details',{id:id});
    };
    
    $scope.insertEmployeeSchedule=function() {
      var empSched={
        id:1
      };
      employeeScheduleDataFactory.insertEmployeeSchedule(empSched)
        .success(function(){
          $scope.status='Employee schedule was added! Refreshing employee schedule list.';
        })
        .error(function(error){
          $scope.status='Unable to add employee schedule: '+error.message;
        });
    };

    $scope.deleteEmployeeSchedule=function(id) {
      employeeScheduleDataFactory.deleteEmployeeSchedule(id)
        .success(function(){
          $scope.status='Employee schedule is deleted! Refreshing employee schedule list.';
          for (var i = 0; i < $scope.employeeSchedules.length; i++) {
            var empSched=$scope.employeeSchedules[i];
            if(empSched.employeeScheduleId===id) {
              $scope.employeeSchedules.splice(i,1);
              break;
            }
          }
        })
        .error(function(error) {
          $scope.status='Unable to delete employee schedule: '+error.message;
        });
    };

  }]);