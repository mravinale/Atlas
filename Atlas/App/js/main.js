require.config({ 
    paths: {
        'jQuery': '/Scripts/jquery/jquery-1.9.1.min',
        'aloha': '/Scripts/aloha',
        'angular': '/Scripts/angular/angular.min',
        'angular-ui': '/Scripts/angular/angular-ui.min',
        'angular-strap': '/Scripts/angular/angular-strap.min',
        'angular-bootstrap': '/Scripts/angular/ui-bootstrap-0.6.0.min',
        'angular-bootstrap-tpls': '/Scripts/angular/ui-bootstrap-tpls-0.6.0.min',
        'bootstrap': '/Scripts/boostrap/bootstrap.min',
        'modernizr': '/Scripts/jquery/modernizr-2.5.3',
        'cslider': '/Scripts/jquery/jquery.cslider',
        'angular-aloha': '/App/js/directives/angular-aloha'
    },
    baseUrl: 'app/js',
    shim: {
        'jQuery': { 'exports': 'jQuery' },
        'angular': { 'exports': 'angular' },
        'angular-ui': { deps: ['angular', 'cslider'] },
        'angular-strap': { deps: ['angular'] },
        'angular-bootstrap': { deps: ['angular'] },
        'angular-bootstrap-tpls': { deps: ['angular'] },
        'angular-aloha': { deps: ['jQuery','angular','aloha'] }
    },
    priority: ['jQuery', 'cslider', 'angular' ]
});

require(['jQuery', 'angular','routes/mainRoutes'], function ($, angular) {
    
    //angular.module('ui.config', ['ui']).value('ui.config', {
    //    jq: {
    //        cslider: { autoplay: true, bgincrement: 450 }
    //    }
    //});   

    angular.bootstrap(document, ['mainApp']);
});