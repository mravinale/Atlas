define(['modules/mainApp', 'services/home'], function (mainApp) {
    mainApp.controller('homeController', function ($rootScope, $scope, homeService) {
        
        $scope.slides = [];
        $scope.slides.push({ text: 'Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.', image: '/Content/images/slide-01.jpg' });
        $scope.slides.push({ text: 'Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.', image: '/Content/images/slide-02.jpg' });
        $scope.slides.push({ text: 'Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.', image: '/Content/images/slide-03.jpg' });

        var getPreviewInfo = function () {
            homeService.getPreviewInfo().then(function (preview) {
                $scope.preview1 = preview.data[0];
                $scope.preview2 = preview.data[1];
                $scope.preview3 = preview.data[2];
                }, function (error) {
                    console.log(error); // = 'Unable to load preview page data: ' + error.message;
                });
        };

        var listener = $scope.$on('UpdatePreviewInfo', function (event, editable) {

            homeService.updatePreviewInfo(editable).then(function (posts) {
                console.log(editable.content);
            }, function (error) {
                console.log(error);
            });
            
        });

        $scope.$on("$destroy", function () {
            listener();
        });

        $scope.init = function () {
            getPreviewInfo();
        };

        $scope.init();

    });   

});


