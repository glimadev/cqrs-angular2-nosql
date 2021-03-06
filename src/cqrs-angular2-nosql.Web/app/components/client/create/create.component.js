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
var ClientCreateComponent = (function () {
    function ClientCreateComponent(apiService, router) {
        var _this = this;
        this.apiService = apiService;
        this.router = router;
        this.client = new ClientCreate();
        this.create = function () {
            _this.apiService.postData("Client", _this.client, function () {
                _this.router.navigate(['/client-list']);
            });
        };
    }
    return ClientCreateComponent;
}());
ClientCreateComponent = __decorate([
    core_1.Component({
        templateUrl: 'create.component.html',
        moduleId: module.id
    }),
    __metadata("design:paramtypes", [api_service_1.ApiService, router_1.Router])
], ClientCreateComponent);
exports.ClientCreateComponent = ClientCreateComponent;
var ClientCreate = (function () {
    function ClientCreate() {
    }
    return ClientCreate;
}());
exports.ClientCreate = ClientCreate;
//# sourceMappingURL=create.component.js.map