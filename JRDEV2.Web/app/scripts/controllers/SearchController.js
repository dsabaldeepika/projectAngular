'use strict';

var passingId = 0; //variable for JobPostingView

app.controller('searchCtrl', function ($scope, $location, Job, $http, Message, $route, $modal, $log,$routeParams) {


    //================================
    //Search section
    //DLR 04/28/2014 
    //================================

    $scope.Jobs = {};
    $scope.Companies = {};
    $scope.searchList = {};
    $scope.search = "";
    $scope.searchstring = $routeParams.searchstring;

    if ($scope.searchstring != null) {
        $http({ method: 'GET', url: '/app/api/v1/Search/' + $scope.searchstring })
        .success(function (data) {
            $scope.searchList = data;

        })
        .error(function (data) {
            alert(data);
        });
    }

    $scope.getSearchList = function () {
       
            $http({ method: 'GET', url: '/app/api/v1/Search/'+$scope.search })
                    .success(function (data) {
                        $scope.searchList = data;
                                          
                    })
                    .error(function (data) {
                        alert(data);
                    });
    
            //$http({ method: 'GET', url: '/app/api/v1/Companies/' })
            //        .success(function (data) {
            //            $scope.Companies = data;
            //        })
            //        .error(function (data) {
            //            alert(data);
                
        //});
        //$scope.SearchList.push($scope.Jobs);
        //$scope.SearchList.push($scope.Companies);
    }

    //$scope.jobArray = [                                   
    //{ "jobTitle": "Jr Developer", "companyName": "Code Camps", "description": "Code Code Code", "city": "Pearland, TX", "dateCreated": "4/11/14"},
    //{ "jobTitle": "Programmer", "companyName": "Blue Bell", "description": "Ice Cream Code", "city": "Houston, TX", "dateCreated": "4/11/14" },
    //{ "jobTitle": "Sr Developer", "companyName": "JC Penny's", "description": "More Code", "city": "Heavenly, TX", "dateCreated": "4/11/14" }]; //    POCO

    //$scope.testtest = "FSDF"; //  test string
    //alert(JSON.stringify( $scope.jobArray));  // testing for string return by POCO obj
    //User Profile Messages//
    $scope.messageArray = Message.query();
    ////////////////////////

    ////Filter for Salary Options/////
    $scope.salaryFilter = function (min) {
        return parseInt(min.salaryMin) >= parseInt($scope.salary_Min || 0);
    };

    ///retrieve job from job table and reroute to job posting view
    $scope.initJobPostingView = function () {
        $scope.singleJob = Job.get({ id: passingId }, function () {
        });
    }

    $scope.getJob = function (job) {
        passingId = job;
        $location.path('/job'); // change to JobPostingView
    }
    ////////////////////////////////////

    //retrieve job from jobPostingView and reroute to UserProfileView JobCart
    $scope.initJobCart = function () {
        $scope.singleJobCarts = [];
        $scope.singleJobCart = Job.get({ id: passingId }, function () {
            $scope.singleJobCarts.push($scope.singleJobCart)
        });
    }

    //$scope.getJobCart = function (jobCart) {
    //    passingId = jobCart;
    //    $location.path('/userprofile'); // change to UserProfileView
    //}

    ///retrieve job from jobPostingView and reroute to UserProfileView SAVED JOBS
    $scope.initJobSave = function () {
        $scope.singleJobSaves = [];
        $scope.singleJobSave = Job.get({ id: passingId }, function () {
            $scope.singleJobSaves.push($scope.singleJobSave)
        });
    }

    $scope.getJobSave = function (jobSave) {
        passingId = jobSave;
        $location.path('/userprofile'); // change to UserProfileView
    }

    //JobCartModel
    $scope.currentItem = null;
    $scope.getJobCartModal = function (item) {
        $scope.currentItem = item;

        var modalInstance = $modal.open({
            templateUrl: 'myModalContent',
            controller: 'ModalInstanceCtrl',
            resolve: {
                currentItem: function () {
                    return $scope.currentItem;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {

        });
    }
    $scope.searchObject = {};
    //pagination stuff (you'll need this everywhere you want to paginate
    $scope.jobArray = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.prevPageDisabled = function () {
        return $scope.currentPage === 0 ? "disabled" : "";
    };
    $scope.nextPageDisabled = function () {
        return $scope.currentPage === $scope.pageCount() ? "disabled" : "";
    };
    $scope.pageCount = function () {
        return Math.ceil($scope.jobArray.length / $scope.itemsPerPage) - 1;
    };
    $scope.nextPage = function () {
        if ($scope.currentPage < $scope.pageCount()) {
            $scope.makeJobsCall();
        }
    };
    $scope.prevPage = function () {
        if ($scope.currentPage > 0) {
            $scope.currentPage--;
            $scope.makeJobsCall();
        }
    };
    $scope.searchJobs = function () {
        $scope.currentPage = 0;
        $scope.makeJobsCall();
    };
    $scope.makeJobsCall = function () {
        $scope.searchObject = { ItemsPerPage: $scope.itemsPerPage, CurrentPage: $scope.currentPage, SearchText: $scope.search.$ };
        $http({ method: 'POST', url: '/app/api/v1/JobSearch', data: $scope.searchObject })
        .success(function (data) {
            $scope.jobArray = data;
        })
        .error(function (data) {
            alert(data);
        });
    }
    ////////////////////////////////////////////////////////////////////

    // Please note that $modalInstance represents a modal window (instance) dependency.
    // It is not the same as the $modal service used above.
    app.controller('ModalInstanceCtrl', ['$scope', '$modalInstance', 'currentItem', function ($scope, $modalInstance, currentItem) {

        $scope.currentItem = currentItem;
        $scope.ok = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);

});
