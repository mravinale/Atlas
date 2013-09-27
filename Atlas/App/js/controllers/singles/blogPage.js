define(['modules/mainApp', 'services/blog'], function (mainApp) {
    
    mainApp.controller('blogPageController', function ($scope, blogService, $route) {
                
        var getPost = function () {            
            blogService.getPost($route.current.params.id).then(function (post) {                   
                    $scope.post = post.data;
                }, function(error) {
                    console.log('Unable to load preview page data: ' + error.message);
                });
        };

        $scope.$on('UpdatePost', function (event, editable) {
            editable.title = $scope.post.title;
             
            blogService.updatePost(editable).then(function (result) {
                console.log(result.content);
            }, function (error) {
                console.log(error);
            });

        });
        
        $scope.init = function () {
            setInterval(function () { getPost(); }, 300);         
        };

        $scope.init();
    });

});




