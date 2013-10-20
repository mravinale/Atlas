define(['modules/mainApp', 'services/home'], function (mainApp) {
    mainApp.controller('homeController', function ($rootScope, $scope, homeService) {
        
        $scope.slides = [];
        $scope.slides.push({ text: 'Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.', image: '/Content/images/slide-01.jpg' });
        $scope.slides.push({ text: 'Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.', image: '/Content/images/slide-02.jpg' });
        $scope.slides.push({ text: 'Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.', image: '/Content/images/slide-03.jpg' });

        var getPreviewInfo = function () {
            homeService.getPreviewInfo().then(function (editables) {
                $scope.editable1 = editables.data[0];
                $scope.editable2 = editables.data[1];
                $scope.editable3 = editables.data[2];
                }, function (error) {
                    console.log(error);
                });
        };

        var listener = $scope.$on('UpdatePreviewInfo', function (event, editable) {

            homeService.updatePreviewInfo(editable).then(function (result) {
                console.log(result.content);
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


