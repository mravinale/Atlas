define(['modules/mainApp'], function (mainApp) {
    
    mainApp.service('blogService', ['$http', function ($http, $q) {

        var urlBase = '/api/blog';

        this.getPreviewPage = function () {
            return $http.get(urlBase + '/preview');
        };

        
    }]);

});




