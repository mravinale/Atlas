define(['modules/mainApp'], function (mainApp) {
    
    mainApp.service('homeService', ['$http', function ($http, $q) {

        var urlBase = '/api/home';

        this.getPreviewPosts = function () {
            return $http.get(urlBase + '/posts');
        };

        
    }]);

});




