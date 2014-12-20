/*global app:true*/
'use strict';

angular.module('rcForm', []).directive(rcSubmitDirective);

var app = angular.module('jrdevwebApp', [
  'ngCookies',
  'ngResource',
  'ngSanitize',
  'ngRoute',
  'ui.bootstrap',
  'ui.utils',
  'rcForm',
  'rcDisabledBootstrap'
])
app.config(function ($routeProvider, $httpProvider) {
    $routeProvider
     .when('/', {
         templateUrl: 'views/Home.html',
         controller: 'globalCtrl', title: 'Home'
     })
     .when('/company', {
         templateUrl: 'views/companiesView.html',
         controller: 'companyCtrl', title: 'Company'
     })
      .when('/companydashboard', {
          templateUrl: 'views/CompanyDashboard.html',
          controller: 'companyCtrl', title: 'Company Dashboard'
      })
        .when('/companyprofile', {
            templateUrl: 'views/CompanyProfile.html',
            controller: 'companyCtrl', title: 'Company Profile'
        })
      .when('/companysettings', {
          templateUrl: 'views/CompanySettings.html',
          controller: 'companyCtrl', title: 'Company Settings'
      })
        .when('/talentsettings', {
            templateUrl: 'views/TalentSettings.html',
            controller: 'talentCtrl', title: 'Talent Settings'
        })
        .when('/jobapplist/:id', {
            templateUrl: 'views/JobAppList.html',
            controller: 'jobCtrl', title: 'Job Application List',
        })
        .when('/jobappview/:id', {
            templateUrl: 'views/JobAppView.html',
            controller: 'jobCtrl', title: 'Job Application Preview'
        })
        .when('/panel-element-302510', {   // Panel element on JobAppList view ////
            templateUrl: 'views/JobAppList.html',
            controller: 'jobCtrl'
        })
        .when('/panel-element-772675', {  // Panel element on JobAppView view ////
            templateUrl: 'views/JobAppView.html',
            controller: 'jobCtrl'
        })
         .when('/companycreate', {
             templateUrl: 'views/CompanyCreate.html',
             controller: 'companyCtrl', title: 'Company Creation'
         })
        .when('/companyjoin', {
            templateUrl: 'views/CompanyJoin.html',
            controller: 'companyCtrl', title: 'Company Join'
        })
        .when('/jobmaker', {
            templateUrl: 'views/JobMaker.html',
            controller: 'jobCtrl', title: 'Make a Job'
        })
           .when('/jobview/:id', {
               templateUrl: 'views/JobView.html',
               controller: 'jobCtrl', title: 'Job View'
           })
             .when('/talentcreate', {
                 templateUrl: 'views/TalentCreate.html',
                 controller: 'talentCtrl', title: 'Create Talent'
             })
            .when('/talentdashboard', {
                templateUrl: 'views/TalentDashboard.html',
                controller: 'talentCtrl', title: 'Talent Dashboard'
            })
            .when('/talentprofile', {
                templateUrl: 'views/TalentProfile.html',
                controller: 'talentCtrl', title: 'Talent Profile'
            })
            .when('/talentresume', {
                templateUrl: 'views/TalentResume.html',
                controller: 'talentCtrl', title: 'Talent Resume'
                //,
                //resolve: {
                //    Resumes : function (ResumeService) {
                //        return ResumeService.getResumes();
                //    }
                //}
            })
        //DLR added route for viewing individual resume
            .when('/resumedetail/:id', {
                templateUrl: 'views/ResumeDetail.html',
                controller: 'talentCtrl', title: 'Resume Details'
            })
         .when('/inbox', {
             templateUrl: 'views/UserInbox.html',
             controller: 'messageCtrl', title: 'Inbox'
         })
        .when('/inbox/:id', {
            templateUrl: 'views/MessageDetail.html',
            controller: 'messageCtrl', title: 'Message'
        })
         .when('/companyinbox', { //ray created 
             templateUrl: 'views/CompanyInbox.html',
             controller: 'messageCtrl', title: 'Message'
         })
        .when('/companyinbox/:id', { //ray created 
            templateUrl: 'views/MessageDetail.html',
            controller: 'messageCtrl', title: 'Message'
        })
         .when('/search', {
             templateUrl: 'views/Search.html',
             controller: 'searchCtrl', title: 'Search'
         })
         .when('/search/:searchstring', {
             templateUrl: 'views/Search.html',
             controller: 'searchCtrl', title: 'Search'
         })
        .when('/login', {
            templateUrl: 'views/LoginView.html',
            controller: 'LoginController', title: 'Login'
        })
        .when('/register', {
            templateUrl: 'views/RegisterView.html',
            controller: 'RegisterController', title: 'Register'
        })
        .when('/error/:statusCode', {
            templateUrl: 'views/Error.html',
            controller: 'globalCtrl', title: 'Error'
        })
        .when('/jrdevsabout', {
            templateUrl: 'views/JrDevsAbout.html',
            controller: 'companyCtrl', title: 'About'
        })
        .when('/faq', {
            templateUrl: 'views/FAQ.html',
            controller: 'companyCtrl', title: 'FAQ'
        })
        .otherwise({
          redirectTo: '/'
      });
    $httpProvider.interceptors.push('AuthInterceptor');
});

app.run(['$rootScope', 'sessionHandler', '$location', '$route', function ($rootScope, sessionHandler, $location, $route) {
    $rootScope.$on('$routeChangeStart', function (event, next, current) {
        if (($location.path() === '/search') ||
            $location.path() === '/talentcreate' ||
            $location.path() === '/companycreate' ||
            $location.path() === '/jrdevsabout' ||
            $location.path() === '/faq' ||
            next.title === 'Error' || sessionHandler.checkLoggedIn() && ($location.path() !== '' && $location.path() !== '/')) {
            $location.path();
        }
        
        //if (sessionHandler.checkLoggedIn() && ($location.path() === '' || $location.path() === '/')) {
        //    $location.path('/main', true);
        //}
        
    })

    $rootScope.$on("$routeChangeSuccess", function (currentRoute, previousRoute) {
        $rootScope.title = $route.current.title;
        // GetMessages();

        //if (sessionHandler.checkLoggedIn) {
        //    CheckMessage.getMessages();
        //}
    });
}]);

//pagination filter//
//app.filter('startFrom', function () {
//    return function (input, start) {
//        start = +start; //parse to int
//        return input.slice(start);
//    }
//});