webpackJsonp([2],{

/***/ "../../../../../src/app/layout-frontend/about/about.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/layout-frontend/about/about.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\r\n  about works!\r\n</p>\r\n"

/***/ }),

/***/ "../../../../../src/app/layout-frontend/about/about.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AboutComponent; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var AboutComponent = (function () {
    function AboutComponent() {
    }
    AboutComponent.prototype.ngOnInit = function () {
    };
    return AboutComponent;
}());
AboutComponent = __decorate([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["J" /* Component */])({
        selector: 'app-about',
        template: __webpack_require__("../../../../../src/app/layout-frontend/about/about.component.html"),
        styles: [__webpack_require__("../../../../../src/app/layout-frontend/about/about.component.css")]
    }),
    __metadata("design:paramtypes", [])
], AboutComponent);

//# sourceMappingURL=about.component.js.map

/***/ }),

/***/ "../../../../../src/app/layout-frontend/layout-frontend-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__layout_frontend_component__ = __webpack_require__("../../../../../src/app/layout-frontend/layout-frontend.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__about_about_component__ = __webpack_require__("../../../../../src/app/layout-frontend/about/about.component.ts");
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LayoutFrontendRoutingModule; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var routes = [
    {
        path: '', component: __WEBPACK_IMPORTED_MODULE_2__layout_frontend_component__["a" /* LayoutFrontendComponent */],
        children: [
            {
                path: 'about', component: __WEBPACK_IMPORTED_MODULE_3__about_about_component__["a" /* AboutComponent */]
            },
        ]
    }
];
var LayoutFrontendRoutingModule = (function () {
    function LayoutFrontendRoutingModule() {
    }
    return LayoutFrontendRoutingModule;
}());
LayoutFrontendRoutingModule = __decorate([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["b" /* NgModule */])({
        imports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* RouterModule */].forChild(routes)],
        exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* RouterModule */]]
    })
], LayoutFrontendRoutingModule);

//# sourceMappingURL=layout-frontend-routing.module.js.map

/***/ }),

/***/ "../../../../../src/app/layout-frontend/layout-frontend.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".main-container {\r\n  background-color: cadetblue;\r\n  height: 100%;\r\n  position: absolute;\r\n  width: 100%;\r\n  display: block;\r\n}\r\n.main-container>h1{\r\n  text-align:center;\r\n  color:#fff;\r\n}\r\n.btnmenu{\r\n  text-align:right;\r\n  margin:0 7px;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/layout-frontend/layout-frontend.component.html":
/***/ (function(module, exports) {

module.exports = "<section class=\"main-container\">\r\n  <h1>Welcome to Front and layout</h1>\r\n  <section class=\"btnmenu\">\r\n    <button class=\"btn btn-default\" [routerLink]=\"['/']\">Go to Home</button>\r\n    <button class=\"btn btn-default\" [routerLink]=\"['/admin']\">Go to dashboard</button>\r\n  </section>\r\n \r\n  <router-outlet></router-outlet>\r\n</section>"

/***/ }),

/***/ "../../../../../src/app/layout-frontend/layout-frontend.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LayoutFrontendComponent; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var LayoutFrontendComponent = (function () {
    function LayoutFrontendComponent() {
    }
    LayoutFrontendComponent.prototype.ngOnInit = function () {
    };
    return LayoutFrontendComponent;
}());
LayoutFrontendComponent = __decorate([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["J" /* Component */])({
        selector: 'app-layout-frontend',
        template: __webpack_require__("../../../../../src/app/layout-frontend/layout-frontend.component.html"),
        styles: [__webpack_require__("../../../../../src/app/layout-frontend/layout-frontend.component.css")]
    }),
    __metadata("design:paramtypes", [])
], LayoutFrontendComponent);

//# sourceMappingURL=layout-frontend.component.js.map

/***/ }),

/***/ "../../../../../src/app/layout-frontend/layout-frontend.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/@angular/common.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__layout_frontend_routing_module__ = __webpack_require__("../../../../../src/app/layout-frontend/layout-frontend-routing.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__layout_frontend_component__ = __webpack_require__("../../../../../src/app/layout-frontend/layout-frontend.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__about_about_component__ = __webpack_require__("../../../../../src/app/layout-frontend/about/about.component.ts");
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LayoutFrontendModule", function() { return LayoutFrontendModule; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var LayoutFrontendModule = (function () {
    function LayoutFrontendModule() {
    }
    return LayoutFrontendModule;
}());
LayoutFrontendModule = __decorate([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["b" /* NgModule */])({
        imports: [
            __WEBPACK_IMPORTED_MODULE_1__angular_common__["h" /* CommonModule */],
            __WEBPACK_IMPORTED_MODULE_2__layout_frontend_routing_module__["a" /* LayoutFrontendRoutingModule */],
        ],
        declarations: [__WEBPACK_IMPORTED_MODULE_3__layout_frontend_component__["a" /* LayoutFrontendComponent */], __WEBPACK_IMPORTED_MODULE_4__about_about_component__["a" /* AboutComponent */]]
    })
], LayoutFrontendModule);

//# sourceMappingURL=layout-frontend.module.js.map

/***/ })

});
//# sourceMappingURL=2.chunk.js.map