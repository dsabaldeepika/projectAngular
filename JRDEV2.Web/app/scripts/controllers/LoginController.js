app.controller('LoginController', function ($scope, $http, $rootScope, $location, $window, sessionHandler, GetMessages, LoginService, $q, $timeout) {
    $scope.login = {};
 //   $scope.isLoggedIn = false;
    
    //$scope.isLoading = false;

    $scope.getIsLoggedIn = function () {
        if (sessionHandler.get('auth')) {
            $scope.isLoggedIn = true;
 //           alert("called gitIsLoggedIn, and it is true");
        }
        else {
            $scope.isLoggedIn = false;
  //          alert("called gitIsLoggedIn, and it is false");
        }
        return $scope.isLoggedIn;
    }

    $scope.processLogin = function () {
        return LoginService.processLogin($scope.login.username, $scope.login.password).then(function () {
            $('#loginModal').modal('hide');
            $scope.isLoggedIn = true;
            $scope.getUser();
        }, function (status) {
            $scope.status = status;
            alert("Invalid Username or Password, please try again.");
        });
    };

    $scope.getUser = function () {
        $http({
            method: 'GET',
            async: false,
            url: '/api/v1/Users/Login'
        }).success(function (data, status) {
            $rootScope.currentUser = data;
            $rootScope.loggedIn = true;
            GetMessages.getMessages();
            var path = "";
            switch (data.roleName) {
                case "TalentUser": { path = "talentdashboard" } break;
                case "CompanyAdmin": { path = "companydashboard"} break;
                case "CompanyUser": { path = "companydashboard" } break;
                case "SiteAdmin": { path = "#"} break;
                default: { path="#"} break;
            }
            console.log(path);
            $location.path(path);
        }).error(function (data, status) {
            $scope.status = status;
        });
    };

    $scope.getUserNoRedirect = function () {
        if ($scope.isLoggedIn)
        {
            $http({
                method: 'GET',
                async: false,
                url: '/api/v1/Users/Login'
            }).success(function (data, status) {
                $rootScope.currentUser = data;
            }).error(function (data, status) {
                $scope.status = status;
            });
        }
    };
    //var LogOffController = function ($scope, $rootScope, $location, sessionHandler) {
    //    $scope.logoff = function () {
    //        $rootScope.currentUser = null;
    //        $rootScope.token = null;
    //        $rootScope.loggedIn = false;
    //        sessionHandler.logout();
    //        $rootScope.companyLogedIn = false;
    //        $location.path('/');
    //        console.log("logged off");
    //    }
    //}
    $scope.logoff = function () {
        $rootScope.currentUser = null;
        $rootScope.token = null;
        $rootScope.loggedIn = false;
        sessionHandler.logout();
        $rootScope.companyLogedIn = false;
        $scope.isLoggedIn = false;
        $location.path('/');
        //hacky way to refresh
        $window.location.reload();
        console.log("logged off");
    }

    $scope.gotoDashboard = function () {
        var path = "";
        switch ($rootScope.currentUser.roleName) {
            case "TalentUser": { path = "talentdashboard"; } break;
            case "CompanyAdmin": { path = "companydashboard"; } break;
            case "CompanyUser": { path = "companydashboard"; } break;
            case "SiteAdmin": { path = "#"; } break;
            default: { path = "#";} break;
        }
        $location.path(path);
    }

    $scope.gotoSettings = function () {
        var path = "";
        switch ($rootScope.currentUser.roleName) {
            case "TalentUser": { path = "talentsettings"; } break;
            case "CompanyAdmin": { path = "companysettings"; } break;
            case "CompanyUser": { path = "companysettings"; } break;
            case "SiteAdmin": { path = "#"; } break;
            default: { path = "#"; } break;
        }
        $location.path(path);
    }
});