define(['modules/mainApp'], function (mainApp) {
    mainApp.controller('blogController', function ($scope, $location, blogService) {
        
        $scope.previewPosts;

        var getPostPreview = function () {

            blogService.getPostPreview().then(function (previews) {
                $scope.previewPosts = previews.data;
            }, function (error) {
                console.log(error); // = 'Unable to load preview page data: ' + error.message;
            });

        };

        $scope.createPost = function () {

            blogService.createFullPost().then(function (preview) {             
                $location.path("/blogPage/"+preview.data.id);
            }, function (error) {
                console.log(error.data); // = 'Unable to load preview page data: ' + error.message;
            });
        
        };

        $scope.init = function () {
            getPostPreview();
        };

        $scope.init();

    });
});