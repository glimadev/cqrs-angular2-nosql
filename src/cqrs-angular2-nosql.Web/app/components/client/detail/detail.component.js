"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var api_service_1 = require("../../../services/api.service");
var router_1 = require("@angular/router");
var ClientDetailComponent = (function () {
    function ClientDetailComponent(apiService, route) {
        this.apiService = apiService;
        this.route = route;
        this.clientId = route.snapshot.paramMap.get('id');
    }
    ClientDetailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.apiService.getData("Client/?id=" + this.clientId, function (data) {
            _this.client = data;
        });
    };
    return ClientDetailComponent;
}());
ClientDetailComponent = __decorate([
    core_1.Component({
        templateUrl: 'detail.component.html',
        moduleId: module.id
    }),
    __metadata("design:paramtypes", [api_service_1.ApiService, router_1.ActivatedRoute])
], ClientDetailComponent);
exports.ClientDetailComponent = ClientDetailComponent;
var Client = (function () {
    function Client() {
    }
    return Client;
}());
exports.Client = Client;
//# sourceMappingURL=detail.component.js.map