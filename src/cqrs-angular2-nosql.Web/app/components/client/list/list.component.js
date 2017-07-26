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
var ClientListComponent = (function () {
    function ClientListComponent(apiService) {
        this.apiService = apiService;
    }
    ClientListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.apiService.getData("Client", function (data) {
            _this.clients = data;
        });
    };
    return ClientListComponent;
}());
ClientListComponent = __decorate([
    core_1.Component({
        templateUrl: 'list.component.html',
        moduleId: module.id
    }),
    __metadata("design:paramtypes", [api_service_1.ApiService])
], ClientListComponent);
exports.ClientListComponent = ClientListComponent;
var Client = (function () {
    function Client() {
    }
    return Client;
}());
exports.Client = Client;
//# sourceMappingURL=list.component.js.map