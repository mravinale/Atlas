define(['modules/mainApp'], function (mainApp) {
    
    mainApp.service('blogService', ['$http', function ($http, $q) {

        var urlBase = '/api/blog/';

        this.getPostPreview = function () {
            return $http.get(urlBase + 'PreviewPost');
        };

        this.getFullPost = function (id) {
            return $http.get(urlBase + 'FullPost/'+id);
        };

        this.createFullPost = function () {
            return $http.post(urlBase + 'CreateFullPost');
        };

        
    }]);

});




