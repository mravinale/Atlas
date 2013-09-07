define(['modules/mainApp'], function (mainApp) {
    
    mainApp.service('blogPageService', ['$http', function ($http, $q) {

        var urlBase = '/api/blog';

        this.getPreviewPage = function () {
            return $http.get(urlBase + '/preview');
        };

        
    }]);

});




