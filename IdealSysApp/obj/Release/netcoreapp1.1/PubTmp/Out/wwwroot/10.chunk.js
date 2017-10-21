webpackJsonp([10],{

/***/ "../../../../../Client/app/page-not-found/page-not-found-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__page_not_found_component__ = __webpack_require__("../../../../../Client/app/page-not-found/page-not-found.component.ts");
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PageNotFoundRoutingModule; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    { path: '', component: __WEBPACK_IMPORTED_MODULE_2__page_not_found_component__["a" /* PageNotFoundComponent */] }
];
var PageNotFoundRoutingModule = (function () {
    function PageNotFoundRoutingModule() {
    }
    return PageNotFoundRoutingModule;
}());
PageNotFoundRoutingModule = __decorate([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
        imports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"].forChild(routes)],
        exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"]]
    })
], PageNotFoundRoutingModule);

//# sourceMappingURL=page-not-found-routing.module.js.map

/***/ }),

/***/ "../../../../../Client/app/page-not-found/page-not-found.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "\r\n:host {\r\n  display: block;\r\n}\r\n\r\n.welcome-page {\r\n  position: absolute;\r\n  top: 0;\r\n  left: 0;\r\n  right: 0;\r\n  bottom: 0;\r\n  overflow: auto;\r\n  background: #218E44;\r\n  text-align: center;\r\n  color: #fff;\r\n  padding: 10em;\r\n}\r\n  .col-lg-8 {\r\n    padding: 0;\r\n  }\r\n\r\n.rounded-btn {\r\n  border-radius: 50px;\r\n  color: rgba(255,255,255,0.8);\r\n  background: #6FB344;\r\n  border: 2px solid rgba(255,255,255,0.8);\r\n  font-size: 18px;\r\n  line-height: 40px;\r\n  padding: 0 25px;\r\n}\r\n\r\n  .rounded-btn:hover, .rounded-btn:focus, .rounded-btn:active, .rounded-btn:visited {\r\n    color: rgba(255,255,255,1);\r\n    border: 2px solid rgba(255,255,255,1);\r\n    outline: none;\r\n  }\r\n\r\n  h1 {\r\n    font-weight: 300;\r\n    margin-top: 20px;\r\n    margin-bottom: 10px;\r\n    font-size: 36px;\r\n  }\r\n\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../Client/app/page-not-found/page-not-found.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"welcome-page\" [@routerTransition]>\r\n  <div class=\"row\">\r\n    <div class=\"col-md-10 push-md-1\">\r\n      <h1>404 - Page Not Found</h1>\r\n      <p class=\"lead\">This page does not exist</p>\r\n      <p class=\"lead\">\r\n        <a class=\"btn rounded-btn\" [routerLink]=\"['/']\">Restart</a>\r\n      </p>\r\n    </div>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../Client/app/page-not-found/page-not-found.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__router_animations__ = __webpack_require__("../../../../../Client/app/router.animations.ts");
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PageNotFoundComponent; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var PageNotFoundComponent = (function () {
    function PageNotFoundComponent() {
    }
    PageNotFoundComponent.prototype.ngOnInit = function () {
    };
    return PageNotFoundComponent;
}());
PageNotFoundComponent = __decorate([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
        selector: 'app-page-not-found',
        template: __webpack_require__("../../../../../Client/app/page-not-found/page-not-found.component.html"),
        styles: [__webpack_require__("../../../../../Client/app/page-not-found/page-not-found.component.css")],
        animations: [__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__router_animations__["a" /* routerTransition */])()]
    }),
    __metadata("design:paramtypes", [])
], PageNotFoundComponent);

//# sourceMappingURL=page-not-found.component.js.map

/***/ }),

/***/ "../../../../../Client/app/page-not-found/page-not-found.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__page_not_found_component__ = __webpack_require__("../../../../../Client/app/page-not-found/page-not-found.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__page_not_found_routing_module__ = __webpack_require__("../../../../../Client/app/page-not-found/page-not-found-routing.module.ts");
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PageNotFoundModule", function() { return PageNotFoundModule; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var PageNotFoundModule = (function () {
    function PageNotFoundModule() {
    }
    return PageNotFoundModule;
}());
PageNotFoundModule = __decorate([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
        imports: [
            __WEBPACK_IMPORTED_MODULE_3__page_not_found_routing_module__["a" /* PageNotFoundRoutingModule */],
            __WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"]
        ],
        declarations: [__WEBPACK_IMPORTED_MODULE_2__page_not_found_component__["a" /* PageNotFoundComponent */]]
    })
], PageNotFoundModule);

//# sourceMappingURL=page-not-found.module.js.map

/***/ }),

/***/ "../../../../../Client/app/router.animations.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_animations__ = __webpack_require__("../../../animations/@angular/animations.es5.js");
/* harmony export (immutable) */ __webpack_exports__["a"] = routerTransition;
/* harmony export (immutable) */ __webpack_exports__["b"] = fadeAnimate;
/* unused harmony export slideToRight */
/* unused harmony export slideToLeft */
/* unused harmony export slideToBottom */
/* unused harmony export slideToTop */

function routerTransition() {
    return fadeAnimate();
}
function fadeAnimate() {
    // trigger name for attaching this animation to an element using the [@triggerName] syntax
    return __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["trigger"])('routerTransition', [
        // route 'enter' transition
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':enter', [
            // css styles at start of transition
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ opacity: 0 }),
            // animation and styles at end of transition
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('.3s', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ opacity: 1 }))
        ]),
    ]);
}
function slideToRight() {
    return __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["trigger"])('routerTransition', [
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["state"])('void', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({})),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["state"])('*', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({})),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':enter', [
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateX(-100%)' }),
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('0.5s ease-in-out', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateX(0%)' }))
        ]),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':leave', [
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateX(0%)' }),
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('0.5s ease-in-out', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateX(100%)' }))
        ])
    ]);
}
function slideToLeft() {
    return __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["trigger"])('routerTransition', [
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["state"])('void', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({})),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["state"])('*', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({})),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':enter', [
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateX(100%)' }),
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('0.5s ease-in-out', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateX(0%)' }))
        ]),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':leave', [
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateX(0%)' }),
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('0.5s ease-in-out', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateX(-100%)' }))
        ])
    ]);
}
function slideToBottom() {
    return __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["trigger"])('routerTransition', [
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["state"])('void', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({})),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["state"])('*', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({})),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':enter', [
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateY(-100%)' }),
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('0.5s ease-in-out', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateY(0%)' }))
        ]),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':leave', [
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateY(0%)' }),
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('0.5s ease-in-out', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateY(100%)' }))
        ])
    ]);
}
function slideToTop() {
    return __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["trigger"])('routerTransition', [
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["state"])('void', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({})),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["state"])('*', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({})),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':enter', [
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateY(100%)' }),
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('0.5s ease-in-out', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateY(0%)' }))
        ]),
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["transition"])(':leave', [
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateY(0%)' }),
            __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["animate"])('0.5s ease-in-out', __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_animations__["style"])({ transform: 'translateY(-100%)' }))
        ])
    ]);
}
//# sourceMappingURL=router.animations.js.map

/***/ })

});
//# sourceMappingURL=10.chunk.js.map