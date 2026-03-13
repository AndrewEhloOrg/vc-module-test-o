// Call this to register your module to main application
var moduleName = 'Artem.TestO';

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider',
        function ($stateProvider) {
            $stateProvider
                .state('workspace.TestOState', {
                    url: '/test-o',
                    templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                    controller: [
                        'platformWebApp.bladeNavigationService',
                        function (bladeNavigationService) {
                            var newBlade = {
                                id: 'blade1',
                                controller: 'Artem.TestO.helloWorldController',
                                template: 'Modules/$(Artem.TestO)/Scripts/blades/hello-world.html',
                                isClosingDisabled: true,
                            };
                            bladeNavigationService.showBlade(newBlade);
                        }
                    ]
                });
        }
    ])
    .run(['platformWebApp.mainMenuService', '$state',
        function (mainMenuService, $state) {
            //Register module in main menu
            var menuItem = {
                path: 'browse/test-o',
                icon: 'fa fa-cube',
                title: 'TestO',
                priority: 100,
                action: function () { $state.go('workspace.TestOState'); },
                permission: 'test-o:access',
            };
            mainMenuService.addMenuItem(menuItem);
        }
    ]);
