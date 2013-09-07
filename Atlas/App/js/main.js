require.config({ 
    paths: {
        'jQuery': '/Scripts/jquery/jquery-1.9.1.min',
        'aloha': '/Scripts/aloha',
        'angular': '/Scripts/angular/angular.min',
        'angular-ui': '/Scripts/angular/angular-ui.min',
        'angular-strap': '/Scripts/angular/angular-strap.min',
        'bootstrap': '/Scripts/boostrap/bootstrap.min',
        'modernizr': '/Scripts/jquery/modernizr-2.5.3',
        'cslider': '/Scripts/jquery/jquery.cslider',
        'angular-aloha': '/App/html/directives/angular-aloha'
    },
    baseUrl: 'app/js',
    shim: {
        'jQuery': { 'exports': 'jQuery' },
        'angular': { 'exports': 'angular' },
        'angular-ui': { deps: ['angular'] },
        'angular-strap': { deps: ['angular'] },
        'angular-aloha': { deps: ['jQuery','angular','aloha'] }
    },
    priority: [
		"angular"
    ]
});

require(['jQuery', 'angular', 'routes/mainRoutes'], function ($, angular) {
    
        angular.bootstrap(document, ['mainApp']); 
   
});