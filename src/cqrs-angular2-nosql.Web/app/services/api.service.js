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
var http_1 = require("@angular/http");
var ApiService = (function () {
    function ApiService(http) {
        this.http = http;
    }
    ApiService.prototype.getData = function (endpoint, callback) {
        var _this = this;
        this.http.get('/api/' + endpoint).subscribe(function (response) {
            _this.getResponse(response.json(), callback);
        });
    };
    ApiService.prototype.getResponse = function (response, callback) {
        if (response.success) {
            callback(response.data);
        }
    };
    return ApiService;
}());
ApiService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], ApiService);
exports.ApiService = ApiService;
var ResultService = (function () {
    function ResultService() {
    }
    return ResultService;
}());
exports.ResultService = ResultService;
//# sourceMappingURL=api.service.js.map