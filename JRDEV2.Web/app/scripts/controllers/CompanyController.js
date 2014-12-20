'use strict';
//Modals
$('#EditModal').modal('show.bs.modal');
$('#PaymentHistoryModal').modal('show.bs.modal');
$('#AddEmployeeModal').modal('show.bs.modal');
$('#MessageModal').modal('show.bs.modal');

var tester = 0;

//// used for file upload, not working right now
//app.directive('fileUpload', function () {
//    return {
//        scope: true,        //create a new scope
//        link: function (scope, el, attrs) {
//            el.bind('change', function (event) {
//                var files = event.target.files;
//                //iterate files since 'multiple' may be specified on the element
//                for (var i = 0; i < files.length; i++) {
//                    //emit event upward
//                    scope.$emit("fileSelected", { file: files[i] });
//                }
//            });
//        }
//    };
//});

// this made azure upload work but broke user registration and login
//app.config(function ($httpProvider) {
//        $httpProvider.defaults.transformRequest = function(data) {
//            if (data === undefined)
//                return data;

//            var fd = new FormData();
//            angular.forEach(data, function(value, key) {
//                if (value instanceof FileList) {
//                    if (value.length == 1) {
//                        fd.append(key, value[0]);
//                    } else {
//                        angular.forEach(value, function(file, index) {
//                            fd.append(key + '_' + index, file);
//                        });
//                    }
//                } else {
//                    fd.append(key, value);
//                }
//            });
//            return fd;
//        }
//        $httpProvider.defaults.headers.post['Content-Type'] = undefined;
//});

