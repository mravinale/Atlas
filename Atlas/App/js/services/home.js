define(['modules/mainApp'], function (mainApp) {
    
    mainApp.service('homeService', ['$http', function ($http) {

        var urlBase = '/api/home/';

        this.getPreviewInfo = function () {
            return $http.get(urlBase + 'PreviewInfo');
        };

        this.updatePreviewInfo = function (editable) { 
            return $http.put(urlBase + 'UpdatePreviewInfo/' + editable.id, editable);
        };

        
    }]);

});




