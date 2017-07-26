"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var router_1 = require("@angular/router");
var common_1 = require("@angular/common");
var http_1 = require("@angular/http");
var app_component_1 = require("./app.component");
var api_service_1 = require("./services/api.service");
var list_component_1 = require("./components/client/list/list.component");
var detail_component_1 = require("./components/client/detail/detail.component");
var appRoutes = [
    { path: 'client-list', component: list_component_1.ClientListComponent },
    { path: 'client-detail/:id', component: detail_component_1.ClientDetailComponent }
];
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            router_1.RouterModule.forRoot(appRoutes),
            http_1.HttpModule
        ],
        declarations: [
            app_component_1.AppComponent,
            list_component_1.ClientListComponent,
            detail_component_1.ClientDetailComponent
        ],
        bootstrap: [
            app_component_1.AppComponent
        ],
        providers: [
            api_service_1.ApiService,
            { provide: common_1.LocationStrategy, useClass: common_1.HashLocationStrategy }
        ]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map