app.controller('companyCtrl', function ($scope, CompanyVM, Job, Message, $location, $resource, $http, Upload, Click, $routeParams) {
    // Define company object
    $scope.company = {
        CompanyName: "",
        FirstName: "",
        LastName: "",
        UserName: "",
        Password: "",
        StreetAddress: "",
        StreetAddress2: "",
        City: "",
        State: "",
        ZipCode: "",
        PhoneNumber: "",
        EmailAddress: "",
        Description: "",
        MainUrl: "",
        FacebookUrl: "",
        LinkedinUrl: "",
        TwitterUrl: "",
        GoogleplusUrl: "",
        Logo: "",
        CompanyUserEmail: "",
        CompanyUserEmail2: "",
    };

    // Route to company dashboard
    $scope.toCompanyDashboard = function () {
        $location.path("/");
    }

    $scope.toaboutView = function () {
        window.location = "/app/index.html#/jrdevsabout";
    }

    $scope.toFAQView = function () {
        window.location = "/app/index.html#/faq";
    }

    $scope.toCompanyProfile = function (CompanyId) {
        //get company with Id
        window.location = "/app/index.html#/companyprofile";
    }

    // GET selected company
    $scope.getCompany = function () {
        $http({ method: "GET", url: "/app/api/v1/Company/-1" })
        .success(function (data) {
            $scope.companyInfo = data;
            $scope.getJobs();
        })
            .error(function (data) {
                console.log(data);
            });
    };

    $scope.selectedJob = {};
    $scope.setSelectedJob = function (job) {
        $scope.selectedJob = job;
    }

    // CREATE company
    $scope.createCompany = function () {
        CompanyVM.save($scope.company, function () {
            // Add new company
            $scope.companyInfo.push($scope.company);

            // Blank all view fields
            $scope.company = {
                CompanyName: "",
                FirstName: "",
                LastName: "",
                UserName: "",
                Password: "",
                StreetAddress: "",
                StreetAddress2: "",
                City: "",
                State: "",
                ZipCode: "",
                PhoneNumber: "",
                EmailAddress: "",
                Description: "",
                MainUrl: "",
                FacebookUrl: "",
                LinkedinUrl: "",
                TwitterUrl: "",
                GoogleplusUrl: "",
                Logo: "",
                CompanyUserEmail: "",
                CompanyUserEmail2: "",
            };
        })

        // Route to company dashboard
        $scope.toCompanyDashboard();
    };

    // UPDATE company
    //$scope.updateCompany = function (id, company) {
    //    $http({ method: 'PATCH', url: '/app/api/v1/Company/-1', data: 'company' })
    //    .success(function (data) { console.log(data); })
    //}

    // DELETE company
    $scope.deleteCompany = function (id) {
        CompanyVM.delete({ id: id }, function () { });

        if ($scope.companyInfo.length === 1) {
            $scope.companyInfo.splice(0, 1);
        }
        else {
            $scope.companyInfo.splice(id - 1, 1);
        }
    };

    $scope.startCrud = function () {
        // START OF COMPANYSETTINGS CRUD ON "Company" Table 
        console.log($scope.currentUser);
        var cid = JSON.stringify($scope.currentUser);
        cid = cid.replace(/"/g, "");
        cid = cid.replace(/\\/g, "");
        $scope.companyInfo = CompanyVM.get({ id: cid });
        //alert(JSON.stringify($scope.companyInfo));
        if ($scope.companyInfo.isDeleted === true) {
            $scope.active = "Active";
            //alert($scope.active);
        }
        else {
            $scope.active = "InActive";
        }
    }

    $scope.updateCompanySettings = function () {
        $http({ method: 'PATCH', url: '/app/api/v1/Company/-1', data: $scope.companyInfo })
        .success(function (data) { console.log(data); })
    }
    // END OF COMPANYSETTINGS CRUD

    $scope.sendMessage = function () {
        Message.save($scope.message, function () {
            $scope.message = {
                //UserCreatedId: '1',
                //UserId: '2',
                //UserUpdatedId: '2',
                Content: '',
                Subject: '',
                //MessageId: '2',
                //CompanyId: '1'
            }
        })
        $('#myModal').modal('hide');
    }

    $scope.init = function () {
        $scope.testInfo = CompanyVM.get({ id: tester }, function () { });
    }

    $scope.newTest = function (id) {
        tester = id;
        $scope.companyInfo.test = id;
        //alert(tester);

        //   $scope.companyInfo = $scope.testInfo;
        //alert($location.path());
        //     $rootScope.$broadcast('SOME_TAG', 'your value');
        $location.path('/practice');
    };

    $scope.getJobs = function () {
        if (!$routeParams.id) {
            $http({ method: 'GET', url: '/app/api/v1/Jobs/?companyId=-1' })
            .success(function (data) {
                $scope.jobArray = data;
            })
                .error(function (data) {
                    console.log('Error' + data)
                });
        } else {
            $http({ method: 'GET', url: '/app/api/v1/Jobs/?companyId=' + $routeParams.id  })
            .success(function (data) {
                $scope.jobArray = data;
                console.log(data);
            })
                .error(function (data) {
                    console.log('Error' + data)
                });
        }
    }

    $scope.addJob = function () {
        Job.save($scope.addJobForm, function () { });
        $scope.jobArray.push($scope.addJobForm);
    };

    // 
    $scope.addNewClick = function (jobId) {
        $scope.click = {};
        $scope.click.jobId = jobId;
        Click.save($scope.click, function () { });
    };

    //a simple model to bind to and send to the server
    $scope.model = {};

    //an array of files selected
    $scope.files = [];

    //listen for the file selected event
    $scope.$on("fileSelected", function (event, args) {
        $scope.$apply(function () {
            //add the file object to the scope's files collection
            $scope.files.push(args.file);
        });
    });

    //SAVE IMAGE
    $scope.save = function () {
        $scope.model = Upload.save($scope.files, function () { });
        console.log($scope.model);
        alert("file uploaded!");
    };

    var myApp = angular.module('myApp', []);

    function MyCtrl($scope) {
        $scope.data = 'none';
        $scope.add = function () {
            var f = document.getElementById('file').files[0],
                r = new FileReader();
            r.onloadend = function (e) {
                $scope.data = e.target.result;
            }
            r.readAsBinaryString(f);
        }
    }

    $scope.saveUser = function (user, joinCoForm) {
        if (joinCoForm.$valid) {
            $http({ method: 'POST', url: '/app/api/v1/', data: $scope.user }) //this isn't finished--needs a save location
                    .success(function (data) {
                        console.log(data);
                    })
        .error(function (data) {
            console.log(data);
        })
            //window.alert(user.firstName) (this worked but nothing is actually posted)
        }
    }

    $scope.deleteCompanyUser = function () {

    }

    //cancel editing new user
    $scope.cancelEditJoin = function () {
        //window.alert("test1")
        window.location = "/app/index.html#/companysettings";
    }

    $scope.cancelEdit = function () {
        //window.alert("test1")
        window.location = "/app/index.html#/companydashboard";
    }
    $scope.backToList = function () {
        window.location = "/app/index.html#/jobapplist";
    }

    $scope.applicantView = function (id) {
        $scope.id = id;
        window.location = "/app/index.html#/jobview";
    }
});