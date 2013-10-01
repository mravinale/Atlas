define(['modules/mainApp'], function (mainApp) {
    mainApp.controller('navigatorController', function ($rootScope, $scope, homeService, $route, $location, blogService) {
         
        $scope.editEnable = false;

        $scope.slides = [];
        $scope.slides.push({ text: 'cats!', image: 'http://getbootstrap.com/2.3.2/assets/img/examples/slide-01.jpg' });
        $scope.slides.push({ text: 'cats!', image: 'http://getbootstrap.com/2.3.2/assets/img/examples/slide-02.jpg' });
        $scope.slides.push({ text: 'cats!', image: 'http://getbootstrap.com/2.3.2/assets/img/examples/slide-03.jpg' });

      
        $scope.delete = function () {
            blogService.deletePost($route.current.params.id).then(function (response) {
                $location.path("/blog");
            }, function (error) {
                console.log(error.data);
            });
        };

        $scope.create = function () {
            blogService.createPost().then(function (response) {
                $location.path("/blogPage/" + response.data.id);
            }, function (error) {
                console.log(error.data); 
            });
        };

        $scope.$on('$routeChangeSuccess', function (scope, next, current) {
           
            if (next.$$route.controller == 'blogPageController') {
                $scope.createButtonDisabled = true;
                $scope.editButtonDisabled = false;
                $scope.deleteButtonDisabled = false;
            }
            else if (next.$$route.controller == 'blogController') {
                $scope.createButtonDisabled = false;
                $scope.editButtonDisabled = true;
                $scope.deleteButtonDisabled = true;
            }
            else if (next.$$route.controller == 'homeController') {
                $scope.createButtonDisabled = true;
                $scope.editButtonDisabled = false;
                $scope.deleteButtonDisabled = true;
            }
             
        });

    });   

});


