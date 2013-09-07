'use strict';

// declare a new module, and inject the $compileProvider
angular.module('compile', [], function ($compileProvider) {
    // configure new 'compile' directive by passing a directive
    // factory function. The factory function injects the '$compile'
    $compileProvider.directive('compile', function ($compile) {
        // directive factory creates a link function
        return function (scope, element, attrs) {
            scope.$watch(
              function (scope) {
                  // watch the 'compile' expression for changes
                  return scope.$eval(attrs.compile);
              },
              function (value) {
                  // when the 'compile' expression changes
                  // assign it into the current DOM
                  element.html(value);

                  // compile the new DOM and link it to the current
                  // scope.
                  // NOTE: we only compile .childNodes so that
                  // we don't get into infinite loop compiling ourselves
                  $compile(element.contents())(scope);
              }
            );
        };
    })
});

angular.module('aloha', []).directive('aloha', ['$location', '$compile', function ($location, $compile) {
     

	// Because angularjs would route clicks on any links, but we
	// want the user to be able to click on links so he can edit
	// them.
	function preventAngularRouting(elem) {
	    $(elem).click(function (e) {
			return false;
		});
	}

	function replaceAngularLinkClickHandler(elem) {
		preventAngularRouting(elem);
		$(elem).on('click', 'a', function (e) {
			var href = $(this).attr('href');
			// Use metaKey for OSX and ctrlKey for PC.
			if (e.metaKey || e.ctrlKey) {
				if ('/' === href.charAt(0)) {
					// Relative links withing the angular app.
					$location.url(href);
					e.preventDefault();
				} else {
					// Absolute links pointing outside the angular app.
					window.location.href = href;
				}
			}
		});
	}

	// Also, we don't want the default ctrl+click behaviour of aloha,
	// which is to do window.location.href = href because that would
	// reload the page.
	function disableAlohaCtrlClickHandler() {
		Aloha.ready(function () {
			Aloha.bind('aloha-editable-activated', function (event, msg) {
				// There is no simple way to disable Aloha's ctrl-click
				// behaviour. We know the handler is bound when the editable
				// is activated, and with the timeout we make sure it is
				// unbound again afterwards.
				var editable = msg.editable;
				setTimeout(function () {
					editable.obj.unbind('click.aloha-link.meta-click-link');
				}, 10);
			});
		});
	}
    
	// Only do once for each page load.
	disableAlohaCtrlClickHandler();
   

	return {
		// Because we want to ensure that all directives on the element
		// will be honored, but all directives on descendant elements
		// will be considered non-bindable (priority -1000 and terminal
		// true). Necessary because the content may come prefilled from
	    // the server.
	    restrict: "E",
	    priority: -1000,
	    replace: true,	    
        template: "<div></div>",
		link: function ($scope, elem, attrs) {
            
		    Aloha.ready(function () {
		        
		        $(elem).aloha();
		        console.log(attrs);
		        Aloha.bind('aloha-smart-content-changed', function (jEvent, jData) {
		                $scope.alohaContent = jData.editable.getContents();
		                $scope.$apply();
                    
		                console.log($scope.alohaContent);
		        });


				$scope.$on('$destroy', function () {
					$(elem).mahalo();
				});
		    });

		    
		    replaceAngularLinkClickHandler(elem);
		}
	};
}])
