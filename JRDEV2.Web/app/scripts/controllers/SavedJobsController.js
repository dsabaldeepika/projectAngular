"use strict";
app.controller('SavedJobsCtrl', function ($scope, $http, $routeParams, $rootScope, GetSavedJobs) {
    $scope.savedJobArray = GetSavedJobs.getSavedJobs();
    $scope.savedJobArray.then(function (data) {
        $scope.savedJobArray = data;
    });
    $scope.savedJob = {};
    $scope.newSavedJob = {};
    $scope.unreadCount = 0;
    $scope.getSavedJobs = function () {
        $scope.savedJobArray = GetSavedJobs.getSavedJobs();
    };

    $scope.deleteSavedJob = function (id) {
        DeleteSavedJob(id);
        if (DeleteSavedJob(id)) { document.location.reload(true); };
    };

    //$scope.getSavedJob = function () {
    //    $scope.savedJobId = $routeParams.id;
    //    $http({ method: 'GET', url: '/app/api/v1/SavedJobs/' + $scope.savedJobId })
    //    .success(function (data) {
    //        $scope.unreadCount -= 1;
    //        if ($scope.unreadCount < 0) { $scope.unreadCount = 0; }
    //        $scope.savedJob = data;
    //    })
    //    .error(function (data) {
    //        console.log("Error: " + data);
    //    });
    //};

    //$scope.submitSavedJob = function () {
    //    $http({ method: "POST", url: "/app/api/v1/SavedJobs", data: $scope.newSavedJob })
    //    .success(function (data) {
    //        console.log("SavedJob: " + data + " sent.");
    //        $scope.newSavedJob.body = ""; 
    //    })
    //    .error(function (data) { console.log("Error: " + data); })
    //};

    //$scope.reply = function () {
    //    $scope.newSavedJob.toId = $scope.savedJob.fromId;
    //    $scope.newSavedJob.subject = "Re: " + $scope.savedJob.subject;
    //}

    //$scope.updateSavedJob = function (id, savedJob) {
    //    Company.update({ id: id }, savedJob, function () {
    //        $scope.savedJobArray.push($scope.savedJob);
    //        $scope.savedJob = {
    //            MsgSubject: '',
    //            MsgBody: ''
    //        };
    //    });
    //};

    //$scope.deleteSavedJob = function (id) {
    //    SavedJob.delete({ id: id }, function () {
    //    });
    //    if ($scope.savedJobArray.length === 1) {
    //        $scope.savedJobArray.splice(0, 1);
    //    } else {
    //        $scope.savedJobArray.splice(id - 1, 1);
    //    }
    //};
});
