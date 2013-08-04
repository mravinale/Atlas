require.config({ 
    paths: {
        'jQuery': '/Scripts/jquery-1.9.1.min',
        'angular': '/Scripts/angular.min',
        'angular-ui': '/Scripts/angular-ui.min',
        'angular-strap': '/Scripts/angular-strap',
        'bootstrap': '/Scripts/bootstrap.min',
        'modernizr': '/Scripts/modernizr-2.5.3',
        'cslider': '/Scripts/jquery.cslider'
    },
    baseUrl: 'app/js',
    shim: {
        'jQuery': { 'exports': 'jQuery' },
        'angular': { 'exports': 'angular' },
        'angular-ui': { deps: ['angular'] },
        'angular-strap': { deps: ['angular'] }
    },
    priority: [
		"angular"
    ]
});

require(['jQuery', 'angular', 'routes/mainRoutes'], function ($, angular) {
    
        angular.bootstrap(document, ['mainApp']); 
   
});