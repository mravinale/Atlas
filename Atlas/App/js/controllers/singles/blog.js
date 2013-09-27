define(['modules/mainApp'], function (mainApp) {
    mainApp.controller('blogController', function ($scope, $location, blogService) {
         
        var getAllPost = function () {
            blogService.getAllPost().then(function (previews) {
                $scope.previewPosts = previews.data;
            }, function (error) {
                console.log(error); // = 'Unable to load preview page data: ' + error.message;
            });
        };

        $scope.createPost = function () {
            blogService.createPost().then(function (response) {
               $location.path("/blogPage/" + response.data.id);
            }, function (error) {
                console.log(error.data); // = 'Unable to load preview page data: ' + error.message;
            });        
        };

        $scope.init = function () {
            getAllPost();
        };

        $scope.init();

    });
});