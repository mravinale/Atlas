define(['modules/mainApp', 'services/home'], function (mainApp) {
    mainApp.controller('homeController', function ($scope, homeService) {

        $scope.posts;
        $scope.status;
              
        var getPreviewPage = function () {
            homeService.getPreviewPosts().then(function (posts) {
                    $scope.posts = posts.data; 
                }, function (error) {
                    $scope.status = 'Unable to load preview page data: ' + error.message;
                });
        };

        $scope.init = function () {
            getPreviewPage();
        };

        $scope.init();

    });   

});


