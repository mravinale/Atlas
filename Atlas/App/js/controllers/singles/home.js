define(['modules/mainApp', 'services/home'], function (mainApp) {
    mainApp.controller('homeController', function ($scope, homeService) {

        $scope.posts;
          
        var getPreviewInfo = function () {
            homeService.getPreviewInfo().then(function (preview) {
                $scope.preview1 = preview.data[0];
                $scope.preview2 = preview.data[1];
                $scope.preview3 = preview.data[2];
                }, function (error) {
                    console.log(error); // = 'Unable to load preview page data: ' + error.message;
                });
        };

        $scope.$on('UpdatePreviewInfo', function (event, editable) {

            homeService.updatePreviewInfo(editable).then(function (posts) {
                console.log(editable.content);
            }, function (error) {
                console.log(error);
            });
            
        });

        $scope.init = function () {
            getPreviewInfo();
        };

        $scope.init();

    });   

});


