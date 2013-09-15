define(['modules/mainApp'], function (mainApp) {
    mainApp.controller('blogController', function ($scope, blogService) {
        
        $scope.posts;

        var getPostPreview = function () {
            blogService.getPostPreview().then(function (posts) {
                $scope.posts = posts.data;
            }, function (error) {
                console.log(error); // = 'Unable to load preview page data: ' + error.message;
            });
        };

        $scope.init = function () {
            getPostPreview();
        };

        $scope.init();

    });
});