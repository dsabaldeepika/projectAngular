"use strict";
app.controller('messageCtrl', function ($scope, $http, $routeParams, $rootScope, GetMessages) {
    //$scope.messageArray = GetMessages.getMessages();    
    //$scope.messageArray.then(function (data) {
    //    $scope.messageArray = data;
    //});
    $scope.message = {};
    $scope.newMessage = {};
    $scope.unreadCount = 0;
    $scope.getMessages = function () {
        $scope.messageArray = GetMessages.Messages;
        //$http({ method: 'GET', url: '/app/api/v1/Messages/' })
        //.success(function (data) {
        //    $scope.unreadCount = 0;
        //    for (var message in data) {
        //        if (!data[message].dateRead) {
        //            $scope.unreadCount += 1;
        //        }
        //        $scope.messageArray.push(data[message]);
        //    };
        ////    console.log($scope.messageArray);
        //})
        //.error(function (data) {
        //    console.log("Error: " + data);
        //});
        //$scope.messageArray = GetMessages.getMessages();
        //alert("hello");
  
    };

    

    $scope.getMessage = function () {
        $scope.messageId = $routeParams.id;
        $http({ method: 'GET', url: '/app/api/v1/Messages/' + $scope.messageId })
        .success(function (data) {
            $scope.unreadCount -= 1;
            if ($scope.unreadCount < 0) { $scope.unreadCount = 0; }
            $scope.message = data;
        })
        .error(function (data) {
            console.log("Error: " + data);
        });
    };

    $scope.submitMessage = function () {
        $http({ method: "POST", url: "/app/api/v1/Messages", data: $scope.newMessage })
        .success(function (data) {
            console.log("Message: " + data + " sent.");
            $scope.newMessage.body = ""; //ray was here
        })
        .error(function (data) { console.log("Error: " + data); })
    };

    $scope.reply = function () {
        $scope.newMessage.toId = $scope.message.fromId;
        $scope.newMessage.subject = "Re: " + $scope.message.subject;
    }

    $scope.updateMessage = function (id, message) {
        Company.update({ id: id }, message, function () {
            $scope.messageArray.push($scope.message);
            $scope.message = {
                MsgSubject: '',
                MsgBody: ''
            };
        });
    };

    $scope.deleteMessage = function (id) {
        Message.delete({ id: id }, function () {
        });
        if ($scope.messageArray.length === 1) {
            $scope.messageArray.splice(0, 1);
        } else {
            $scope.messageArray.splice(id - 1, 1);
        }
    };
});
