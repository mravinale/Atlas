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

    mainApp.run(function ($rootScope, $location, $anchorScroll, $routeParams) {

        //when the route is changed scroll to the proper element.
        $rootScope.$on('$routeChangeSuccess', function (newRoute, oldRoute) {
           
            $rootScope.isMainSelected = false;
            $rootScope.isFeature1Selected = false;
            $rootScope.isFeature2Selected = false;
            $rootScope.isFeature3Selected = false;

            switch($location.hash()){
            
                case "main":
                    $rootScope.isMainSelected = true;
                    break;
                case "feature1":
                    $rootScope.isFeature1Selected = true;
                    break;
                case "feature2":
                    $rootScope.isFeature2Selected = true;
                    break;
                case "feature3":
                    $rootScope.isFeature3Selected = true;
                    break;

            }
            
        });
    });
     
});