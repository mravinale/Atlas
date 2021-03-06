//http://plnkr.co/edit/Ep5l2CLM4npjVSDP3c4d?p=preview
require.config({
    paths: {
        'jQuery': '/Scripts/jquery/jquery-1.9.1',
        'aloha': '/Scripts/aloha',
        'angular': '/Scripts/angular/angular',
        'angular-ui': '/Scripts/angular/angular-ui.min',
        'angular-strap': '/Scripts/angular/angular-strap.min',
        'angular-bootstrap-tpls': '/Scripts/angular/ui-bootstrap-tpls-0.5.0.min',
        'bootstrap': '/Scripts/boostrap/bootstrap',
        'modernizr': '/Scripts/jquery/modernizr-2.5.3',
        'holder':'/Scripts/holder',
        'angular-aloha': '/App/js/directives/angular-aloha'
    },
    baseUrl: 'app/js',
    shim: {
        'jQuery': { 'exports': 'jQuery' },
        'angular': { 'exports': 'angular' },
        'holder': { 'exports': 'holder' },
        'angular-ui': { deps: ['angular'] },
        'angular-strap': { deps: ['angular'] },
        'angular-bootstrap-tpls': { deps: ['angular'] },
        'angular-aloha': { deps: ['jQuery','angular','aloha'] }
    },
    priority: ['jQuery', 'cslider', 'angular' ]
});

require(['jQuery', 'angular','routes/mainRoutes'], function ($, angular) {
    
    angular.bootstrap(document, ['mainApp']);
});