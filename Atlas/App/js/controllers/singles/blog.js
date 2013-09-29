define(['modules/mainApp'], function (mainApp) {
    mainApp.controller('blogController', function ($scope, $location, blogService) {
         
        var getAllPost = function () {
            blogService.getAllPost().then(function (previews) {
                $scope.previewPosts = previews.data;
            }, function (error) {
                console.log(error);
            });
        };

        $scope.init = function () {
            getAllPost();
        };

        $scope.init();

    });
});