define(['modules/mainApp', 'services/blogPage'], function (mainApp) {
    
    mainApp.controller('blogPageController', function ($scope, blogPageService) {

        $scope.posts;
        $scope.status;
        
        var getPreviewPage = function () {
            
            blogPageService.getPreviewPage()
                .then(function (page) {
                    console.log(page.posts);
                    $scope.posts = page.posts;
                },function(error) {
                    $scope.status = 'Unable to load preview page data: ' + error.message;
                });
        };
        
        $scope.init = function(){
            getPreviewPage();
        };


        $scope.init();
    });

});




