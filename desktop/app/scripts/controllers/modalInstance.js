'use strict';
angular.module('desktopApp')
	.controller('ModalInstanceCtrl',['$scope','$modalInstance',function ($scope,$modalInstance){
		$scope.submit=function() {
			$modalInstance.close();
		}
		$scope.cancel=function() {
			$modalInstance.dismiss('cancel');
		}
	}]);