'use strict';
//factories only work for default types, use $http for custom api calls
app.factory('Job', function ($resource, $rootScope) {
    return $resource('api/v1/Jobs/:id',
    { id: '@id' },
    { 'update': { method: 'PUT', async: false } },
    { 'query': { method: 'GET', isArray: false, async: false } });
});

app.factory('User', function ($resource) {
    return $resource('/api/v1/Users/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});

app.factory('LoginService', function ($q, $http, $window) {
    var processLogin = function (username, password) {
        var deferred = $q.defer();
        $http({
            method: 'POST',
            data: "username=" + username + "&password=" + password + "&grant_type=password",
            async: false,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: '/Token',
            isArray: false
        }).success(function (data, status) {
            $window.sessionStorage.setItem('token', data.access_token);            
            deferred.resolve();
        }).error(function (data, status) {
            $window.sessionStorage.removeItem('token');
            deferred.reject(status);
        });

        return deferred.promise;
    };

    return { processLogin: processLogin };    
});

app.factory('GetMessages', function ($q, $http) {
    var messageArray = [];

    var getMessages = function () {
        var deferred = $q.defer();
        $http({ method: 'GET', url: '/app/api/v1/Messages/' })
        .success(function (data) {
            //messageArray.clear();
            for (var message in data) {
                messageArray.push(data[message]);
            }
            deferred.resolve(data);
        });
        return deferred.promise;
    }

    //Initialize any bindings
    getMessages();

    return { getMessages: getMessages, Messages: messageArray }
});
//DLR added GetSavedJobs factory
app.factory('GetSavedJobs', function ($q, $http) {
    return {
        getSJ: function (successCB) {
            $http({ method: 'GET', url: '/app/api/v1/SavedJob/' })
            .success(function (data, status,headers,config) {
                successCB(data);
            })
            .error(function (data, status, headers, config) {
                $log.warn(data, status, headers, config);
            });
        }
    }
});
//DLR added GetSavedJobs factory 5/6 working factory service to Get All Resumes
app.factory('GetResumesService', function ($q, $http, $log) {
    return {
        getAllResumes: function (successCB) {
            $http({ method: 'GET', url: '/app/api/v1/Resumes/' })
            .success(function (data, status, headers, config) {
                successCB(data);
            })
            .error(function (data, status, headers, config) {
                $log.warn(data, status, headers, config);
            });
        }
    }
});
//app.factory('CheckMessage', function ($rootScope) {
//    var factory = {};
//    factory.getMessages = function () {
//        $rootScope.messageArray = [];
//        $http({ method: 'GET', url: '/app/api/v1/Messages/' })
//        .success(function (data) {
//            $rootScope.unreadCount = 0;
//            for (var message in data) {
//                if (!data[message].dateRead) {
//                    $rootScope.unreadCount += 1;
//                }
//                $rootScope.messageArray.push(data[message]);
//            };
//        })
//        .error(function (data) { console.log(data);});
//    }
//    return factory;
//});

app.factory('JobStatus', function ($resource) {
    return $resource('api/v1/JobStatus/:id',
   { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('CompanyVM', function ($resource) {
    return $resource('api/v1/Company/:id', {}, {
        update: { method: 'PUT', params: { id: '@id' } },
        delete: { method: 'DELETE', params: { id: '@id' } }
    })
});

app.factory('Resume', function ($resource) {
    return $resource('api/v1/Resumes/:id',
    { id: '@id' },
    { 'get': { method: 'GET', isArray: false } },
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
app.factory('Message', function ($resource) {
    return $resource('api/v1/Messages/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('Application', function ($resource) {
    return $resource('api/v1/Applications/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('JobTimeStamp', function ($resource) {
    return $resource('api/v1/JobTimeStamps/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('Note', function ($resource) {
    return $resource('api/v1/Notes/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('SavedJob', function ($resource) {
    return $resource('api/v1/SavedJobs/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});
app.factory('Skill', function ($resource) {
    return $resource('api/v1/Skills/:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'query': { method: 'GET', isArray: false } });
});

app.factory('ResumeService', function ($http, $rootScope) {
    return {
        getResume: function (id) {
            var Data = {};
            $http({ method: 'GET', async: false, url: '/app/api/v1/Resumes/' + id })
            .success(function (data) {
                $rootScope.ResumeFromAjax = data;
            })
            .error(function (data) {
                alert(data);
            });
        },
        getResumes: function () {
            $http({ method: 'GET', url: '/app/api/v1/Resumes/' })
            .success(function (data) {
                $rootScope.ResumesFromAjax = data;
            })
            .error(function (data) {
                alert(data);
            });
        }
    }
});

app.factory('Upload', function ($resource) {
    return $resource('/api/files:id',
    { id: '@id' },
    { 'update': { method: 'PUT' } },
    { 'save': { method: 'POST', isArray: false } },
    { 'query': { method: 'GET', isArray: false } });
});

app.factory('AuthInterceptor', function ($window, $q, $rootScope, $location) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            if ($window.sessionStorage.getItem('token')) {
                config.headers.Authorization = 'Bearer ' + $window.sessionStorage.getItem('token');
            }
            return config || $q.when(config);
        },
        requestError: function (rejection) {
            return $q.reject(rejection);
        },
        response: function (response) {
            if (response.status === 401) {
                $location.path('/error/' + response.status, true);
            }
            return response || $q.when(response);
        },
        responseError: function (rejection) {
            if ($location.path() != '/')
                $location.path('/error/' + rejection.status, true);
            return $q.reject(rejection);
        }
    };
});

app.factory('sessionHandler', ['$http', '$location', function ($http, $location) {
    var setLoggedIn = function () {
        s['auth'] = true;
        sessionStorage.data = angular.toJson(s);
    };
    var redirectHome = function () {
        s = {};
        sessionStorage.data = angular.toJson(s);
        if ($location.path() !== '/')
            $location.path('/', true);
    };
    if (angular.isDefined(sessionStorage.init)) {
        var s = angular.fromJson(sessionStorage.data);
    } else {
        var s = {};
        sessionStorage.init = true;
    }
    return {
        set: function (key, val) {
            s[key] = val;
            sessionStorage.data = angular.toJson(s);
        },
        get: function (key) {
            if (!angular.isDefined(s[key])) {
                return false;
            }
            return s[key];
        },
        logout: function () {
            $http.post('/api/Account/Logout').success(function () {
                var s = {};
                sessionStorage.data = angular.toJson(s);
                sessionStorage.clear();
                //window.location = window.location.origin + window.location.pathname;
            });
        },
        checkLoggedIn: function () {
            if (s['auth']) {
                return true;
            } else {
                $http.post('/api/Account/AuthStatus').success(setLoggedIn).error(redirectHome);
            }
        }
    };
}]);

app.factory('breadcrumbs', ['ngBread'])