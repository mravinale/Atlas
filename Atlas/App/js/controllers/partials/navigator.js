//define(['modules/mainApp'], function (mainApp) {
   
//});

define(['modules/mainApp'], function (mainApp) {
    mainApp.controller('dialogController', function ($rootScope, $scope, dialog) {
        $scope.close = function (result) {
            dialog.close(result);
        };
    });
    
    mainApp.controller('navigatorController', function ($rootScope, $q, $dialog, $scope, homeService, $route, $location, blogService) {
         
        $scope.editEnable = false;
         
      
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
         

        //var modalOptions = {
        //    closeButtonText: 'Cancel',
        //    actionButtonText: 'Delete Customer',
        //    headerText: 'Delete ?',
        //    bodyText: 'Are you sure you want to delete this customer?'
        //};


        $scope.showModal = function () {

            var d = $dialog.dialog({
                backdrop: true,
                keyboard: true,
                dialogFade: true,
                backdropClick: false,
                templateUrl: '/App/html/partials/login.html',
                controller: 'dialogController',
                resolve: {
                    $parentScope: function () {
                        return $scope;
                    }
                }
            });
            d.open().then(function (result) {
                if (result) {
                    alert('dialog closed with result: ' + result);
                }
            });
             

            //var modalPromise = $modal({
            //    template: '/App/html/partials/login.html',
            //    persist: true,
            //    show: false,
            //    backdrop: 'static',
            //    scope: $scope
            //});
            //$q.when(modalPromise).then(function (modal) {
            //    console.log("go");
            //    console.log(modal);
            //    //modal.modal("show");
            //});

            //modalService.showModal({}, modalOptions).then(function (result) {
            //    alert("from modal");
            //});
        }
       
    });

   

});



