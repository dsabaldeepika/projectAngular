'use strict';
app.controller('talentCtrl', function ($scope, $location, $resource, $http, User, Message, Resume, $routeParams, Application, GetSavedJobs, GetResumesService, sessionHandler) {
    //$scope.userArray = User.query();

    //$scope.getApplications = function () {
    //    $scope.Applications = Application.query();
    //};

    //DLR added getApplications with $http    
    $scope.SavedJobs = {};
    $scope.Applications = {};
//    $scope.AllRusumes = {};
    $scope.application = {};

    $scope.SubmitAllJobs = function (application) {
        var arrayList = [];
        for (var x in application) {
            arrayList.push(application[x]);
        }

        $http.put('/app/api/v1/Application/', arrayList).success();
        document.location.reload(true);
    };

    if (sessionHandler.get('auth')) {
        GetResumesService.getAllResumes(function (data) {
            $scope.AllResumes = data;
        });
    }

    $scope.deleteSavedJob = function (id) {
        $http({ method: 'Delete', url: '/app/api/v1/SavedJob/' + id })
        .success(function (data) {
            console.log('Successfully Deleted SavedJob.');
            //$scope.toTalentResume();
            document.location.reload(true);
        })
        .error(function (data) {
            console.log('Error: ' + data);
        });
    };
    //$scope.deleteSavedJob = function (id) {
    //    DeleteSavedJob(id);
    //    if (DeleteSavedJob(id)) { document.location.reload(true); };
    //};


    GetSavedJobs.getSJ(function (data) {
        $scope.SavedJobs = data;
    });

    $scope.getApplications = function () {
        $http({ method: 'GET', url: '/app/api/v1/Application/' + $scope.UserId })
                .success(function (data) {
                    $scope.Applications = data;
                })
                .error(function (data) {
                    alert(data);
                });
    };
    //DLR added GetJobsApplied with $http  
    $scope.JobsApplied = {};
    $scope.GetJobsApplied = function () {
        $http({ method: 'GET', url: '/app/api/v1/JobsApplied/' + $scope.UserId })
                .success(function (data) {
                    $scope.JobsApplied = data;
                })
                .error(function (data) {
                    alert(data);
                });
    };
    //Goto jobView - DLR 
    $scope.toJobView = function () {
        document.location = "/jobview/:id";
//        window.location = "/app/index.html#/jobview/:id";
    };


    $scope.user = {
        DateCreated: '',
        DateUpdated: '',
        FirstName: '',
        //Hidden: '',
        //JobId: '',
        LastName: '',
        UserCreatedId: '',
        //Password: '',
        UserUpdatedId: '',
    };
    $scope.UserId = '';

    $scope.submitUser = function () {
        User.save($scope.user, function () {
            $scope.userArray.push($scope.user);
            $scope.user = {
                DateCreated: '',
                DateUpdated: '',
                FirstName: '',
                //Hidden: '',
                //JobId: '',
                LastName: '',
                UserCreatedId: '',
                //Password: '',
                UserUpdatedId: '',
            };
        });
    };
    $scope.updateUser = function (id, user) {
        Company.update({ id: id }, user, function () {
            $scope.userArray.push($scope.user);
            $scope.user = {
                DateCreated: '',
                DateUpdated: '',
                FirstName: '',
                //Hidden: '',
                //JobId: '',
                LastName: '',
                UserCreatedId: '',
                //Password: '',
                UserUpdatedId: '',
            };
        });
    };

    $scope.deleteUser = function (id) {
        User.delete({ id: id }, function () {
        });

        if ($scope.userArray.length === 1) {
            $scope.userArray.splice(0, 1);
        } else {
            $scope.userArray.splice(id - 1, 1);
        }
    };

    $scope.master = {};

    $scope.reset = function () {
        $scope.talent = angular.copy($scope.master);
    };

    // Define talent object
    $scope.talent = {
        FirstName: "",
        LastName: "",
        UserName: "",
        Password: "",
        StreetAddress: "",
        StreetAddress2: "",
        City: "",
        State: "",
        ZipCode: "",
        Summary: "",
        Skills: "",
        DesiredSalary: "",
        WillRelocate: "",
        MainUrl: "",
        FacebookUrl: "",
        LinkedinUrl: "",
        TwitterUrl: "",
        GoogleplusUrl: "",
        PicFile: "",
        EmailAddress: "",
        EmailAddress2: "",
        PhoneNumber: "",
        PhoneNumber2: "",
    };

    // Route to talent dashboard
    $scope.toTalentDashboard = function () {
        $location.path("/");
    };///app/index.html#

    $scope.isUnchanged = function (talent) {
        return angular.equals(talent, $scope.master);
    };

    // Set id to scope from route param
    $scope.TalentId = $routeParams.id;

    // GET all talent
    $scope.talentArray = {};
    $scope.getTalentArray = function () {
        $scope.talentArray = TalentVM.query();
    };

    // GET selected talent
    //$scope.getTalent = function () {
    //    $scope.talent = TalentVM.get({ id: $scope.talentId }, function () { });
    //};

    $scope.getTalentVM = function () {

        $http({ method: 'GET', async: false, url: '/app/api/v1/Talent/' })
            .success(function (data) {
                $scope.TalentVM = data;
            })
            .error(function (data) {
                alert(data);
            });
    };

    // CREATE talent
    $scope.createTalent = function () {
        $http({ method: 'POST', url: 'api/v1/Talent/', data: $scope.talent })
        .success(function (data) {
            console.log("User " + $scope.talent.UserName + " Created");
            $scope.talent = {
                FirstName: "",
                LastName: "",
                UserName: "",
                Password: "",
                StreetAddress: "",
                StreetAddress2: "",
                City: "",
                State: "",
                ZipCode: "",
                Summary: "",
                Skills: "",
                //Uncommented by George W. 5/1/14
                //============================================
                DesiredSalary: "",
                WillRelocate: "",
                //============================================

                MainUrl: "",
                FacebookUrl: "",
                LinkedinUrl: "",
                TwitterUrl: "",
                GoogleplusUrl: "",
                PicFile: "",
                EmailAddress: "",
                EmailAddress2: "",
                PhoneNumber: "",
                PhoneNumber2: "",
            };
            // Route to talent dashboard

            $scope.toTalentDashboard();
        })
        .error(function (data) {
            console.log("Error: " + data);
        });
    }


    // UPDATE talent
    // Used to update Talent Profile and Talent Settings - George W. 5/7/14
    $scope.updateTalent = function () {
        var id = $routeParams.id;
        $http({ method: 'Patch', url: '/app/api/v1/Talent/', data: $scope.TalentVM })
        .success(function (data) {
            console.log('Successfully Updated TalentProfile.');
            document.location.reload(true);
        })
        .error(function (data) {
            console.log('Error: ' + data);
        });
    }

    // DELETE talent
    //$scope.deleteTalent = function (id) {                           ---------Commented out by George W. 5/7/14
    //    TalentVM.delete({ id: id }, function () { });

    //    if ($scope.talentArray.length === 1) {
    //        $scope.talentArray.splice(0, 1);
    //    }
    //    else {
    //        $scope.talentArray.splice(id - 1, 1);
    //    }
    //};

    $scope.deleteProfile = function () {
        $http({ method: 'Delete', url: '/app/api/v1/Talent/' + $scope.TalentId })
        .success(function (data) {
            console.log('Successfully Deleted Profile.');
            $scope.toTalentDashboard();
        })
        .error(function (data) {
            console.log('Error: ' + data);
        });
    };



    //================================
    //Resume section
    //DLR 04/24/2014 
    //================================

    // Set id to scope from route param// 
    $scope.ResumeId = $routeParams.id;

    // retrieve select resume //
    //$scope.GetResume = Resume.query({ id: $scope.ResumeId }, function () { });

    $scope.getResume = function () {
        $http({ method: 'GET', async: false, url: '/app/api/v1/Resumes/' + $scope.ResumeId })
            .success(function (data) {
                $scope.Resume = data;
                $scope.newResumeVM = $scope.Resume;
            })
            .error(function (data) {
                alert(data);
            });
    };

    //DLR create route for individual resume detail page
    $scope.toResumeDetail = function () {
        $location.path("/resumedetail/:id");
    };

    //Created by George W. 5/2/14
    //============================================
    $scope.RefreshTalentResume = function () {
        document.location.reload(true);
    };
    //============================================

    $scope.Resumes = {};
    $scope.getResumes = function () {
        $http({ method: 'GET', url: '/app/api/v1/Resumes/' })
                .success(function (data) {
                    $scope.Resumes = data;
                })
                .error(function (data) {
                    alert(data);
                });
    };

    $scope.newResume = {
    };

    $scope.createResume = function () {
        //Created by George W. 5/1/14
        //============================================
        $http({ method: 'POST', url: 'api/v1/Resumes/', data: $scope.newResume })
        .success(function (data) {
            console.log("Resume Created");
            $scope.newResume = {
                Heading: "",
                Summary: "",
                WorkExperience: "",
                Education: "",
                OtherInfo: "",
                UserId: "",
                UserCreatedId: "",
                UserUpdatedId: "",
            };

            $scope.RefreshTalentResume();
        })
        .error(function (data) {
            console.log("Error: " + data);
        });

    };

    $scope.toTalentResume = function () {
        $location.path("/talentresume");
    };

    $scope.updateResume = function () {
        $http({ method: 'Patch', url: '/app/api/v1/Resumes/' + $scope.ResumeId, data: $scope.newResumeVM })
        .success(function (data) {
            console.log('Successfully Updated Resume.');
            $scope.toTalentResume();
            document.location.reload(true);
        })
        .error(function (data) {
            console.log('Error: ' + data);
        });
    };

    $scope.cancelUpdateResume = function () {
        document.location.reload(true);
    }

    $scope.deleteResume = function () {
        $http({ method: 'Delete', url: '/app/api/v1/Resumes/' + $scope.ResumeId })
        .success(function (data) {
            console.log('Successfully Deleted Resume.');
            $scope.toTalentResume();
            document.location.reload(true);
        })
        .error(function (data) {
            console.log('Error: ' + data);
        });
    };
    //========================================================================================================

    //End Resume section
    //================================


    $scope.toTalentSettings = function () {
        $location.path("/talentsettings");
    };


    //Moved to messageController - Jason Cannon 4/25/2014
    //$scope.messageArray = {};
    //$scope.getMessages = function () {
    //$scope.messageArray = Message.query();
    //};
    //$scope.message = {
    //    MsgSubject: '',
    //    MsgBody: ''
    //};
    //$scope.MessageId = '';

    //$scope.submitMessage = function () {
    //    Message.save($scope.message, function () {
    //        $scope.messageArray.push($scope.message);
    //        $scope.message = {
    //            MsgSubject: '',
    //            MsgBody: ''
    //        };
    //    });
    //};
    //$scope.updateMessage = function (id, message) {
    //    Company.update({ id: id }, message, function () {
    //        $scope.messageArray.push($scope.message);
    //        $scope.message = {
    //            MsgSubject: '',
    //            MsgBody: ''
    //        };
    //    });
    //};

    //$scope.deleteMessage = function (id) {

    //    Message.delete({ id: id }, function () {
    //    });

    //    if ($scope.messageArray.length === 1) {
    //        $scope.messageArray.splice(0, 1);
    //    } else {
    //        $scope.messageArray.splice(id - 1, 1);
    //    }
    //};

    $scope.reset();
    $('#EditModal').modal('show.bs.modal');
});