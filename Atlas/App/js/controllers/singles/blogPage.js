define(['modules/mainApp', 'services/blog'], function (mainApp) {
    
    mainApp.controller('blogPageController', function ($scope, blogService, $route) {

        $scope.posts; 
        
        var getFullPost = function () {
            
            blogService.getFullPost($route.current.params.id)
                .then(function (post) {                   
                    $scope.post = post.data;
                }, function(error) {
                    console.log('Unable to load preview page data: ' + error.message);
                });
        };

        //need to work in the update
        
        $scope.init = function(){
            getFullPost();
        };


        $scope.init();
    });

});




