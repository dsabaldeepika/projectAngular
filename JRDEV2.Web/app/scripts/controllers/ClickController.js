'use strict';
//Modals
$('#EditModal').modal('show.bs.modal');
$('#PaymentHistoryModal').modal('show.bs.modal');
$('#AddEmployeeModal').modal('show.bs.modal');
$('#MessageModal').modal('show.bs.modal');

var tester = 0;

// used for file upload, not working right now
app.directive('fileUpload', function () {
    return {
        scope: true,        //create a new scope
        link: function (scope, el, attrs) {
            el.bind('change', function (event) {
                var files = event.target.files;
                //iterate files since 'multiple' may be specified on the element
                for (var i = 0; i < files.length; i++) {
                    //emit event upward
                    scope.$emit("fileSelected", { file: files[i] });
                }
            });
        }
    };
});

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

app.controller('companyCtrl', function ($scope, Company, TestCompany, Job, Message, $location, $resource, $http, Upload, Click, $routeParams) {

    //$scope.companyInfo = Company.get({ id: 6 }, function () { });
    $scope.companyInfo = Company.query();
    //$scope.companyInfo = Company.get({ id: 1 }, function () { });
    $scope.create = {
        name: "",
        st: "",
        st2: "",
        city: "",
        state: "",
        zip: "",
        summary: "",
        main_url: "",
        facebook_url: "",
        linkedin_url: "",
        twitter_url: "",
        googleplus_url: "",
        logofile: "",
        user: "",
        user2: "",
    };

    // Route to company dashboard
    $scope.toCompanyDashboard = function () {
        window.location = "/app/index.html#/companydashboard";
    }

    $scope.jobArray = Job.query();

    // START OF COMPANYSETTINGS CRUD ON "Company" Table 
    //alert($scope.loggedIn);

    $scope.companyInfo = TestCompany.get({ id: 1 });

    if (!$scope.companyInfo.isDeleted) {
        $scope.active = "Active";
        //alert($scope.active);
    }
    else {
        $scope.active = "InActive";
    }

    $scope.updateCompanySettings = function () {
        TestCompany.update({ id: $scope.companyInfo.clickId }, $scope.companyInfo);// this works

        alert(JSON.stringify($scope.companyInfo));
    }
    // END OF COMPANYSETTINGS CRUD

    //TESTING CRUD ON "Click" Table

    $scope.clickcounts = Click.query();//READ WORKS

    //alert(JSON.stringify( $scope.clickcounts));

    //$scope.newClick = {

    //    //NumOfClicks:'', 
    //    //IpAddress:"",
    //    //JobId: ""
    ////},
    ////{

    ////NumOfClicks:555, 
    ////IpAddress:"7771",
    ////JobId: "88"
    //    }
    //;

    $scope.getRecords = function () {
        $scope.clickcounts = Click.query();//READ WORKS
    }
    //CREATE WORKS
    $scope.addRecord2 = function () {
        //alert("add Record Function -> JobId: " + $scope.JobId + " - numofclicks: " + $scope.NumOfClicks + " - IP: " + $scope.IpAddress);

        //$scope.newClick.numOfClicks = $scope.NumOfClicks;
        //$scope.newClick.ipAddress = $scope.IpAddress;
        //$scope.newClick.jobId = $scope.JobId;

        var NewClick = {};
        //alert("add Record Function -> JobId: " + $scope.newClick.JobId + " - numofclicks: " + $scope.newClick.NumOfClicks + " - IP: " + $scope.newClick.IpAddress);

        //$scope.newClick.clickId = 0; //just placeholder

        //alert($scope.newClick.jobId);
        var lastIndex = $scope.clickcounts.length - 1;
        //alert(lastIndex);
        var lastItem = $scope.clickcounts[lastIndex];
        // alert(JSON.stringify(lastItem.clickId));
        NewClick.clickId = lastItem.clickId + 1;
        NewClick.numOfClicks = $scope.newClick.numOfClicks;
        NewClick.ipAddress = $scope.newClick.ipAddress;
        NewClick.jobId = $scope.newClick.jobId;

        //$scope.newClick.clickId = lastItem.clickId + 1;

        $scope.clickcounts.push(NewClick);
        //alert(JSON.stringify($scope.clickcounts));
        //$scope.$apply();

        Click.save($scope.newClick);
        //$scope.$apply();
        //Click.save($scope.newClick, function () { });
        //$scope.Click.push($scope.newClick);

    };

    $scope.addRecord = function () {
        //Click.save($scope.newClick).$promise.then(function () {
        //    $scope.clickcounts = Click.query();
        //    alert("inside promise then");
        //},
        //function (error) { alert(JSON.stringify(error)); $scope.clickcounts = Click.query(); }
        //);
        // alert("DF");

        //promise method above works, but no need to use promise since $resource syntax can handle success/error by  Click.save($scope.newClick,  function(){//function acting as a success parameter}, function(){//failed or error});
        //Click.save($scope.newClick,function () {
        //    $scope.clickcounts = Click.query();
        //    alert("inside promise then");
        //},
        //function (error) { alert("error in save "+JSON.stringify(error)); 
        //    $scope.clickcounts = Click.query();
        //}
        //);

        Click.save($scope.newClick);

    };

    //var User = $resource('/user/:userId', { userId: '@id' });
    //User.get({ userId: 123 })
    //    .$promise.then(function (user) {
    //        $scope.user = user;
    //    });

    // DELETE WORKs
    $scope.deleteRecord = function (id) {
        //alert(id);
        //alert("add Record Function -> ClickID: "+ id );
        //Company.delete({ id: id }, function () { });
        //if ($scope.companyArray.length === 1) {
        //    $scope.companyArray.splice(0, 1);
        //} else {
        //    $scope.companyArray.splice(id - 1, 1);
        //}
        //$scope.clickcounts = Click.query();
        var tempObj = $scope.clickcounts;
        //alert(c1.length);

        Click.delete({ id: id });
        for (var i in tempObj) {
            if (tempObj[i].clickId == id) {
                //alert("dfsa " +i);
                tempObj.splice(i, 1);
                break;
            }
        }

        //if ($scope.clickcounts.length === 1) {   
        //    //$scope.clickcounts.splice(0, 1);
        //    alert(JSON.stringify(c1));
        //    //$scope.$apply();
        //}
        //else {
        //    //$scope.clickcounts= $scope.clickcounts.splice(id, 1);
        //    alert("length NOT 1, id = " + id);
        //    alert("object output "+ JSON.stringify(c1));
        //    //$scope.$apply();
        //}
    };
    // UPDATE TODO
    $scope.updateModal = function (click) {

        $scope.upClick = click;
        //alert(JSON.stringify($scope.upClick));
    }

    $scope.updateRecord = function (click) {
        //var tempObj = $scope.clickcounts;
        //$scope.clickcounts = Click.query();
        //alert(JSON.stringify($scope.clickcounts));
        //alert(click.clickId);

        Click.update({ id: click.clickId }, click);// this works

        //var updateRec = Click.get({ Id: click.clickId }, 
        //    function () {
        //        updateRec = click;
        //        updateRec.$save();
        //});
    }
    // END TESTING CRUD

    $scope.sendMessage = function () {
        Message.save($scope.message, function () {
            $scope.message = {
                Content: '',
                Subject: ''
            }
        })
    }

    $scope.init = function () {
        $scope.testInfo = Company.get({ id: tester }, function () { });
    }
    $scope.newTest = function (id) {
        tester = id;
        $scope.companyInfo.test = id;
        alert(tester);
        //   $scope.companyInfo = $scope.testInfo;
        //alert($location.path());
        //     $rootScope.$broadcast('SOME_TAG', 'your value');
        $location.path('/practice');
    };

    $scope.submitCompany = function () {
        Company.save($scope.company, function () {
            $scope.companyArray.push($scope.company);
            $scope.company = {
                City: '',
                CompanyName: '',
                PaymentInfo: '',
                EmailAddress: '',
                PhoneNumber: '',
                State: '',
                StreetAddress: '',
                UserCreatedId: 1,
                UserUpdatedId: 1,
                ZipCode: ''
            };
        });
    };

    $scope.addJob = function () {
        Job.save($scope.addJobForm, function () { });
        $scope.jobArray.push($scope.addJobForm);
    };
    // update company info
    $scope.updateCompany = function (id, company) {
        Company.update({ id: id }, company, function () { });
    }
    // DELETE
    $scope.deleteCompany = function (id) {
        Company.delete({ id: id }, function () { });
        if ($scope.companyArray.length === 1) {
            $scope.companyArray.splice(0, 1);
        } else {
            $scope.companyArray.splice(id - 1, 1);
        }
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

    //Join Company as user
    $scope.saveUser = function (user, joinCoForm) {
        if (joinCoForm.$valid) {
            //window.alert(user.firstName)(this worked)
        }
    }
    //cancel editing new user
    $scope.cancelEditJoin = function () {
        window.alert("test1")
        window.location = "/app/index.html#/companyjoin";
    }

    $scope.cancelEdit = function () {
        window.alert("test1")
        window.location = "/app/index.html#/jobapplist";
    }

    $scope.backToList = function () {
        window.location = "/app/index.html#/jobapplist";
    }

    $scope.singleJob = {
        id: 1,
        jobTitle: "Coder",
        companyName: "CoderCamps",
        description: "best job ever",
        dateCreated: "01-11-2014",
        startDate: "01-11-2014",
        endDate: "01-11-2014",
        salaryMin: 20,
        salaryMax: 30,
        yearsExperience: 10,
        skillArray: ["C#", "JavaScript", "Angular"],
    }
    $scope.applicantView = function (id) {
        $scope.id = id;
        window.location = "/app/index.html#/jobview";

    }
});