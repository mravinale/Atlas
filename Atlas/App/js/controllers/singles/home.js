define(['modules/mainApp'], function (mainApp) {
    mainApp.controller('homeController', function ($scope, $location) {

        $scope.$location = $location;

        $scope.content = "<h2>Blog Post 1</h2><p >Suspendisse potenti. Donec egestas metus quis mauris ullamcorper eu consequat enim vulputate. Duis dictum ornare ante at accumsan. Mauris ornare sodales pretium.</p>" +
                "<p>" +
                "<a class='btn' href='/Blog'>Model details &raquo;</a>" +
                "</p> "        
        

    });

   

});


