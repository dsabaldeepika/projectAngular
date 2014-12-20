'use strict';

app.factory('Job', function ($resource, $rootScope) {

    return $resource('api/v1/Jobs/:id',
    { id: '@id' },
    {
        'update': {
            method: 'PUT',
            async: false,
            headers: { 'Authorization': 'Bearers ' + $rootScope.Token }
        }
    },
    {
        'query':
          {
              method: 'GET',
              isArray: false,
              async: false,
              headers: { 'Authorization': 'Bearers ' + $rootScope.Token }
          }
    });
});

app.factory('User', function ($resource) {
    return $resource('/api/v1/Users/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('Message', function ($resource) {
    return $resource('api/v1/Messages/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('JobStatus', function ($resource) {
    return $resource('api/v1/JobStatus/:id',
   { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('Company', function ($resource) {
    return $resource('api/v1/Company/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('Resume', function ($resource) {
    return $resource('api/v1/Resume/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('Click', function ($resource) {
    return $resource('api/v1/Clicks/:id',
        {},
        //{ id: '@id' },
   // { 'save': { method: 'POST', headers: { 'Content-Type' : 'application/json'} }   },//CREATED, not needed unless trying to override default save
    //{ 'query': { method: 'GET', isArray: false } },//READ, not needed unless trying to override default 
    { 'update': { method: 'PUT', params: { id: '@id' } } } //UPDATE, needed since angular does not
   // { 'update': { method: 'PUT' } },

    //{ 'delete': { method: 'DELETE', params: { id: '@id' } } });//DELETE, not needed unless trying to override default  

    )
});

app.factory('Testput', function ($resource) {
    return $resource('api/v1/Clicks/:id', {}, {

        update: { method: 'PUT', params: { id: '@id' } },
        delete: { method: 'DELETE', params: { id: '@id' } }
    })
});

app.factory('Register', function ($resource) {
    return $resource('/api/Account/Register/:id',
    { id: '@id' },
    {
        'save': {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' }
        }
    },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });

});
//app.factory('Login', function ($resource, $http, $q) {
//    return $resource('/Token',
//        {
//            'save': {
//                method: 'POST',
//                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
//                data: 'grant_type=password' + '&username=' + document.getElementById('username').value + '&password=' + document.getElementById('password').value,
//                withCredentials: true
//            }
//        })
//    var service = {};
//    service.loginToken = {};
//    service.getAccessToken = function () {
//        return loginToken.access_token;
//    };
//    service.login = function (userName, password) {
//        var deferred = $q.defer();
//        var loginData = {
//            grant_type: "password",
//            username: userName,
//            password: password
//        };
//        $http({
//                method: 'POST',
//                url: '/Token',
//                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
//                data: $.param(loginData)
//                    //
//            }
//        )
//            .success(function (response) {
//                service.loginToken = response;
//                deferred.resolve(response);
//            })
//            .error(function (response) {
//                deferred.reject(response);
//            });
//        return deferred.promise;
//    };
//    service.logout = function () {
//        var deferred = $q.defer();
//        $http({
//            method: 'POST',
//            url: '/api/Account/Logout',
//            headers: { 'Authorization': 'Bearer ' + this.loginToken.access_token },
//        })
//            .success(function (response) {
//                service.loginToken = [];
//                deferred.resolve(response);
//            })
//            .error(function (response) {
//                deferred.reject(response);
//            });

//        return deferred.promise;
//    };
//    return service;
//});

app.factory('Upload', function ($resource) {
    return $resource('/api/files:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'save': { method: 'POST', isArray: false } },
    { 'query': { method: 'GET', isArray: false } });

});

app.factory('AuthInterceptor', function ($window, $q, $rootScope) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            //if ($window.sessionStorage.getItem('token')) {
            //    config.headers.Authorization = 'Bearer ' + $window.sessionStorage.getItem('token');
            //}

            if ($rootScope.token != null) {
                config.headers.Authorization = 'Bearer ' + $rootScope.token;
            }
            return config || $q.when(config);
        },
        response: function (response) {
            if (response.status === 401) {
                // TODO: Redirect user to login page.
            }
            return response || $q.when(response);
        }
    };
});
