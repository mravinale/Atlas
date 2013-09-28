define(['modules/mainApp', 'controllers/partials/navigator', 'controllers/singles/home', 'controllers/singles/blog', 'controllers/singles/blogPage', 'controllers/singles/about'], function (mainApp) {

    mainApp.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/home', { templateUrl: 'App/html/partials/home.html', controller: 'homeController' })
            .when('/blog', { templateUrl: 'App/html/partials/blog.html', controller: 'blogController' })
            .when('/blogPage/:id', { templateUrl: 'App/html/partials/blogPage.html', controller: 'blogPageController' })
            .when('/about', { templateUrl: 'App/html/partials/about.html', controller: 'aboutController' })
            .otherwise({ redirectTo: '/home' });

        $locationProvider.html5Mode(false)

    });


});