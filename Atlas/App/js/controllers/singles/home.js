define(['modules/mainApp', 'services/home'], function (mainApp) {
    mainApp.controller('homeController', function ($scope, homeService) {

        $scope.posts;
        $scope.status;
              
        var getPreviewPage = function () {
            homeService.getPosts().then(function (posts) {
                    $scope.posts = posts.data; 
                }, function (error) {
                    console.log(error); // = 'Unable to load preview page data: ' + error.message;
                });
        };

        $scope.init = function () {
            getPreviewPage();
        };

        $scope.init();

    });   

});


