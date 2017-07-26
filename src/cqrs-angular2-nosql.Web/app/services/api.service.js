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
var ngx_toastr_1 = require("ngx-toastr");
var ApiService = (function () {
    function ApiService(http, toastrService) {
        this.http = http;
        this.toastrService = toastrService;
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json', 'Accept': 'q=0.8;application/json;q=0.9' });
        this.options = new http_1.RequestOptions({ headers: this.headers });
    }
    ApiService.prototype.getData = function (endpoint, callback) {
        var _this = this;
        this.http.get('/api/' + endpoint, this.options).subscribe(function (response) {
            _this.getResponse(response.json(), false, callback);
        });
    };
    ApiService.prototype.postData = function (endpoint, body, callback) {
        var _this = this;
        this.http.post('/api/' + endpoint, body).subscribe(function (response) {
            _this.getResponse(response.json(), true, callback);
        });
    };
    ApiService.prototype.putData = function (endpoint, body, callback) {
        var _this = this;
        this.http.put('/api/' + endpoint, body).subscribe(function (response) {
            _this.getResponse(response.json(), true, callback);
        });
    };
    ApiService.prototype.deleteData = function (endpoint, callback) {
        var _this = this;
        this.http.delete('/api/' + endpoint).subscribe(function (response) {
            _this.getResponse(response.json(), true, callback);
        });
    };
    ApiService.prototype.getResponse = function (response, showSuccess, callback) {
        if (response.success) {
            if (showSuccess) {
                this.toastrService.success('Comando realizado', 'Sucesso!');
            }
            return callback ? callback(response.data) : 1;
        }
        this.toastrService.info(response.messages.join(", "), 'Info!');
    };
    return ApiService;
}());
ApiService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http, ngx_toastr_1.ToastrService])
], ApiService);
exports.ApiService = ApiService;
var ResultService = (function () {
    function ResultService() {
    }
    return ResultService;
}());
exports.ResultService = ResultService;
//# sourceMappingURL=api.service.js.map