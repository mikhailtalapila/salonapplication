'use strict';

angular.module('desktopApp')
  .controller('AppointmentsListCtrl', ['$scope','$state','$http', 'appointmentDataFactory',function ($scope,$state,$http,appointmentDataFactory) {
    
    $scope.$on('$stateChangeSuccess',function(){
     	if ($state.is('appointments.list'))
        	getAppointments();
    	});

    function getAppointments() {
      appointmentDataFactory.getAppointments()
        .success(function(appts){
          $scope.appointments=appts;
        })
        .error(function(error){
          $scope.status='Unable to load appointments data: '+error.message;
        });
    };

    $scope.updateAppointment=function(id) {
      var appt;
      for (var i = 0; i < $scope.appointments.length; i++) {
        var currAppt=$scope.appointments[i]
        if(currAppt.appointmentId===id) {
          appt=currAppt;
          break;
        }
      }

      appointmentDataFactory.updateAppointment(appt)
        .success(function(){
          $scope.status='Updated appointment! Refreshing appointment list';
        })
        .error(function(error){
          $scope.status='Unable to update appointment: '+error.message;
        });
    };


  	$scope.viewDetails=function(id){
      $state.go('appointments.details',{id:id})
    };

    $scope.insertAppointment=function(){
      var appt={
        //some appointment info
        id:1
      };
      appointmentDataFactory.insertAppointment(appt)
        .success(function(){
          $scope.status='Appointment was added! Refreshing appointment list';
          $scope.appointments.push(appt);
        })  
        .error(function(error){
          $scope.status='Unable to add appointment data'+error.message;
        });
    };

    $scope.deleteAppointment=function(id){
      appointmentDataFactory.deleteAppointment(id)
        .success(function() {
          $scope.status='Deleted Appointment! Refreshing appointment list';
          for (var i = 0; i < $scope.appointments.length; i++) {
            var appt=$scope.appointments[i];
            if(appt.appointmentId===id) {
              $scope.appointments.splice(i,1);
              break;
            }
          }
        })
        .error(function(error){
          $scope.status='Unable to delete appointment'+error.message;
        });
    };

}]);
