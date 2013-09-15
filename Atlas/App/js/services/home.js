define(['modules/mainApp'], function (mainApp) {
    
    mainApp.service('homeService', ['$http', function ($http, $q) {

        var urlBase = '/api/home/';

        this.getPosts = function () {
            return $http.get(urlBase+'Posts');
        };

        this.updatePost = function (post) { 
            return $http.put(urlBase + 'UpdatePost/' + post.id, post);
        };        

        
    }]);

});




