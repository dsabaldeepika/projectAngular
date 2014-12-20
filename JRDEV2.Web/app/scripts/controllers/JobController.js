/// <reference path="LoginController.js" />
"use strict"

app.controller('jobCtrl', function ($scope, Resume, Job, $location, $resource, $http, Upload, Click, $routeParams) {

    //Set id to scope from route param// 
    $scope.ApplicantId = $routeParams.id;

    $scope.saveUser = function (user, joinCoForm) {
        if (joinCoForm.$valid) {
            //window.alert(user.firstName)  (this alerted properly)
        }
    }
    //Cancel and return to applicants list//
    $scope.cancelEdit = function () {
        window.alert("test1")
        window.location = "/app/index.html#/jobapplist";
    }

    //Return back to applicants list//
    $scope.backToList = function (id) {
        window.location = "/app/index.html#/jobapplist/" + id;
    }


    //Route to company profile//
    $scope.toCompanyProfile = function () {
        window.location = "/app/index.html#/companyprofile";
    }

    //retrieve list of applicants from seleted Job//
    $scope.getApplicants = Job.query({ id: 1 }, function () { });
    //  $scope.companyInfo = Company.get({ id: 1 }, function () { });

    //route to add application for job
    $scope.addApplication = function () {
        $scope.application.jobId = $routeParams.id;
        $http({ method: "POST", url: "/app/api/v1/Applications/" + $routeParams.id, data: $scope.application })
        .success(function (data) {
            console.log(data);
        })
        .error(function (data) {
            console.log(data);
        })
    }

    //Route to Applicant view and sent id of applicant
    $scope.applicantView = function (id) {
        $scope.id = id;
        window.location = "/app/index.html#/jobappview";
    }
    //dummy data for job view
    //$scope.singleJob = {
    //    id: 1,
    //    jobTitle: "Coder",
    //    companyName: "CoderCamps",
    //    description: "best job ever",
    //    dateCreated: "01-11-2014",
    //    startDate: "01-11-2014",
    //    endDate: "01-11-2014",
    //    salaryMin: 20,
    //    salaryMax: 30,
    //    yearsExperience: 10,
    //    skillArray: ["C#", "JavaScript", "Angular"],
    //    companyId: 1
    //}
    $scope.Jobs = [];
    $scope.Job = {};
    $scope.getJob = function () {
        $http({ method: 'GET', url: '/app/api/v1/Jobs/' + $routeParams.id })
        .success(function (data) {
            $scope.Job = data;
            //$scope.getresumes();
        })
        .error(function (data) {
            console.log('Error: ' + data);
        });
    }

    
    $scope.getresumes = function(){
        $http({ method: 'GET', url: '/app/api/v1/Resumes/' })
        .success(function (data) {
            $scope.Resumes = data;
        })
        .error(function () {
            console.log(data);
        });
    }
        


    $scope.getJobs = function () {
        $http({ method: 'GET', url: '/app/api/v1/Jobs/' })
        .success(function (data) {
            $scope.Jobs = [];
            for (var job in data) {
                $scope.Jobs.push(data[job]);
            }
        })
        .error(function (data) {
            console.log('Error: ' + data);
        });
    }
    $scope.saveJob = function () {

        $http({ method: 'POST', url: '/app/api/v1/Jobs/', data: $scope.Job })
        .success(function (data) {
            console.log('Successfully Posted newJob.');
        })
        .error(function (data) {
            console.log('Error: ' + data);
        });
    }
    $scope.saveJobToCart = function () {
     
        $http({ method: "POST", url: "/app/api/v1/SavedJob/" + $routeParams.id })
        .success(function (data) {
            console.log(data);
            alert("Your Job has been Saved to your Cart!") //added alert for user to know job has been saved -ray
        })
        .error(function (data) {
            console.log(data);
        })
    }

});

