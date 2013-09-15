define(['modules/mainApp'], function (mainApp) {
    
    mainApp.service('blogService', ['$http', function ($http, $q) {

        var urlBase = '/api/blog/';

        this.getPostPreview = function () {
            return $http.get(urlBase + 'PostPreview');
        };

        
    }]);

});




