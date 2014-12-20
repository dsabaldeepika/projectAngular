'use strict';
//alert('its working');
app.controller('globalCtrl', function ($scope, Register, $http, $routeParams, $rootScope, $location, $window, sessionHandler) {
    //Register Controls
    $scope.register = {};

    $scope.registerTalent = function () {
        Register.save($scope.register, function () {
            //$scope.registerArray.push($scope.register);
            $scope.register = {
                username: '',
                password: '',
                confirmPassword: '',
                firstName: '',
                lastName: '',
            };

        });
    };
    $scope.registerCompany = function () {
        Register.save($scope.register, function () {
            //$scope.registerArray.push($scope.register);
            $scope.register = {
                username: '',
                password: '',
                confirmPassword: '',
                firstName: '',
                lastName: '',
            };
        });
    };

    $scope.httpStatusCode = $routeParams.statusCode;

    $scope.getUser = function () {
        $http({
            method: 'GET',
            url: '/api/v1/Users'
        }).success(function (data, status) {
            console.log(data);
            $rootScope.currentUser = data;
            $rootScope.loggedIn = true;
            $window.sessionStorage.setItem("userRole", data.roleName);
            //$location.path('/userprofile');
            //if (data.Role === "Administrator") {
            //    $location.path('/front');
            //} else if (data.Role === "Employer") {
            //    $location.path('/companies');
            //} else if (data.Role === "User") {
            //    $rootScope.companyLogedIn = true;
            //    $location.path('/userprofile');
            //}
            //else {
            //    $rootScope.companyLogedIn = true;
            //    $location.path('/CompanyUser');
            //}
        }).error(function (data, status) {
            $scope.status = status;
        });
    };
    var LogOffController = function ($scope, $rootScope, $location) {
        $scope.logoff = function () {
            $rootScope.currentUser = null;
            $rootScope.token = null;
            $rootScope.loggedIn = false;
            $rootScope.companyLogedIn = false;
            $location.path('/');
            console.log("logged off");
        }
    }
    $scope.talentRedirect = function () {
        $location.path('/talentcreate')
        $scope.showModal = false;
    };
    $scope.companyRedirect = function () {
        $location.path('/companycreate')
        $scope.showModal = false;
    };

    $scope.gotoDashboard = function () {
        alert(angular.toJson($rootScope.currentUser));
    }

    $scope.gotoSettings = function () {

    }
});




