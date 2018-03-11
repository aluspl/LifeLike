webpackJsonp([1],{

/***/ "./ClientApp/Album/AlbumLayout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AlbumLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Components_EmptyList_EmptyListView__ = __webpack_require__("./ClientApp/Components/EmptyList/EmptyListView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Components_Loading_LoadingView__ = __webpack_require__("./ClientApp/Components/Loading/LoadingView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Components_AlbumList_ListView__ = __webpack_require__("./ClientApp/Components/AlbumList/ListView.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var AlbumLayout = /** @class */ (function (_super) {
    __extends(AlbumLayout, _super);
    function AlbumLayout(props, state) {
        var _this = _super.call(this, props, state) || this;
        _this.paths = {
            getList: '/Api/Album/List'
        };
        _this.state = {
            loadingData: true,
            items: []
        };
        return _this;
    }
    AlbumLayout.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.getList, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                items: JSON.parse(data),
                loadingData: false
            });
        });
    };
    AlbumLayout.prototype.render = function () {
        var hasItems = this.state.items.length > 0;
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, "ALBUMS"),
            this.state.loadingData ?
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Components_Loading_LoadingView__["a" /* default */], { Title: 'Albums' }) :
                hasItems ?
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3__Components_AlbumList_ListView__["a" /* default */], { items: this.state.items }) : __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__Components_EmptyList_EmptyListView__["a" /* default */], { Title: "Album" }));
    };
    return AlbumLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Components/AlbumList/ListItem.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_moment__ = __webpack_require__("./node_modules/moment/moment.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_moment___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_moment__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var LogListItem = /** @class */ (function (_super) {
    __extends(LogListItem, _super);
    function LogListItem(props) {
        return _super.call(this, props) || this;
    }
    LogListItem.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("a", { href: "/Log/Details/" + this.props.item.Id },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'ListItem row' },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md-12' },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'ProjectsListItem-summary row' },
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md-6 padding-none' },
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'ProjectsListItem-name' }, this.props.item.Name)),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md-6 padding-none' },
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'pull-right' },
                                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'glyphicon glyphicon-calendar' }),
                                " ",
                                __WEBPACK_IMPORTED_MODULE_1_moment__(this.props.item.EventTime).format("DD-MM-YYYY")))),
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'row' },
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md-12 padding-none' },
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'ProjectsListItem-description' }, this.props.item.Messages)))))));
    };
    return LogListItem;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (LogListItem);


/***/ }),

/***/ "./ClientApp/Components/AlbumList/ListView.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__ListItem__ = __webpack_require__("./ClientApp/Components/AlbumList/ListItem.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var ListView = /** @class */ (function (_super) {
    __extends(ListView, _super);
    function ListView(props) {
        return _super.call(this, props) || this;
    }
    ListView.prototype.render = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: 'row' },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md-12' }, this.props.items.map(function (item) {
                return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__ListItem__["a" /* default */], { key: item.Id, item: item });
            })));
    };
    return ListView;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (ListView);


/***/ }),

/***/ "./ClientApp/Components/EmptyList/EmptyListView.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var EmptyListView = /** @class */ (function (_super) {
    __extends(EmptyListView, _super);
    function EmptyListView() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    EmptyListView.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, "Empty List"));
    };
    return EmptyListView;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (EmptyListView);


/***/ }),

/***/ "./ClientApp/Components/Loading/LoadingView.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var LoadingView = /** @class */ (function (_super) {
    __extends(LoadingView, _super);
    function LoadingView(props) {
        return _super.call(this, props) || this;
    }
    LoadingView.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, "Loading.."));
    };
    return LoadingView;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (LoadingView);


/***/ }),

/***/ "./ClientApp/Components/LogList/ListItem.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_moment__ = __webpack_require__("./node_modules/moment/moment.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_moment___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_moment__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_router_dom__ = __webpack_require__("./node_modules/react-router-dom/es/index.js");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();



var ListItem = /** @class */ (function (_super) {
    __extends(ListItem, _super);
    function ListItem() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListItem.prototype.SetupNavLink = function () {
        return '/Log/'.concat(this.props.item.Id.toString());
    };
    ListItem.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("tr", null,
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("td", null, this.props.item.Name),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("td", null,
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'fas fe' }),
                " ",
                __WEBPACK_IMPORTED_MODULE_1_moment__(this.props.item.EventTime).format("DD-MM-YYYY")),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("td", null, this.props.item.Messages),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("td", null,
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2_react_router_dom__["c" /* NavLink */], { to: this.SetupNavLink(), exact: true, activeClassName: 'active' }, "Detail"))));
    };
    return ListItem;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (ListItem);


/***/ }),

/***/ "./ClientApp/Components/LogList/LogList.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__ListItem__ = __webpack_require__("./ClientApp/Components/LogList/ListItem.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var ListView = /** @class */ (function (_super) {
    __extends(ListView, _super);
    function ListView() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListView.prototype.render = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", null,
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("table", { className: 'table' },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("thead", null,
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("tr", null,
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("th", { scope: "col" }, "Name"),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("th", { scope: "col" }, "Date"),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("th", { scope: "col" }, "Message"),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("th", { scope: "col" }, "Action"))),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("tbody", null, this.props.items.map(function (log) {
                    return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__ListItem__["a" /* default */], { key: log.Id, item: log });
                }))));
    };
    return ListView;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (ListView);


/***/ }),

/***/ "./ClientApp/Components/MenuList/ListItem.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom__ = __webpack_require__("./node_modules/react-router-dom/es/index.js");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var ListItem = /** @class */ (function (_super) {
    __extends(ListItem, _super);
    function ListItem() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListItem.prototype.SetupNavLink = function () {
        return '/'.concat(this.props.item.Controller).concat('/').concat(this.props.item.Action);
    };
    ListItem.prototype.SetupGlyph = function () {
        return 'fas fa-'.concat(this.props.item.IconName);
    };
    ListItem.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("li", { className: "nav-item" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["c" /* NavLink */], { className: "nav-link", to: this.SetupNavLink(), exact: true, activeClassName: 'active' },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("i", { className: this.SetupGlyph() }),
                "  ",
                this.props.item.Name)));
    };
    return ListItem;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (ListItem);


/***/ }),

/***/ "./ClientApp/Components/PageList/ListItem.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom__ = __webpack_require__("./node_modules/react-router-dom/es/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_moment__ = __webpack_require__("./node_modules/moment/moment.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_moment___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_moment__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();



var ListItem = /** @class */ (function (_super) {
    __extends(ListItem, _super);
    function ListItem() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListItem.prototype.SetupNavLink = function () {
        return ('/Post/').concat(this.props.item.ShortName);
    };
    ListItem.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["c" /* NavLink */], { className: 'col-sm-4', to: this.SetupNavLink() },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'subheading' }, this.props.item.FullName),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "row" },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md-6' },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("i", { className: 'fas fa-calendar' }),
                    " ",
                    this.props.item.ShortName),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md-3' },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("i", { className: 'fas fa-calendar' }),
                    __WEBPACK_IMPORTED_MODULE_2_moment__(this.props.item.Published).format("DD-MM-YYYY")))));
    };
    return ListItem;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (ListItem);


/***/ }),

/***/ "./ClientApp/Components/PageList/ListView.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__ListItem__ = __webpack_require__("./ClientApp/Components/PageList/ListItem.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var ListView = /** @class */ (function (_super) {
    __extends(ListView, _super);
    function ListView() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListView.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "row" }, this.props.items.map(function (item) {
            return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__ListItem__["a" /* default */], { key: item.Id, item: item });
        })));
    };
    return ListView;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (ListView);


/***/ }),

/***/ "./ClientApp/Components/VideoList/ListItem.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Youtube_Player__ = __webpack_require__("./ClientApp/Components/Youtube/Player.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var ListItem = /** @class */ (function (_super) {
    __extends(ListItem, _super);
    function ListItem() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListItem.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "col-md-6" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__Youtube_Player__["a" /* default */], { YoutubeId: this.props.item.YoutubeID })));
    };
    return ListItem;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (ListItem);


/***/ }),

/***/ "./ClientApp/Components/VideoList/ListView.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__ListItem__ = __webpack_require__("./ClientApp/Components/VideoList/ListItem.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var ListView = /** @class */ (function (_super) {
    __extends(ListView, _super);
    function ListView() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListView.prototype.render = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'row' }, this.props.items.map(function (item) {
            return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__ListItem__["a" /* default */], { key: item.Id, item: item });
        }));
    };
    return ListView;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (ListView);


/***/ }),

/***/ "./ClientApp/Components/Youtube/Player.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var Player = /** @class */ (function (_super) {
    __extends(Player, _super);
    function Player() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Player.prototype.render = function () {
        var videoUrl = "http://www.youtube.com/embed/" + this.props.YoutubeId;
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", null,
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("iframe", { className: "responsive-embed-item", src: videoUrl })));
    };
    return Player;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (Player);


/***/ }),

/***/ "./ClientApp/Home/HomeLayout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HomeLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Models_Config__ = __webpack_require__("./ClientApp/Models/Config.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Components_Youtube_Player__ = __webpack_require__("./ClientApp/Components/Youtube/Player.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Components_Loading_LoadingView__ = __webpack_require__("./ClientApp/Components/Loading/LoadingView.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var HomeLayout = /** @class */ (function (_super) {
    __extends(HomeLayout, _super);
    function HomeLayout(props) {
        var _this = _super.call(this, props) || this;
        _this.paths = {
            getList: '/Api/Config'
        };
        _this.state = { Item: new __WEBPACK_IMPORTED_MODULE_1__Models_Config__["a" /* default */], loadingData: true };
        return _this;
    }
    HomeLayout.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.getList, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                Item: JSON.parse(data),
                loadingData: false
            });
        });
    };
    HomeLayout.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" },
            this.state.loadingData ? __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3__Components_Loading_LoadingView__["a" /* default */], { Title: "Main Page" }) :
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" },
                    "LifeLike: ",
                    this.state.Item.WelcomeText),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Components_Youtube_Player__["a" /* default */], { YoutubeId: this.state.Item.WelcomeVideo })));
    };
    return HomeLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Layout/Layout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Layout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__NavMenu__ = __webpack_require__("./ClientApp/Layout/NavMenu.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();


var Layout = /** @class */ (function (_super) {
    __extends(Layout, _super);
    function Layout() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Layout.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'container' },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__NavMenu__["a" /* NavMenu */], null),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "container-fluid" }, this.props.children)));
    };
    return Layout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Layout/NavMenu.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return NavMenu; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom__ = __webpack_require__("./node_modules/react-router-dom/es/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Components_MenuList_ListItem__ = __webpack_require__("./ClientApp/Components/MenuList/ListItem.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();



var NavMenu = /** @class */ (function (_super) {
    __extends(NavMenu, _super);
    function NavMenu(props) {
        var _this = _super.call(this, props) || this;
        _this.paths = {
            getList: '/Api/Menu'
        };
        _this.state = {
            loadingData: true,
            items: []
        };
        return _this;
    }
    NavMenu.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.getList, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                items: JSON.parse(data),
                loadingData: false
            });
        });
    };
    NavMenu.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("nav", { className: "navbar navbar-expand-lg navbar-dark bg-primary fixed-top", id: "sideNav" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["c" /* NavLink */], { className: "navbar-brand", to: "/" },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: "d-block d-lg-none" }, "LifeLike"),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: "d-none d-lg-block" },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("img", { className: "img-fluid img-profile rounded mx-auto mb-2", src: "images/logo.png", alt: "" }))),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("button", { className: "navbar-toggler", type: "button", "data-toggle": "collapse", "data-target": "#navbarSupportedContent", "aria-controls": "navbarSupportedContent", "aria-expanded": "false", "aria-label": "Toggle navigation" },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: "navbar-toggler-icon" })),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "collapse navbar-collapse", id: "navbarSupportedContent" },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("ul", { className: 'navbar-nav' }, this.state.items.map(function (item) {
                    return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Components_MenuList_ListItem__["a" /* default */], { key: item.Id, item: item });
                })))));
    };
    return NavMenu;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Log/LogDetailLayout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LogDetailLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_moment__ = __webpack_require__("./node_modules/moment/moment.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_moment___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_moment__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Models_Log__ = __webpack_require__("./ClientApp/Models/Log.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();



var LogDetailLayout = /** @class */ (function (_super) {
    __extends(LogDetailLayout, _super);
    function LogDetailLayout(props, state) {
        var _this = _super.call(this, props) || this;
        _this.paths = {
            getList: '/Api/Log/Detail/'
        };
        _this.state = {
            loadingData: true,
            item: new __WEBPACK_IMPORTED_MODULE_2__Models_Log__["a" /* default */]
        };
        return _this;
    }
    LogDetailLayout.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.getList.concat(this.props.match.params.shortname), {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                item: JSON.parse(data),
                loadingData: false
            });
        });
    };
    LogDetailLayout.prototype.render = function () {
        return this.state.loadingData ? __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("h1", null, "Loading") :
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" },
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, this.state.item.Name),
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'row' },
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md' },
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'row' },
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md' },
                                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", { className: 'fas fe-calendar' }),
                                __WEBPACK_IMPORTED_MODULE_1_moment__(this.state.item.EventTime).format("DD-MM-YYYY"))),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'row' },
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md' },
                                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", null, this.state.item.Messages))),
                        __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'row' },
                            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: 'col-md' },
                                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("span", null, this.state.item.StackTrace))))));
    };
    return LogDetailLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Log/LogLayout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LogLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Components_Loading_LoadingView__ = __webpack_require__("./ClientApp/Components/Loading/LoadingView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Components_LogList_LogList__ = __webpack_require__("./ClientApp/Components/LogList/LogList.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Components_EmptyList_EmptyListView__ = __webpack_require__("./ClientApp/Components/EmptyList/EmptyListView.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var LogLayout = /** @class */ (function (_super) {
    __extends(LogLayout, _super);
    function LogLayout(props, state) {
        var _this = _super.call(this, props, state) || this;
        _this.paths = {
            getList: '/Api/Log/List'
        };
        _this.state = {
            loadingData: true,
            items: []
        };
        return _this;
    }
    LogLayout.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.getList, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                items: JSON.parse(data),
                loadingData: false
            });
        });
    };
    LogLayout.prototype.render = function () {
        var hasItems = this.state.items.length > 0;
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, "LOGS"),
            this.state.loadingData ?
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__Components_Loading_LoadingView__["a" /* default */], { Title: 'Logs' }) :
                hasItems ?
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Components_LogList_LogList__["a" /* default */], { items: this.state.items }) : __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3__Components_EmptyList_EmptyListView__["a" /* default */], { Title: "Logs" }));
    };
    return LogLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Models/Config.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
var Config = /** @class */ (function () {
    function Config() {
    }
    return Config;
}());
/* harmony default export */ __webpack_exports__["a"] = (Config);


/***/ }),

/***/ "./ClientApp/Models/Log.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
var Log = /** @class */ (function () {
    function Log() {
    }
    return Log;
}());
/* harmony default export */ __webpack_exports__["a"] = (Log);


/***/ }),

/***/ "./ClientApp/Models/Page.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
var Page = /** @class */ (function () {
    function Page() {
    }
    return Page;
}());
/* harmony default export */ __webpack_exports__["a"] = (Page);


/***/ }),

/***/ "./ClientApp/Page/PageLayout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PageLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Components_Loading_LoadingView__ = __webpack_require__("./ClientApp/Components/Loading/LoadingView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Components_PageList_ListView__ = __webpack_require__("./ClientApp/Components/PageList/ListView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Components_EmptyList_EmptyListView__ = __webpack_require__("./ClientApp/Components/EmptyList/EmptyListView.tsx");

var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var PageLayout = /** @class */ (function (_super) {
    __extends(PageLayout, _super);
    function PageLayout(props, state) {
        var _this = _super.call(this, props, state) || this;
        _this.paths = {
            All: '/Api/Page/Pages',
        };
        _this.state = {
            loadingData: true,
            items: []
        };
        return _this;
    }
    PageLayout.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.All, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                items: JSON.parse(data),
                loadingData: false
            });
        });
    };
    PageLayout.prototype.render = function () {
        var hasProjects = this.state.items.length > 0;
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, "Dev Projects"),
            this.state.loadingData ?
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__Components_Loading_LoadingView__["a" /* default */], { Title: "Posts" }) :
                hasProjects ?
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Components_PageList_ListView__["a" /* default */], { items: this.state.items }) : __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3__Components_EmptyList_EmptyListView__["a" /* default */], { Title: "Posts" })));
    };
    return PageLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Page/PostDetailLayout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PostDetailLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Models_Page__ = __webpack_require__("./ClientApp/Models/Page.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Components_Loading_LoadingView__ = __webpack_require__("./ClientApp/Components/Loading/LoadingView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__PostDetailView__ = __webpack_require__("./ClientApp/Page/PostDetailView.tsx");

var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var PostDetailLayout = /** @class */ (function (_super) {
    __extends(PostDetailLayout, _super);
    function PostDetailLayout(props) {
        var _this = _super.call(this, props) || this;
        _this.paths = {
            getList: '/Api/Page/Details/'
        };
        _this.state = {
            loadingData: true,
            Item: new __WEBPACK_IMPORTED_MODULE_1__Models_Page__["a" /* default */],
        };
        console.log(_this.state);
        return _this;
    }
    PostDetailLayout.prototype.componentDidMount = function () {
        var _this = this;
        var path = this.paths.getList.concat(this.props.match.params.shortname);
        console.log(path);
        fetch(path, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                Item: JSON.parse(data),
                loadingData: false
            });
        });
    };
    PostDetailLayout.prototype.render = function () {
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" }, this.state.loadingData ?
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Components_Loading_LoadingView__["a" /* default */], { Title: "Post" }) :
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3__PostDetailView__["a" /* default */], { Item: this.state.Item })));
    };
    return PostDetailLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Page/PostDetailView.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);

var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var PostDetailView = /** @class */ (function (_super) {
    __extends(PostDetailView, _super);
    function PostDetailView() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    PostDetailView.prototype.render = function () {
        var Item = this.props.Item;
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", null,
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, Item.FullName),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("p", null,
                " ",
                Item.Content,
                " "),
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("p", null,
                " ",
                Item.Category,
                " ")));
    };
    ;
    return PostDetailView;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));
/* harmony default export */ __webpack_exports__["a"] = (PostDetailView);


/***/ }),

/***/ "./ClientApp/Page/PostLayout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PostLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Components_EmptyList_EmptyListView__ = __webpack_require__("./ClientApp/Components/EmptyList/EmptyListView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Components_PageList_ListView__ = __webpack_require__("./ClientApp/Components/PageList/ListView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Components_Loading_LoadingView__ = __webpack_require__("./ClientApp/Components/Loading/LoadingView.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var PostLayout = /** @class */ (function (_super) {
    __extends(PostLayout, _super);
    function PostLayout(props, state) {
        var _this = _super.call(this, props, state) || this;
        _this.paths = {
            getList: '/Api/Page/Posts'
        };
        _this.state = {
            loadingData: true,
            items: []
        };
        return _this;
    }
    PostLayout.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.getList, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                items: JSON.parse(data),
                loadingData: false
            });
        });
    };
    PostLayout.prototype.render = function () {
        var hasProjects = this.state.items.length > 0;
        return (__WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, "News"),
            this.state.loadingData ?
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3__Components_Loading_LoadingView__["a" /* default */], { Title: "News" }) :
                hasProjects ?
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Components_PageList_ListView__["a" /* default */], { items: this.state.items }) : __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__Components_EmptyList_EmptyListView__["a" /* default */], { Title: "News" })));
    };
    return PostLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/RSS/Layout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return RSSLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var RSSLayout = /** @class */ (function (_super) {
    __extends(RSSLayout, _super);
    function RSSLayout(props) {
        return _super.call(this, props) || this;
    }
    RSSLayout.prototype.render = function () {
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, this.props.match.params.shortname));
    };
    return RSSLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/Routes.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return routes; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react_router_dom__ = __webpack_require__("./node_modules/react-router-dom/es/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Layout_Layout__ = __webpack_require__("./ClientApp/Layout/Layout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Home_HomeLayout__ = __webpack_require__("./ClientApp/Home/HomeLayout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__Page_PostLayout__ = __webpack_require__("./ClientApp/Page/PostLayout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__Page_PageLayout__ = __webpack_require__("./ClientApp/Page/PageLayout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__RSS_Layout__ = __webpack_require__("./ClientApp/RSS/Layout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__Page_PostDetailLayout__ = __webpack_require__("./ClientApp/Page/PostDetailLayout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__Log_LogLayout__ = __webpack_require__("./ClientApp/Log/LogLayout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__Log_LogDetailLayout__ = __webpack_require__("./ClientApp/Log/LogDetailLayout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__Video_VideoLayout__ = __webpack_require__("./ClientApp/Video/VideoLayout.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__Album_AlbumLayout__ = __webpack_require__("./ClientApp/Album/AlbumLayout.tsx");












var routes = __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Layout_Layout__["a" /* Layout */], null,
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { exact: true, path: '/', component: __WEBPACK_IMPORTED_MODULE_3__Home_HomeLayout__["a" /* HomeLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Index', component: __WEBPACK_IMPORTED_MODULE_3__Home_HomeLayout__["a" /* HomeLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Photos', component: __WEBPACK_IMPORTED_MODULE_11__Album_AlbumLayout__["a" /* AlbumLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Albums', component: __WEBPACK_IMPORTED_MODULE_11__Album_AlbumLayout__["a" /* AlbumLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Videos', component: __WEBPACK_IMPORTED_MODULE_10__Video_VideoLayout__["a" /* VideoLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Logs', component: __WEBPACK_IMPORTED_MODULE_8__Log_LogLayout__["a" /* LogLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { exact: true, path: '/RSS', component: __WEBPACK_IMPORTED_MODULE_6__RSS_Layout__["a" /* RSSLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { exact: true, path: '/RSS/:shortname', component: __WEBPACK_IMPORTED_MODULE_6__RSS_Layout__["a" /* RSSLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Log/:shortname', component: __WEBPACK_IMPORTED_MODULE_9__Log_LogDetailLayout__["a" /* LogDetailLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Album/:shortname', component: __WEBPACK_IMPORTED_MODULE_11__Album_AlbumLayout__["a" /* AlbumLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { exact: true, path: '/Pages', component: __WEBPACK_IMPORTED_MODULE_5__Page_PageLayout__["a" /* PageLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Page/:shortname', component: __WEBPACK_IMPORTED_MODULE_7__Page_PostDetailLayout__["a" /* PostDetailLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Posts', component: __WEBPACK_IMPORTED_MODULE_4__Page_PostLayout__["a" /* PostLayout */] }),
    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1_react_router_dom__["b" /* Route */], { path: '/Post/:shortname', component: __WEBPACK_IMPORTED_MODULE_7__Page_PostDetailLayout__["a" /* PostDetailLayout */] }));


/***/ }),

/***/ "./ClientApp/Styles/resume.scss":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "./ClientApp/Video/VideoLayout.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return VideoLayout; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Components_Loading_LoadingView__ = __webpack_require__("./ClientApp/Components/Loading/LoadingView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__Components_EmptyList_EmptyListView__ = __webpack_require__("./ClientApp/Components/EmptyList/EmptyListView.tsx");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Components_VideoList_ListView__ = __webpack_require__("./ClientApp/Components/VideoList/ListView.tsx");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var VideoLayout = /** @class */ (function (_super) {
    __extends(VideoLayout, _super);
    function VideoLayout(props, state) {
        var _this = _super.call(this, props, state) || this;
        _this.paths = {
            getList: '/Api/Video/'
        };
        _this.state = {
            loadingData: true,
            items: []
        };
        return _this;
    }
    VideoLayout.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.getList, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState({
                items: JSON.parse(data),
                loadingData: false
            });
        });
    };
    VideoLayout.prototype.render = function () {
        var hasProjects = this.state.items.length > 0;
        return __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("section", { className: "resume-section" },
            __WEBPACK_IMPORTED_MODULE_0_react__["createElement"]("div", { className: "subheading" }, "VIDEOS"),
            this.state.loadingData ?
                __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_1__Components_Loading_LoadingView__["a" /* default */], { Title: "Videos" }) :
                hasProjects ?
                    __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3__Components_VideoList_ListView__["a" /* default */], { items: this.state.items }) : __WEBPACK_IMPORTED_MODULE_0_react__["createElement"](__WEBPACK_IMPORTED_MODULE_2__Components_EmptyList_EmptyListView__["a" /* default */], { Title: "Videos" }));
    };
    return VideoLayout;
}(__WEBPACK_IMPORTED_MODULE_0_react__["Component"]));



/***/ }),

/***/ "./ClientApp/boot.tsx":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_bootstrap__ = __webpack_require__("./node_modules/bootstrap/dist/js/bootstrap.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_bootstrap___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_bootstrap__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react__ = __webpack_require__("./node_modules/react/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_react___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_react__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_dom__ = __webpack_require__("./node_modules/react-dom/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_react_dom___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_react_dom__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_react_hot_loader__ = __webpack_require__("./node_modules/react-hot-loader/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_react_hot_loader___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3_react_hot_loader__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_react_router_dom__ = __webpack_require__("./node_modules/react-router-dom/es/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__Routes__ = __webpack_require__("./ClientApp/Routes.tsx");






var routes = __WEBPACK_IMPORTED_MODULE_5__Routes__["a" /* routes */];
function renderApp() {
    // This code starts up the React app when it runs in a browser. It sets up the routing
    // configuration and injects the app into a DOM element.
    var baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
    __WEBPACK_IMPORTED_MODULE_2_react_dom__["render"](__WEBPACK_IMPORTED_MODULE_1_react__["createElement"](__WEBPACK_IMPORTED_MODULE_3_react_hot_loader__["AppContainer"], null,
        __WEBPACK_IMPORTED_MODULE_1_react__["createElement"](__WEBPACK_IMPORTED_MODULE_4_react_router_dom__["a" /* BrowserRouter */], { children: routes, basename: baseUrl })), document.getElementById('react-app'));
}
renderApp();


/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

__webpack_require__("./ClientApp/Styles/resume.scss");
module.exports = __webpack_require__("./ClientApp/boot.tsx");


/***/ })

},[0]);
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvQWxidW0vQWxidW1MYXlvdXQudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9Db21wb25lbnRzL0FsYnVtTGlzdC9MaXN0SXRlbS50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL0NvbXBvbmVudHMvQWxidW1MaXN0L0xpc3RWaWV3LnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvQ29tcG9uZW50cy9FbXB0eUxpc3QvRW1wdHlMaXN0Vmlldy50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL0NvbXBvbmVudHMvTG9hZGluZy9Mb2FkaW5nVmlldy50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL0NvbXBvbmVudHMvTG9nTGlzdC9MaXN0SXRlbS50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL0NvbXBvbmVudHMvTG9nTGlzdC9Mb2dMaXN0LnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvQ29tcG9uZW50cy9NZW51TGlzdC9MaXN0SXRlbS50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL0NvbXBvbmVudHMvUGFnZUxpc3QvTGlzdEl0ZW0udHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9Db21wb25lbnRzL1BhZ2VMaXN0L0xpc3RWaWV3LnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvQ29tcG9uZW50cy9WaWRlb0xpc3QvTGlzdEl0ZW0udHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9Db21wb25lbnRzL1ZpZGVvTGlzdC9MaXN0Vmlldy50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL0NvbXBvbmVudHMvWW91dHViZS9QbGF5ZXIudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9Ib21lL0hvbWVMYXlvdXQudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9MYXlvdXQvTGF5b3V0LnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvTGF5b3V0L05hdk1lbnUudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9Mb2cvTG9nRGV0YWlsTGF5b3V0LnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvTG9nL0xvZ0xheW91dC50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL01vZGVscy9Db25maWcudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL01vZGVscy9Mb2cudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL01vZGVscy9QYWdlLnRzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9QYWdlL1BhZ2VMYXlvdXQudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9QYWdlL1Bvc3REZXRhaWxMYXlvdXQudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9QYWdlL1Bvc3REZXRhaWxWaWV3LnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvUGFnZS9Qb3N0TGF5b3V0LnRzeCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvUlNTL0xheW91dC50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL1JvdXRlcy50c3giLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL1N0eWxlcy9yZXN1bWUuc2NzcyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvVmlkZW8vVmlkZW9MYXlvdXQudHN4Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9ib290LnRzeCJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7O0FBQStCO0FBRW1DO0FBQ047QUFDSjtBQVV4RDtJQUFpQywrQkFBNkI7SUFDMUQscUJBQVksS0FBWSxFQUFFLEtBQVk7UUFBdEMsWUFDSSxrQkFBTSxLQUFLLEVBQUUsS0FBSyxDQUFDLFNBS3RCO1FBRU8sV0FBSyxHQUFHO1lBQ1osT0FBTyxFQUFFLGlCQUFpQjtTQUM3QixDQUFDO1FBUkUsS0FBSSxDQUFDLEtBQUssR0FBRztZQUNULFdBQVcsRUFBRSxJQUFJO1lBQ2pCLEtBQUssRUFBRSxFQUFFO1NBQ1osQ0FBQzs7SUFDTixDQUFD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Q04sQ0FBQztBQUNELFNBQVMsRUFBRSxDQUFDIiwiZmlsZSI6ImVudHJ5LmpzIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSAncmVhY3QnO1xuaW1wb3J0IHsgUm91dGVDb21wb25lbnRQcm9wcyB9IGZyb20gJ3JlYWN0LXJvdXRlcic7XG5pbXBvcnQgRW1wdHlMaXN0VmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9FbXB0eUxpc3QvRW1wdHlMaXN0Vmlld1wiO1xuaW1wb3J0IExvYWRpbmdWaWV3IGZyb20gXCIuLi9Db21wb25lbnRzL0xvYWRpbmcvTG9hZGluZ1ZpZXdcIjtcbmltcG9ydCBMaXN0VmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9BbGJ1bUxpc3QvTGlzdFZpZXdcIjtcbmltcG9ydCBJdGVtIGZyb20gXCIuLi9Nb2RlbHMvQWxidW1cIjtcblxuaW50ZXJmYWNlICBQcm9wcyBleHRlbmRzIFJvdXRlQ29tcG9uZW50UHJvcHM8YW55PiB7XG4gICAgXG59XG5pbnRlcmZhY2UgU3RhdGUge1xuICAgIGxvYWRpbmdEYXRhOiBib29sZWFuLFxuICAgIGl0ZW1zOiBJdGVtW11cbn1cbmV4cG9ydCBjbGFzcyBBbGJ1bUxheW91dCBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxQcm9wcywgU3RhdGU+IHtcbiAgICBjb25zdHJ1Y3Rvcihwcm9wczogUHJvcHMsIHN0YXRlOiBTdGF0ZSkge1xuICAgICAgICBzdXBlcihwcm9wcywgc3RhdGUpO1xuICAgICAgICB0aGlzLnN0YXRlID0ge1xuICAgICAgICAgICAgbG9hZGluZ0RhdGE6IHRydWUsXG4gICAgICAgICAgICBpdGVtczogW11cbiAgICAgICAgfTtcbiAgICB9XG5cbiAgICBwcml2YXRlIHBhdGhzID0ge1xuICAgICAgICBnZXRMaXN0OiAnL0FwaS9BbGJ1bS9MaXN0J1xuICAgIH07XG4gICAgcHVibGljIGNvbXBvbmVudERpZE1vdW50KCkge1xuICAgICAgICBmZXRjaCh0aGlzLnBhdGhzLmdldExpc3QsIHtcbiAgICAgICAgICAgIGNyZWRlbnRpYWxzOiAnaW5jbHVkZScgfSlcbiAgICAgICAgICAgIC50aGVuKChyZXNwb25zZSkgPT4ge1xuICAgICAgICAgICAgICAgIHJldHVybiByZXNwb25zZS50ZXh0KCk7XG4gICAgICAgICAgICB9KVxuICAgICAgICAgICAgLnRoZW4oKGRhdGEpID0+IHtcbiAgICAgICAgICAgICAgICB0aGlzLnNldFN0YXRlKHtcbiAgICAgICAgICAgICAgICAgICAgaXRlbXM6IEpTT04ucGFyc2UoZGF0YSksXG4gICAgICAgICAgICAgICAgICAgIGxvYWRpbmdEYXRhOiBmYWxzZVxuICAgICAgICAgICAgICAgIH0pO1xuICAgICAgICAgICAgfSk7XG4gICAgfVxuICAgIHB1YmxpYyByZW5kZXIoKSB7XG4gICAgICAgIGNvbnN0IGhhc0l0ZW1zID0gdGhpcy5zdGF0ZS5pdGVtcy5sZW5ndGggPiAwO1xuXG4gICAgICAgIHJldHVybiA8c2VjdGlvbiBjbGFzc05hbWU9XCJyZXN1bWUtc2VjdGlvblwiPlxuICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJzdWJoZWFkaW5nXCI+XG4gICAgICAgICAgICAgICBBTEJVTVNcbiAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAge1xuICAgICAgICAgICAgICAgIHRoaXMuc3RhdGUubG9hZGluZ0RhdGEgP1xuICAgICAgICAgICAgICAgICAgICA8TG9hZGluZ1ZpZXcgVGl0bGU9eydBbGJ1bXMnfS8+IDpcbiAgICAgICAgICAgICAgICAgICAgaGFzSXRlbXMgP1xuICAgICAgICAgICAgICAgICAgICAgICAgPExpc3RWaWV3IGl0ZW1zPSB7dGhpcy5zdGF0ZS5pdGVtc30gLz4gOiAgPEVtcHR5TGlzdFZpZXcgVGl0bGU9e1wiQWxidW1cIn0gLz5cbiAgICAgICAgICAgIH1cbiAgICAgICAgPC9zZWN0aW9uPjtcbiAgICB9XG59XG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvQWxidW0vQWxidW1MYXlvdXQudHN4IiwiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSAncmVhY3QnO1xuaW1wb3J0ICogYXMgbW9tZW50IGZyb20gJ21vbWVudCc7XG5cbmltcG9ydCBJdGVtIGZyb20gJy4uLy4uL01vZGVscy9BbGJ1bSc7XG5cbmludGVyZmFjZSBMb2dMaXN0SXRlbVByb3Mge1xuICAgIGtleTogbnVtYmVyLFxuICAgIGl0ZW06IEl0ZW1cbn1cblxuY2xhc3MgTG9nTGlzdEl0ZW0gZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8TG9nTGlzdEl0ZW1Qcm9zLCBhbnk+IHtcblxuICAgIGNvbnN0cnVjdG9yKHByb3BzOiBMb2dMaXN0SXRlbVByb3MpXG4gICAge1xuICAgICAgICBzdXBlcihwcm9wcylcbiAgICB9XG4gICAgcmVuZGVyKCkge1xuICAgICAgICByZXR1cm4gKCAgICAgICAgICAgIFxuICAgICAgICAgICAgPGEgaHJlZj17YC9Mb2cvRGV0YWlscy8ke3RoaXMucHJvcHMuaXRlbS5JZH1gfT5cbiAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J0xpc3RJdGVtIHJvdyc+XG4gICAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPSdjb2wtbWQtMTInPlxuICAgICAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J1Byb2plY3RzTGlzdEl0ZW0tc3VtbWFyeSByb3cnPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPSdjb2wtbWQtNiBwYWRkaW5nLW5vbmUnPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzc05hbWU9J1Byb2plY3RzTGlzdEl0ZW0tbmFtZSc+e3RoaXMucHJvcHMuaXRlbS5OYW1lfTwvc3Bhbj5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0nY29sLW1kLTYgcGFkZGluZy1ub25lJz5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHNwYW4gY2xhc3NOYW1lPSdwdWxsLXJpZ2h0Jz5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzTmFtZT0nZ2x5cGhpY29uIGdseXBoaWNvbi1jYWxlbmRhcicvPiB7bW9tZW50KHRoaXMucHJvcHMuaXRlbS5FdmVudFRpbWUpLmZvcm1hdChcIkRELU1NLVlZWVlcIil9XG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvc3Bhbj5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J3Jvdyc+XG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J2NvbC1tZC0xMiBwYWRkaW5nLW5vbmUnPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzc05hbWU9J1Byb2plY3RzTGlzdEl0ZW0tZGVzY3JpcHRpb24nPnt0aGlzLnByb3BzLml0ZW0uTWVzc2FnZXN9PC9zcGFuPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgICAgICAgICAgICAgPC9kaXY+ICAgICAgICAgICAgICAgICAgICAgIFxuICAgICAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgICAgICA8L2E+XG4gICAgICAgIClcbiAgICB9XG5cbn1cblxuZXhwb3J0IGRlZmF1bHQgTG9nTGlzdEl0ZW07XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL0NvbXBvbmVudHMvQWxidW1MaXN0L0xpc3RJdGVtLnRzeCIsImltcG9ydCAqIGFzIFJlYWN0IGZyb20gJ3JlYWN0JztcblxuaW1wb3J0IEl0ZW0gZnJvbSAnLi4vLi4vTW9kZWxzL0FsYnVtJztcbmltcG9ydCBMaXN0SXRlbSBmcm9tICcuL0xpc3RJdGVtJztcblxuaW50ZXJmYWNlIExpc3RQcm9wcyB7XG4gICAgaXRlbXM6IEl0ZW1bXVxufVxuXG5jbGFzcyBMaXN0VmlldyBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxMaXN0UHJvcHMsIGFueT4ge1xuICAgIGNvbnN0cnVjdG9yKHByb3BzOiBMaXN0UHJvcHMpXG4gICAge1xuICAgICAgICBzdXBlcihwcm9wcylcbiAgICB9XG4gICAgXG4gICAgcmVuZGVyKCkge1xuICAgICAgICByZXR1cm4gPHNlY3Rpb24gY2xhc3NOYW1lPSdyb3cnPlxuICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J2NvbC1tZC0xMic+XG4gICAgICAgICAgICAgICAge1xuICAgICAgICAgICAgICAgICAgICB0aGlzLnByb3BzLml0ZW1zLm1hcChpdGVtID0+IHtcbiAgICAgICAgICAgICAgICAgICAgICAgIHJldHVybiA8TGlzdEl0ZW0ga2V5PXtpdGVtLklkfSBpdGVtPXtpdGVtfS8+XG4gICAgICAgICAgICAgICAgICAgIH0pXG4gICAgICAgICAgICAgICAgfVxuICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgIDwvc2VjdGlvbj5cbiAgICB9XG5cbn1cblxuZXhwb3J0IGRlZmF1bHQgTGlzdFZpZXc7XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL0NvbXBvbmVudHMvQWxidW1MaXN0L0xpc3RWaWV3LnRzeCIsImltcG9ydCAqIGFzIFJlYWN0IGZyb20gJ3JlYWN0JztcblxuaW50ZXJmYWNlIExvYWRpbmdWaWV3UHJvcHMge1xuICAgIFRpdGxlOiBzdHJpbmc7XG59XG5cbmNsYXNzIEVtcHR5TGlzdFZpZXcgZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8TG9hZGluZ1ZpZXdQcm9wcywgYW55PiB7XG5cbiAgICBwdWJsaWMgcmVuZGVyKCkge1xuICAgICAgICByZXR1cm4gKFxuICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJzdWJoZWFkaW5nXCI+XG4gICAgICAgICAgICAgICAgRW1wdHkgTGlzdFxuICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgIClcbiAgICB9XG59XG5cbmV4cG9ydCBkZWZhdWx0IEVtcHR5TGlzdFZpZXc7XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL0NvbXBvbmVudHMvRW1wdHlMaXN0L0VtcHR5TGlzdFZpZXcudHN4IiwiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSAncmVhY3QnO1xuXG5cbmludGVyZmFjZSBMb2FkaW5nVmlld1Byb3BzIHtcbiAgICBUaXRsZTogc3RyaW5nO1xufVxuXG5jbGFzcyBMb2FkaW5nVmlldyBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxMb2FkaW5nVmlld1Byb3BzLCBhbnk+IHtcblxuICAgIGNvbnN0cnVjdG9yKHByb3BzOiBMb2FkaW5nVmlld1Byb3BzKSB7XG4gICAgICAgIHN1cGVyKHByb3BzKTtcbiAgICAgICAgXG4gICAgfVxuICAgIHB1YmxpYyByZW5kZXIoKSB7XG4gICAgICAgIHJldHVybiAoXG4gICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJzdWJoZWFkaW5nXCI+XG4gICAgICAgICAgICAgICAgICAgIExvYWRpbmcuLlxuICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICApXG4gICAgfVxufVxuXG5leHBvcnQgZGVmYXVsdCBMb2FkaW5nVmlldztcblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvQ29tcG9uZW50cy9Mb2FkaW5nL0xvYWRpbmdWaWV3LnRzeCIsImltcG9ydCAqIGFzIFJlYWN0IGZyb20gJ3JlYWN0JztcbmltcG9ydCAqIGFzIG1vbWVudCBmcm9tICdtb21lbnQnO1xuXG5pbXBvcnQgSXRlbSBmcm9tICcuLi8uLi9Nb2RlbHMvTG9nJztcbmltcG9ydCB7IE5hdkxpbmsgfSBmcm9tICdyZWFjdC1yb3V0ZXItZG9tJztcblxuaW50ZXJmYWNlIEl0ZW1Qcm9zIHtcbiAgICBrZXk6IG51bWJlcixcbiAgICBpdGVtOiBJdGVtXG59XG5cbmNsYXNzIExpc3RJdGVtIGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PEl0ZW1Qcm9zLCBhbnk+IHtcbiAgICBcbiAgICBTZXR1cE5hdkxpbmsoKVxuICAgIHtcbiAgICAgICAgIHJldHVybiAnL0xvZy8nLmNvbmNhdCh0aGlzLnByb3BzLml0ZW0uSWQudG9TdHJpbmcoKSk7ICAgICAgICBcbiAgICB9ICBcbiAgICByZW5kZXIoKSB7XG4gICAgICAgIHJldHVybiAoICAgIFxuICAgICAgICAgICAgXG4gICAgICAgICAgIFxuICAgICAgICAgICAgICA8dHI+XG4gICAgICAgICAgICAgICAgICA8dGQ+XG4gICAgICAgICAgICAgICAgICAgICAge3RoaXMucHJvcHMuaXRlbS5OYW1lfVxuICAgICAgICAgICAgICAgICAgPC90ZD5cbiAgICAgICAgICAgICAgICAgIDx0ZD5cbiAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzc05hbWU9J2ZhcyBmZScvPiB7bW9tZW50KHRoaXMucHJvcHMuaXRlbS5FdmVudFRpbWUpLmZvcm1hdChcIkRELU1NLVlZWVlcIil9XG4gICAgICAgICAgICAgICAgICA8L3RkPlxuICAgICAgICAgICAgICAgICAgPHRkPlxuICAgICAgICAgICAgICAgICAgICAgIHt0aGlzLnByb3BzLml0ZW0uTWVzc2FnZXN9XG4gICAgICAgICAgICAgICAgICA8L3RkPlxuICAgICAgICAgICAgICAgICAgPHRkPlxuICAgICAgICAgICAgICAgICAgICAgIDxOYXZMaW5rIHRvPXt0aGlzLlNldHVwTmF2TGluaygpfSAgIGV4YWN0IGFjdGl2ZUNsYXNzTmFtZT0nYWN0aXZlJz5EZXRhaWw8L05hdkxpbms+XG4gICAgICAgICAgICAgICAgICA8L3RkPlxuICAgICAgICAgICAgICAgIDwvdHI+XG4gICAgICAgIClcbiAgICB9XG59XG5cbmV4cG9ydCBkZWZhdWx0IExpc3RJdGVtO1xuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9Db21wb25lbnRzL0xvZ0xpc3QvTGlzdEl0ZW0udHN4IiwiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSBcInJlYWN0XCI7XG5cbmltcG9ydCBMaXN0SXRlbSBmcm9tICcuL0xpc3RJdGVtJztcbmltcG9ydCBJdGVtIGZyb20gXCIuLi8uLi9Nb2RlbHMvTG9nXCI7XG5cbmludGVyZmFjZSBMaXN0UHJvcHMge1xuICAgIGl0ZW1zOiBJdGVtW11cbn1cblxuY2xhc3MgTGlzdFZpZXcgZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8TGlzdFByb3BzLCBhbnk+IHtcblxuICAgIHJlbmRlcigpIHtcbiAgICAgICAgcmV0dXJuIDxkaXY+XG4gICAgICAgICAgICA8dGFibGUgY2xhc3NOYW1lPSd0YWJsZSc+XG4gICAgICAgICAgICA8dGhlYWQ+XG4gICAgICAgICAgICA8dHI+XG4gICAgICAgICAgICAgICAgPHRoIHNjb3BlPVwiY29sXCI+TmFtZTwvdGg+XG4gICAgICAgICAgICAgICAgPHRoIHNjb3BlPVwiY29sXCI+RGF0ZTwvdGg+XG4gICAgICAgICAgICAgICAgPHRoIHNjb3BlPVwiY29sXCI+TWVzc2FnZTwvdGg+XG4gICAgICAgICAgICAgICAgPHRoIHNjb3BlPVwiY29sXCI+QWN0aW9uPC90aD5cblxuICAgICAgICAgICAgPC90cj5cbiAgICAgICAgICAgIDwvdGhlYWQ+XG4gICAgICAgICAgICA8dGJvZHk+XG4gICAgICAgICAgICAgICAge1xuICAgICAgICAgICAgICAgICAgICB0aGlzLnByb3BzLml0ZW1zLm1hcChsb2cgPT4ge1xuICAgICAgICAgICAgICAgICAgICAgICAgcmV0dXJuIDxMaXN0SXRlbSBrZXk9e2xvZy5JZH0gaXRlbT17bG9nfS8+XG4gICAgICAgICAgICAgICAgICAgIH0pXG4gICAgICAgICAgICAgICAgfVxuICAgICAgICAgICAgPC90Ym9keT5cbiAgICAgICAgPC90YWJsZT5cbiAgICAgICAgPC9kaXY+XG4gICAgfVxuXG59XG5cbmV4cG9ydCBkZWZhdWx0IExpc3RWaWV3O1xuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9Db21wb25lbnRzL0xvZ0xpc3QvTG9nTGlzdC50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5pbXBvcnQgeyBSb3V0ZXIgfSBmcm9tIFwicmVhY3Qtcm91dGVyXCI7XG5pbXBvcnQgSXRlbSBmcm9tICcuLi8uLi9Nb2RlbHMvTWVudUl0ZW0nO1xuaW1wb3J0IHtOYXZMaW5rfSBmcm9tIFwicmVhY3Qtcm91dGVyLWRvbVwiO1xuXG5pbnRlcmZhY2UgTGlzdEl0ZW1Qcm9zIHtcbiAgICBrZXk6IG51bWJlcixcbiAgICBpdGVtOiBJdGVtXG59XG5cbmNsYXNzIExpc3RJdGVtIGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PExpc3RJdGVtUHJvcywgYW55PiB7XG4gICAgU2V0dXBOYXZMaW5rKClcbiAgICB7XG4gICAgICAgICByZXR1cm4gJy8nLmNvbmNhdCh0aGlzLnByb3BzLml0ZW0uQ29udHJvbGxlcikuY29uY2F0KCcvJykuY29uY2F0KHRoaXMucHJvcHMuaXRlbS5BY3Rpb24pOyAgICAgICAgXG4gICAgfVxuICAgIFNldHVwR2x5cGgoKVxuICAgIHtcbiAgICAgICAgIHJldHVybidmYXMgZmEtJy5jb25jYXQodGhpcy5wcm9wcy5pdGVtLkljb25OYW1lKTsgICAgICAgIFxuICAgIH1cbiAgICByZW5kZXIoKSB7XG4gICAgICAgIHJldHVybiAoXG4gICAgICAgICAgICA8bGkgY2xhc3NOYW1lPVwibmF2LWl0ZW1cIj5cbiAgICAgICAgICAgICAgICA8TmF2TGluayBjbGFzc05hbWU9XCJuYXYtbGlua1wiICB0bz17dGhpcy5TZXR1cE5hdkxpbmsoKX0gICBleGFjdCBhY3RpdmVDbGFzc05hbWU9J2FjdGl2ZSc+XG4gICAgICAgICAgICAgICAgICAgIDxpIGNsYXNzTmFtZT17dGhpcy5TZXR1cEdseXBoKCl9Lz4gIHt0aGlzLnByb3BzLml0ZW0uTmFtZX1cbiAgICAgICAgICAgICAgICA8L05hdkxpbms+XG4gICAgICAgICAgICA8L2xpPlxuICAgICAgICApXG4gICAgfVxufVxuXG5leHBvcnQgZGVmYXVsdCBMaXN0SXRlbTtcblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvQ29tcG9uZW50cy9NZW51TGlzdC9MaXN0SXRlbS50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5pbXBvcnQge05hdkxpbmt9IGZyb20gXCJyZWFjdC1yb3V0ZXItZG9tXCI7XG5cbmltcG9ydCBJdGVtIGZyb20gJy4uLy4uL01vZGVscy9QYWdlJztcbmltcG9ydCAqIGFzIG1vbWVudCBmcm9tIFwibW9tZW50XCI7XG5cbmludGVyZmFjZSBMaXN0SXRlbVByb3Mge1xuICAgIGtleTogbnVtYmVyLFxuICAgIGl0ZW06IEl0ZW1cbn1cblxuY2xhc3MgTGlzdEl0ZW0gZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8TGlzdEl0ZW1Qcm9zLCBhbnk+IHtcbiAgICBTZXR1cE5hdkxpbmsoKSB7XG4gICAgICAgIHJldHVybiAoJy9Qb3N0LycpLmNvbmNhdCh0aGlzLnByb3BzLml0ZW0uU2hvcnROYW1lKTtcbiAgICB9XG5cbiAgICByZW5kZXIoKSB7XG4gICAgICAgIHJldHVybiAoXG4gICAgICAgICAgICA8TmF2TGluayBjbGFzc05hbWU9J2NvbC1zbS00JyB0bz17dGhpcy5TZXR1cE5hdkxpbmsoKX0+XG4gICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J3N1YmhlYWRpbmcnPlxuICAgICAgICAgICAgICAgICAgICB7dGhpcy5wcm9wcy5pdGVtLkZ1bGxOYW1lfVxuICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPVwicm93XCI+XG4gICAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPSdjb2wtbWQtNic+XG4gICAgICAgICAgICAgICAgICAgICAgICA8aSBjbGFzc05hbWU9J2ZhcyBmYS1jYWxlbmRhcicvPiB7dGhpcy5wcm9wcy5pdGVtLlNob3J0TmFtZX1cbiAgICAgICAgICAgICAgICAgICAgPC9kaXY+XG5cbiAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J2NvbC1tZC0zJz5cbiAgICAgICAgICAgICAgICAgICAgICAgIDxpIGNsYXNzTmFtZT0nZmFzIGZhLWNhbGVuZGFyJy8+e21vbWVudCh0aGlzLnByb3BzLml0ZW0uUHVibGlzaGVkKS5mb3JtYXQoXCJERC1NTS1ZWVlZXCIpfVxuICAgICAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgIDwvTmF2TGluaz5cbiAgICAgICAgKVxuICAgIH1cblxufVxuXG5leHBvcnQgZGVmYXVsdCBMaXN0SXRlbTtcblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvQ29tcG9uZW50cy9QYWdlTGlzdC9MaXN0SXRlbS50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5cblxuaW1wb3J0IEl0ZW0gZnJvbSAnLi4vLi4vTW9kZWxzL1BhZ2UnO1xuaW1wb3J0IExpc3RJdGVtIGZyb20gJy4vTGlzdEl0ZW0nO1xuXG5pbnRlcmZhY2UgTGlzdFByb3BzIHtcbiAgICBpdGVtczogSXRlbVtdXG59XG5cbmNsYXNzIExpc3RWaWV3IGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PExpc3RQcm9wcywgYW55PiB7XG5cbiAgICByZW5kZXIoKSB7XG4gICAgICAgIHJldHVybiAoXG4gICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cInJvd1wiPlxuICAgICAgICAgICAgICAgIHtcbiAgICAgICAgICAgICAgICAgICAgdGhpcy5wcm9wcy5pdGVtcy5tYXAoaXRlbSA9PiB7XG4gICAgICAgICAgICAgICAgICAgICAgICByZXR1cm4gPExpc3RJdGVtIGtleT17aXRlbS5JZH0gaXRlbT17aXRlbX0vPlxuICAgICAgICAgICAgICAgICAgICB9KVxuICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICApXG4gICAgfVxufVxuXG5leHBvcnQgZGVmYXVsdCBMaXN0VmlldztcblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvQ29tcG9uZW50cy9QYWdlTGlzdC9MaXN0Vmlldy50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5pbXBvcnQge05hdkxpbmt9IGZyb20gXCJyZWFjdC1yb3V0ZXItZG9tXCI7XG5pbXBvcnQgUGxheWVyIGZyb20gJy4uL1lvdXR1YmUvUGxheWVyJ1xuaW1wb3J0IEl0ZW0gZnJvbSAnLi4vLi4vTW9kZWxzL01lbnVJdGVtJztcblxuaW50ZXJmYWNlIExpc3RJdGVtUHJvcyB7XG4gICAga2V5OiBudW1iZXIsXG4gICAgaXRlbTogSXRlbVxufVxuXG5jbGFzcyBMaXN0SXRlbSBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxMaXN0SXRlbVByb3MsIGFueT4ge1xuICAgXG4gICAgcmVuZGVyKCkge1xuICAgICAgICByZXR1cm4gKCAgXG4gICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cImNvbC1tZC02XCI+XG4gICAgICAgICAgICAgICAgPFBsYXllciBZb3V0dWJlSWQ9e3RoaXMucHJvcHMuaXRlbS5Zb3V0dWJlSUR9IC8+XG4gICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgKTtcbiAgICB9XG59XG5cbmV4cG9ydCBkZWZhdWx0IExpc3RJdGVtO1xuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9Db21wb25lbnRzL1ZpZGVvTGlzdC9MaXN0SXRlbS50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5cblxuaW1wb3J0IEl0ZW0gZnJvbSAnLi4vLi4vTW9kZWxzL01lbnVJdGVtJztcbmltcG9ydCBMaXN0SXRlbSBmcm9tICcuL0xpc3RJdGVtJztcblxuaW50ZXJmYWNlIExpc3RQcm9wcyB7XG4gICAgaXRlbXM6IEl0ZW1bXVxufVxuXG5jbGFzcyBMaXN0VmlldyBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxMaXN0UHJvcHMsIGFueT4ge1xuXG4gICAgcmVuZGVyKCkge1xuICAgICAgICByZXR1cm4gIDxkaXYgY2xhc3NOYW1lPSdyb3cnPlxuICAgICAgICAgICAgICAgICAgICAgICAge1xuICAgICAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMucHJvcHMuaXRlbXMubWFwKGl0ZW0gPT4ge1xuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICByZXR1cm4gPExpc3RJdGVtIGtleT17aXRlbS5JZH0gaXRlbT17aXRlbX0vPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIH0pXG4gICAgICAgICAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICAgICAgPC9kaXY+XG4gICAgfVxufVxuXG5leHBvcnQgZGVmYXVsdCBMaXN0VmlldztcblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvQ29tcG9uZW50cy9WaWRlb0xpc3QvTGlzdFZpZXcudHN4IiwiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSBcInJlYWN0XCI7XG5cbmludGVyZmFjZSBJUGxheWVyIHtcbiAgICBZb3V0dWJlSWQ6IHN0cmluZ1xufVxuXG5jbGFzcyBQbGF5ZXIgZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8SVBsYXllciwgYW55PiB7XG5cbiAgICByZW5kZXIoKSB7XG4gICAgICAgIGNvbnN0IHZpZGVvVXJsID0gYGh0dHA6Ly93d3cueW91dHViZS5jb20vZW1iZWQvJHt0aGlzLnByb3BzLllvdXR1YmVJZH1gO1xuXG4gICAgICAgIHJldHVybiAoXG4gICAgICAgICAgICA8ZGl2PlxuICAgICAgICAgICAgICAgIDxpZnJhbWUgY2xhc3NOYW1lPVwicmVzcG9uc2l2ZS1lbWJlZC1pdGVtXCIgc3JjPXt2aWRlb1VybH0vPlxuICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICAgKTtcbiAgICAgIH0gICAgICAgXG59XG5cbmV4cG9ydCBkZWZhdWx0IFBsYXllcjtcblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvQ29tcG9uZW50cy9Zb3V0dWJlL1BsYXllci50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5pbXBvcnQgeyBSb3V0ZUNvbXBvbmVudFByb3BzIH0gZnJvbSAncmVhY3Qtcm91dGVyJztcbmltcG9ydCBDb25maWcgZnJvbSAnLi4vTW9kZWxzL0NvbmZpZydcbmltcG9ydCBQbGF5ZXIgZnJvbSAnLi4vQ29tcG9uZW50cy9Zb3V0dWJlL1BsYXllcidcbmltcG9ydCBMb2FkaW5nVmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9Mb2FkaW5nL0xvYWRpbmdWaWV3XCI7XG5pbnRlcmZhY2UgSUhvbWVTdGF0ZXtcbiAgSXRlbTogQ29uZmlnLFxuICBsb2FkaW5nRGF0YTogYm9vbGVhblxuXG59XG5leHBvcnQgY2xhc3MgSG9tZUxheW91dCBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxSb3V0ZUNvbXBvbmVudFByb3BzPHt9PiwgSUhvbWVTdGF0ZT4ge1xuICAgIGNvbnN0cnVjdG9yKHByb3BzOlJvdXRlQ29tcG9uZW50UHJvcHM8e30+KSB7XG4gICAgICAgIHN1cGVyKHByb3BzKTtcbiAgICAgICAgdGhpcy5zdGF0ZSA9IHsgSXRlbTogbmV3IENvbmZpZywgbG9hZGluZ0RhdGE6IHRydWUgfTtcbiAgICB9XG4gICAgcHJpdmF0ZSBwYXRocyA9IHtcbiAgICAgICAgZ2V0TGlzdDogJy9BcGkvQ29uZmlnJ1xuICAgIH07ICAgXG4gICAgcHVibGljIGNvbXBvbmVudERpZE1vdW50KCkge1xuICAgICAgICBmZXRjaCh0aGlzLnBhdGhzLmdldExpc3QsIHsgXG4gICAgICAgICAgICBjcmVkZW50aWFsczogJ2luY2x1ZGUnIH0pXG4gICAgICAgICAgICAudGhlbigocmVzcG9uc2UpID0+IHtcbiAgICAgICAgICAgICAgICByZXR1cm4gcmVzcG9uc2UudGV4dCgpO1xuICAgICAgICAgICAgfSlcbiAgICAgICAgICAgIC50aGVuKChkYXRhKSA9PiB7XG4gICAgICAgICAgICAgICAgdGhpcy5zZXRTdGF0ZSh7XG4gICAgICAgICAgICAgICAgICAgIEl0ZW06IEpTT04ucGFyc2UoZGF0YSksXG4gICAgICAgICAgICAgICAgICAgIGxvYWRpbmdEYXRhOiBmYWxzZVxuICAgICAgICAgICAgICAgIH0pO1xuICAgICAgICAgICAgfSk7XG4gICAgfVxuICAgIHB1YmxpYyByZW5kZXIoKSB7XG4gICAgICAgICAgICByZXR1cm4gKFxuICAgICAgICAgICAgICAgIDxzZWN0aW9uIGNsYXNzTmFtZT1cInJlc3VtZS1zZWN0aW9uXCI+XG4gICAgICAgICAgICAgICAge1xuICAgICAgICAgICAgICAgICAgICB0aGlzLnN0YXRlLmxvYWRpbmdEYXRhID8gPExvYWRpbmdWaWV3IFRpdGxlPVwiTWFpbiBQYWdlXCIvPiA6XG4gICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cInN1YmhlYWRpbmdcIj5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICBMaWZlTGlrZToge3RoaXMuc3RhdGUuSXRlbS5XZWxjb21lVGV4dH1cbiAgICAgICAgICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgICAgICAgICAgPFBsYXllciBZb3V0dWJlSWQ9e3RoaXMuc3RhdGUuSXRlbS5XZWxjb21lVmlkZW99IC8+XG5cbiAgICAgICAgICAgICAgICAgICAgey8qPHA+e3RoaXMuc3RhdGUuSXRlbS5Sc3MxVXJsfSA8L3A+Ki99XG4gICAgICAgICAgICAgICAgey8qPHA+e3RoaXMuc3RhdGUuSXRlbS5Sc3MyVXJsfSA8L3A+Ki99XG4gICAgICAgICAgICAgICAgXG4gICAgICAgICAgICA8L3NlY3Rpb24+KVxuICAgIH1cbn1cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9Ib21lL0hvbWVMYXlvdXQudHN4IiwiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSAncmVhY3QnO1xuaW1wb3J0IHtOYXZNZW51fSBmcm9tICcuL05hdk1lbnUnO1xuXG5leHBvcnQgaW50ZXJmYWNlIExheW91dFByb3BzIHtcbiAgICBjaGlsZHJlbj86IFJlYWN0LlJlYWN0Tm9kZTtcbn1cblxuZXhwb3J0IGNsYXNzIExheW91dCBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxMYXlvdXRQcm9wcywge30+IHtcbiAgICBwdWJsaWMgcmVuZGVyKCkge1xuICAgICAgICByZXR1cm4gICggXG4gICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0nY29udGFpbmVyJz5cbiAgICAgICAgICAgICAgICA8TmF2TWVudS8+XG4gICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJjb250YWluZXItZmx1aWRcIj5cbiAgICAgICAgICAgICAgICAgICAgICAgIHt0aGlzLnByb3BzLmNoaWxkcmVufVxuICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICk7XG4gICAgfVxufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL0xheW91dC9MYXlvdXQudHN4IiwiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSAncmVhY3QnO1xuaW1wb3J0IHsgTmF2TGluayB9IGZyb20gJ3JlYWN0LXJvdXRlci1kb20nO1xuaW1wb3J0IEl0ZW0gZnJvbSBcIi4uL01vZGVscy9NZW51SXRlbVwiO1xuaW1wb3J0IExpc3RJdGVtIGZyb20gXCIuLi9Db21wb25lbnRzL01lbnVMaXN0L0xpc3RJdGVtXCI7XG5cbmludGVyZmFjZSBOYXZNZW51U3RhdGUge1xuICAgIGxvYWRpbmdEYXRhOiBib29sZWFuLFxuICAgIGl0ZW1zOiBJdGVtW11cbn1cbmludGVyZmFjZSBOYXZNZW51UHJvcHN7XG5cbn1cblxuZXhwb3J0IGNsYXNzIE5hdk1lbnUgZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8TmF2TWVudVByb3BzLCBOYXZNZW51U3RhdGU+IHtcbiAgICBwcml2YXRlIHBhdGhzID0ge1xuICAgICAgICBnZXRMaXN0OiAnL0FwaS9NZW51J1xuICAgIH07XG5cbiAgICBjb25zdHJ1Y3Rvcihwcm9wczogTmF2TWVudVByb3BzKSB7XG4gICAgICAgIHN1cGVyKHByb3BzKTtcblxuICAgICAgICB0aGlzLnN0YXRlID0ge1xuICAgICAgICAgICAgbG9hZGluZ0RhdGE6IHRydWUsXG4gICAgICAgICAgICBpdGVtczogW11cbiAgICAgICAgfTtcbiAgICB9XG4gICAgcHVibGljIGNvbXBvbmVudERpZE1vdW50KCkge1xuICAgICAgICBmZXRjaCh0aGlzLnBhdGhzLmdldExpc3QsIHtcbiAgICAgICAgICAgIGNyZWRlbnRpYWxzOiAnaW5jbHVkZScgfSlcbiAgICAgICAgICAgIC50aGVuKChyZXNwb25zZSkgPT4ge1xuICAgICAgICAgICAgICAgIHJldHVybiByZXNwb25zZS50ZXh0KCk7XG4gICAgICAgICAgICB9KVxuICAgICAgICAgICAgLnRoZW4oKGRhdGEpID0+IHtcbiAgICAgICAgICAgICAgICB0aGlzLnNldFN0YXRlKHtcbiAgICAgICAgICAgICAgICAgICAgaXRlbXM6IEpTT04ucGFyc2UoZGF0YSksXG4gICAgICAgICAgICAgICAgICAgIGxvYWRpbmdEYXRhOiBmYWxzZVxuICAgICAgICAgICAgICAgIH0pO1xuICAgICAgICAgICAgfSk7XG4gICAgfVxuICAgIHB1YmxpYyByZW5kZXIoKSB7XG4gICAgICAgIHJldHVybiAoXG4gICAgICAgICAgICA8bmF2IGNsYXNzTmFtZT1cIm5hdmJhciBuYXZiYXItZXhwYW5kLWxnIG5hdmJhci1kYXJrIGJnLXByaW1hcnkgZml4ZWQtdG9wXCIgaWQ9XCJzaWRlTmF2XCI+XG4gICAgICAgICAgICAgICAgPE5hdkxpbmsgY2xhc3NOYW1lPVwibmF2YmFyLWJyYW5kXCIgdG89XCIvXCI+XG4gICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzTmFtZT1cImQtYmxvY2sgZC1sZy1ub25lXCI+TGlmZUxpa2U8L3NwYW4+XG4gICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzTmFtZT1cImQtbm9uZSBkLWxnLWJsb2NrXCI+XG4gICAgICAgICAgICAgICAgICAgICAgICA8aW1nIGNsYXNzTmFtZT1cImltZy1mbHVpZCBpbWctcHJvZmlsZSByb3VuZGVkIG14LWF1dG8gbWItMlwiIHNyYz1cImltYWdlcy9sb2dvLnBuZ1wiIGFsdD1cIlwiLz5cbiAgICAgICAgICAgICAgICAgICAgPC9zcGFuPlxuICAgICAgICAgICAgICAgIDwvTmF2TGluaz5cbiAgICAgICAgICAgICAgICA8YnV0dG9uIGNsYXNzTmFtZT1cIm5hdmJhci10b2dnbGVyXCIgdHlwZT1cImJ1dHRvblwiIGRhdGEtdG9nZ2xlPVwiY29sbGFwc2VcIiBkYXRhLXRhcmdldD1cIiNuYXZiYXJTdXBwb3J0ZWRDb250ZW50XCIgYXJpYS1jb250cm9scz1cIm5hdmJhclN1cHBvcnRlZENvbnRlbnRcIiBhcmlhLWV4cGFuZGVkPVwiZmFsc2VcIiBhcmlhLWxhYmVsPVwiVG9nZ2xlIG5hdmlnYXRpb25cIj5cbiAgICAgICAgICAgICAgICAgICAgPHNwYW4gY2xhc3NOYW1lPVwibmF2YmFyLXRvZ2dsZXItaWNvblwiLz5cbiAgICAgICAgICAgICAgICA8L2J1dHRvbj5cbiAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cImNvbGxhcHNlIG5hdmJhci1jb2xsYXBzZVwiIGlkPVwibmF2YmFyU3VwcG9ydGVkQ29udGVudFwiPlxuICAgICAgICAgICAgICAgICAgICA8dWwgY2xhc3NOYW1lPSduYXZiYXItbmF2Jz5cbiAgICAgICAgICAgICAgICAgICAgICAgIHtcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB0aGlzLnN0YXRlLml0ZW1zLm1hcChpdGVtID0+IHtcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgcmV0dXJuIDxMaXN0SXRlbSBrZXk9e2l0ZW0uSWR9IGl0ZW09e2l0ZW19Lz5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB9KVxuICAgICAgICAgICAgICAgICAgICAgICAgfVxuICAgICAgICAgICAgICAgICAgICA8L3VsPlxuICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgPC9uYXY+XG4gICAgKTtcbiAgICB9XG59XG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvTGF5b3V0L05hdk1lbnUudHN4IiwiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSAncmVhY3QnO1xuaW1wb3J0ICogYXMgbW9tZW50IGZyb20gJ21vbWVudCc7XG5pbXBvcnQge1JvdXRlQ29tcG9uZW50UHJvcHN9IGZyb20gJ3JlYWN0LXJvdXRlcic7XG5pbXBvcnQgTG9nIGZyb20gJy4uL01vZGVscy9Mb2cnO1xuXG5pbnRlcmZhY2UgU3RhdGUge1xuICAgIGxvYWRpbmdEYXRhOiBib29sZWFuLFxuICAgIGl0ZW06IExvZ1xufVxuXG5pbnRlcmZhY2UgIFByb3BzIGV4dGVuZHMgUm91dGVDb21wb25lbnRQcm9wczxhbnk+IHtcbiAgICBzaG9ydG5hbWU6IHN0cmluZ1xufVxuXG5leHBvcnQgY2xhc3MgTG9nRGV0YWlsTGF5b3V0IGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PFByb3BzLCBTdGF0ZT4ge1xuICAgIHByaXZhdGUgcGF0aHMgPSB7XG4gICAgICAgIGdldExpc3Q6ICcvQXBpL0xvZy9EZXRhaWwvJ1xuICAgIH07XG5cbiAgICBjb25zdHJ1Y3Rvcihwcm9wczogUHJvcHMsIHN0YXRlOiBTdGF0ZSkge1xuICAgICAgICBzdXBlcihwcm9wcyk7XG5cbiAgICAgICAgdGhpcy5zdGF0ZSA9IHtcbiAgICAgICAgICAgIGxvYWRpbmdEYXRhOiB0cnVlLFxuICAgICAgICAgICAgaXRlbTogbmV3IExvZ1xuICAgICAgICB9O1xuICAgIH1cblxuICAgIHB1YmxpYyBjb21wb25lbnREaWRNb3VudCgpIHtcbiAgICAgICAgZmV0Y2godGhpcy5wYXRocy5nZXRMaXN0LmNvbmNhdCh0aGlzLnByb3BzLm1hdGNoLnBhcmFtcy5zaG9ydG5hbWUpLCB7XG4gICAgICAgICAgICBjcmVkZW50aWFsczogJ2luY2x1ZGUnXG4gICAgICAgIH0pXG4gICAgICAgICAgICAudGhlbigocmVzcG9uc2UpID0+IHtcbiAgICAgICAgICAgICAgICByZXR1cm4gcmVzcG9uc2UudGV4dCgpO1xuICAgICAgICAgICAgfSlcbiAgICAgICAgICAgIC50aGVuKChkYXRhKSA9PiB7XG4gICAgICAgICAgICAgICAgdGhpcy5zZXRTdGF0ZSh7XG4gICAgICAgICAgICAgICAgICAgIGl0ZW06IEpTT04ucGFyc2UoZGF0YSksXG4gICAgICAgICAgICAgICAgICAgIGxvYWRpbmdEYXRhOiBmYWxzZVxuICAgICAgICAgICAgICAgIH0pO1xuICAgICAgICAgICAgfSk7XG4gICAgfVxuXG4gICAgcHVibGljIHJlbmRlcigpIHtcbiAgICAgICAgcmV0dXJuIHRoaXMuc3RhdGUubG9hZGluZ0RhdGEgPyA8aDE+TG9hZGluZzwvaDE+IDpcbiAgICAgICAgICAgIDxzZWN0aW9uIGNsYXNzTmFtZT1cInJlc3VtZS1zZWN0aW9uXCI+XG4gICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJzdWJoZWFkaW5nXCI+XG4gICAgICAgICAgICAgICAgICAgIHt0aGlzLnN0YXRlLml0ZW0uTmFtZX1cbiAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0ncm93Jz5cbiAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9J2NvbC1tZCc+XG4gICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0ncm93Jz5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0nY29sLW1kJz5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHNwYW4gICBjbGFzc05hbWU9J2ZhcyBmZS1jYWxlbmRhcicvPiBcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAge21vbWVudCh0aGlzLnN0YXRlLml0ZW0uRXZlbnRUaW1lKS5mb3JtYXQoXCJERC1NTS1ZWVlZXCIpfVxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0ncm93Jz5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT0nY29sLW1kJz5cbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHNwYW4+e3RoaXMuc3RhdGUuaXRlbS5NZXNzYWdlc308L3NwYW4+XG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPSdyb3cnPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPSdjb2wtbWQnPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8c3Bhbj57dGhpcy5zdGF0ZS5pdGVtLlN0YWNrVHJhY2V9PC9zcGFuPlxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgICAgIDwvZGl2PlxuICAgICAgICAgICAgPC9zZWN0aW9uPlxuICAgIH1cbn1cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9Mb2cvTG9nRGV0YWlsTGF5b3V0LnRzeCIsImltcG9ydCAqIGFzIFJlYWN0IGZyb20gJ3JlYWN0JztcbmltcG9ydCB7IFJvdXRlQ29tcG9uZW50UHJvcHMgfSBmcm9tICdyZWFjdC1yb3V0ZXInO1xuaW1wb3J0IEl0ZW0gZnJvbSBcIi4uL01vZGVscy9Mb2dcIjtcbmltcG9ydCBMb2FkaW5nVmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9Mb2FkaW5nL0xvYWRpbmdWaWV3XCI7XG5pbXBvcnQgTGlzdFZpZXcgZnJvbSBcIi4uL0NvbXBvbmVudHMvTG9nTGlzdC9Mb2dMaXN0XCI7XG5pbXBvcnQgRW1wdHlMaXN0VmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9FbXB0eUxpc3QvRW1wdHlMaXN0Vmlld1wiO1xuXG5pbnRlcmZhY2UgU3RhdGUge1xuICAgIGxvYWRpbmdEYXRhOiBib29sZWFuLFxuICAgIGl0ZW1zOiBJdGVtW11cbn1cbmludGVyZmFjZSAgUHJvcHMgZXh0ZW5kcyBSb3V0ZUNvbXBvbmVudFByb3BzPGFueT4ge1xufVxuZXhwb3J0IGNsYXNzIExvZ0xheW91dCBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxQcm9wcywgU3RhdGU+IHtcbiAgICBjb25zdHJ1Y3Rvcihwcm9wczogUm91dGVDb21wb25lbnRQcm9wczx7fT4sIHN0YXRlOiBTdGF0ZSkge1xuICAgICAgICBzdXBlcihwcm9wcywgc3RhdGUpO1xuICAgICAgICB0aGlzLnN0YXRlID0ge1xuICAgICAgICAgICAgbG9hZGluZ0RhdGE6IHRydWUsXG4gICAgICAgICAgICBpdGVtczogW11cbiAgICAgICAgfTtcbiAgICB9XG4gICAgcHJpdmF0ZSBwYXRocyA9IHtcbiAgICAgICAgZ2V0TGlzdDogJy9BcGkvTG9nL0xpc3QnXG4gICAgfTtcblxuICAgIHB1YmxpYyBjb21wb25lbnREaWRNb3VudCgpIHtcbiAgICAgICAgZmV0Y2godGhpcy5wYXRocy5nZXRMaXN0LCB7XG4gICAgICAgICAgICBjcmVkZW50aWFsczogJ2luY2x1ZGUnIH0pXG4gICAgICAgICAgICAudGhlbigocmVzcG9uc2UpID0+IHtcbiAgICAgICAgICAgICAgICByZXR1cm4gcmVzcG9uc2UudGV4dCgpO1xuICAgICAgICAgICAgfSlcbiAgICAgICAgICAgIC50aGVuKChkYXRhKSA9PiB7XG4gICAgICAgICAgICAgICAgdGhpcy5zZXRTdGF0ZSh7XG4gICAgICAgICAgICAgICAgICAgIGl0ZW1zOiBKU09OLnBhcnNlKGRhdGEpLFxuICAgICAgICAgICAgICAgICAgICBsb2FkaW5nRGF0YTogZmFsc2VcbiAgICAgICAgICAgICAgICB9KTtcbiAgICAgICAgICAgIH0pO1xuICAgIH1cblxuICAgIHB1YmxpYyByZW5kZXIoKSB7XG4gICAgICAgIGNvbnN0IGhhc0l0ZW1zID0gdGhpcy5zdGF0ZS5pdGVtcy5sZW5ndGggPiAwO1xuXG4gICAgICAgIHJldHVybiA8c2VjdGlvbiBjbGFzc05hbWU9XCJyZXN1bWUtc2VjdGlvblwiPlxuICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJzdWJoZWFkaW5nXCI+XG4gICAgICAgICAgICAgICBMT0dTXG4gICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgIHtcbiAgICAgICAgICAgICAgICB0aGlzLnN0YXRlLmxvYWRpbmdEYXRhID9cbiAgICAgICAgICAgICAgICAgICAgPExvYWRpbmdWaWV3IFRpdGxlPXsnTG9ncyd9Lz4gOlxuICAgICAgICAgICAgICAgICAgICBoYXNJdGVtcyA/XG4gICAgICAgICAgICAgICAgICAgICAgICA8TGlzdFZpZXcgaXRlbXM9IHt0aGlzLnN0YXRlLml0ZW1zfSAvPiA6ICA8RW1wdHlMaXN0VmlldyAgVGl0bGU9e1wiTG9nc1wifSAgLz5cbiAgICAgICAgICAgIH1cbiAgICAgICAgPC9zZWN0aW9uPlxuICAgIH1cbn1cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9Mb2cvTG9nTGF5b3V0LnRzeCIsImV4cG9ydCBkZWZhdWx0IGNsYXNzIENvbmZpZyB7XG4gICAgUnNzMVVybDogc3RyaW5nO1xuICAgIFdlbGNvbWVUZXh0IDogc3RyaW5nO1xuICAgIFJzczJVcmw6IHN0cmluZztcbiAgICAgV2VsY29tZVZpZGVvOnN0cmluZztcbn1cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvTW9kZWxzL0NvbmZpZy50cyIsImV4cG9ydCBkZWZhdWx0IGNsYXNzIExvZ1xue1xuICAgIElkOiBudW1iZXI7XG4gICAgVHlwZTogbnVtYmVyO1xuXG4gICAgTmFtZTogc3RyaW5nO1xuICAgIE1lc3NhZ2VzOiBzdHJpbmc7XG4gICAgU3RhY2tUcmFjZTogc3RyaW5nO1xuICAgIEV2ZW50VGltZTogRGF0ZTtcbn1cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvTW9kZWxzL0xvZy50cyIsImV4cG9ydCBkZWZhdWx0IGNsYXNzIFBhZ2Uge1xuICAgIElkOiBudW1iZXI7XG4gICAgTGlua0lkOiBudW1iZXI7XG4gICAgU2hvcnROYW1lOiBzdHJpbmc7XG4gICAgRnVsbE5hbWU6IHN0cmluZztcbiAgICBDb250ZW50OiBzdHJpbmc7XG4gICAgSWNvbk5hbWU6IHN0cmluZztcbiAgICBDYXRlZ29yeTogc3RyaW5nO1xuICAgIFB1Ymxpc2hlZDogRGF0ZTtcbiAgICBJbWFnZVVybDogc3RyaW5nO1xufVxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9Nb2RlbHMvUGFnZS50cyIsIid1c2Ugc3RyaWN0JztcblxuaW1wb3J0ICogYXMgUmVhY3QgZnJvbSAncmVhY3QnO1xuaW1wb3J0IHtSb3V0ZUNvbXBvbmVudFByb3BzfSBmcm9tICdyZWFjdC1yb3V0ZXInO1xuaW1wb3J0IEl0ZW0gZnJvbSBcIi4uL01vZGVscy9QYWdlXCI7XG5pbXBvcnQgTG9hZGluZ1ZpZXcgZnJvbSBcIi4uL0NvbXBvbmVudHMvTG9hZGluZy9Mb2FkaW5nVmlld1wiO1xuaW1wb3J0IExpc3RWaWV3IGZyb20gXCIuLi9Db21wb25lbnRzL1BhZ2VMaXN0L0xpc3RWaWV3XCI7XG5pbXBvcnQgRW1wdHlMaXN0VmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9FbXB0eUxpc3QvRW1wdHlMaXN0Vmlld1wiO1xuXG5pbnRlcmZhY2UgIFByb3BzIGV4dGVuZHMgUm91dGVDb21wb25lbnRQcm9wczxhbnk+e1xuICAgIFBhcmFtczogc3RyaW5nO1xufVxuXG5pbnRlcmZhY2UgSVBvc3RTdGF0ZSB7XG4gICAgbG9hZGluZ0RhdGE6IGJvb2xlYW4sXG4gICAgaXRlbXM6IEl0ZW1bXVxufVxuXG5leHBvcnQgY2xhc3MgUGFnZUxheW91dCBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxQcm9wcywgSVBvc3RTdGF0ZT4ge1xuICAgIGNvbnN0cnVjdG9yKHByb3BzOiBQcm9wcywgc3RhdGU6IElQb3N0U3RhdGUpIHtcbiAgICAgICAgc3VwZXIocHJvcHMsIHN0YXRlKTtcbiAgICAgICAgdGhpcy5zdGF0ZSA9IHtcbiAgICAgICAgICAgIGxvYWRpbmdEYXRhOiB0cnVlLFxuICAgICAgICAgICAgaXRlbXM6IFtdXG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgcHJpdmF0ZSBwYXRocyA9IHtcbiAgICAgICAgQWxsOiAnL0FwaS9QYWdlL1BhZ2VzJyxcbiAgICB9O1xuXG4gICAgcHVibGljIGNvbXBvbmVudERpZE1vdW50KCkge1xuICAgICAgICBmZXRjaCh0aGlzLnBhdGhzLkFsbCwge1xuICAgICAgICAgICAgY3JlZGVudGlhbHM6ICdpbmNsdWRlJ1xuICAgICAgICB9KVxuICAgICAgICAgICAgLnRoZW4oKHJlc3BvbnNlKSA9PiB7XG4gICAgICAgICAgICAgICAgcmV0dXJuIHJlc3BvbnNlLnRleHQoKTtcbiAgICAgICAgICAgIH0pXG4gICAgICAgICAgICAudGhlbigoZGF0YSkgPT4ge1xuICAgICAgICAgICAgICAgIHRoaXMuc2V0U3RhdGUoe1xuICAgICAgICAgICAgICAgICAgICBpdGVtczogSlNPTi5wYXJzZShkYXRhKSxcbiAgICAgICAgICAgICAgICAgICAgbG9hZGluZ0RhdGE6IGZhbHNlXG4gICAgICAgICAgICAgICAgfSk7XG4gICAgICAgICAgICB9KTtcbiAgICB9XG5cbiAgICBwdWJsaWMgcmVuZGVyKCkge1xuICAgICAgICBjb25zdCBoYXNQcm9qZWN0cyA9IHRoaXMuc3RhdGUuaXRlbXMubGVuZ3RoID4gMDtcblxuICAgICAgICByZXR1cm4gKFxuICAgICAgICAgICAgPHNlY3Rpb24gY2xhc3NOYW1lPVwicmVzdW1lLXNlY3Rpb25cIj5cbiAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cInN1YmhlYWRpbmdcIj5cbiAgICAgICAgICAgICAgICAgICAgRGV2IFByb2plY3RzXG4gICAgICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICAgICAgICAge1xuICAgICAgICAgICAgICAgICAgICB0aGlzLnN0YXRlLmxvYWRpbmdEYXRhID9cbiAgICAgICAgICAgICAgICAgICAgPExvYWRpbmdWaWV3IFRpdGxlPXtcIlBvc3RzXCJ9Lz4gOlxuICAgICAgICAgICAgICAgICAgICAgaGFzUHJvamVjdHMgP1xuICAgICAgICAgICAgICAgICAgICA8TGlzdFZpZXcgaXRlbXM9e3RoaXMuc3RhdGUuaXRlbXN9Lz4gOiAgPEVtcHR5TGlzdFZpZXcgVGl0bGU9e1wiUG9zdHNcIn0vPlxuICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgIDwvc2VjdGlvbj5cbiAgICAgICAgKVxuICAgICAgICAgICAgICAgICAgICBcbiAgICAgICAgICAgXG4gICAgfVxufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL1BhZ2UvUGFnZUxheW91dC50c3giLCIndXNlIHN0cmljdCc7XG5cbmltcG9ydCAqIGFzIFJlYWN0IGZyb20gJ3JlYWN0JztcbmltcG9ydCB7Um91dGVDb21wb25lbnRQcm9wc30gZnJvbSAncmVhY3Qtcm91dGVyJztcbmltcG9ydCBJdGVtIGZyb20gXCIuLi9Nb2RlbHMvUGFnZVwiO1xuaW1wb3J0IExvYWRpbmdWaWV3IGZyb20gXCIuLi9Db21wb25lbnRzL0xvYWRpbmcvTG9hZGluZ1ZpZXdcIjtcbmltcG9ydCBEZXRhaWwgZnJvbSAnLi9Qb3N0RGV0YWlsVmlldyc7XG5cbmludGVyZmFjZSAgUHJvcHMgZXh0ZW5kcyBSb3V0ZUNvbXBvbmVudFByb3BzPGFueT57XG4gICAgc2hvcnRuYW1lOiBzdHJpbmdcbn1cblxuaW50ZXJmYWNlIElQb3N0RGV0YWlsU3RhdGUge1xuICAgIGxvYWRpbmdEYXRhOiBib29sZWFuLFxuICAgIEl0ZW06IEl0ZW0sXG59XG5cbmV4cG9ydCBjbGFzcyBQb3N0RGV0YWlsTGF5b3V0IGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PFByb3BzLCBJUG9zdERldGFpbFN0YXRlPiB7XG4gICAgY29uc3RydWN0b3IocHJvcHM6IFByb3BzKSB7XG4gICAgICAgIHN1cGVyKHByb3BzKTtcbiAgICAgICAgdGhpcy5zdGF0ZSA9IHtcbiAgICAgICAgICAgIGxvYWRpbmdEYXRhOiB0cnVlLFxuICAgICAgICAgICAgSXRlbTogbmV3IEl0ZW0sXG4gICAgICAgIH07XG4gICAgICAgIGNvbnNvbGUubG9nKHRoaXMuc3RhdGUpO1xuICAgIH1cblxuICAgIHByaXZhdGUgcGF0aHMgPSB7XG4gICAgICAgIGdldExpc3Q6ICcvQXBpL1BhZ2UvRGV0YWlscy8nXG4gICAgfTtcblxuICAgIHB1YmxpYyBjb21wb25lbnREaWRNb3VudCgpIHtcbiAgICAgICAgbGV0IHBhdGggPSB0aGlzLnBhdGhzLmdldExpc3QuY29uY2F0KHRoaXMucHJvcHMubWF0Y2gucGFyYW1zLnNob3J0bmFtZSk7XG4gICAgICAgIGNvbnNvbGUubG9nKHBhdGgpO1xuXG4gICAgICAgIGZldGNoKHBhdGgsIHtcbiAgICAgICAgICAgIGNyZWRlbnRpYWxzOiAnaW5jbHVkZSdcbiAgICAgICAgfSlcbiAgICAgICAgICAgIC50aGVuKChyZXNwb25zZSkgPT4ge1xuICAgICAgICAgICAgICAgIHJldHVybiByZXNwb25zZS50ZXh0KCk7XG4gICAgICAgICAgICB9KVxuICAgICAgICAgICAgLnRoZW4oKGRhdGEpID0+IHtcbiAgICAgICAgICAgICAgICB0aGlzLnNldFN0YXRlKHtcbiAgICAgICAgICAgICAgICAgICAgSXRlbTogSlNPTi5wYXJzZShkYXRhKSxcbiAgICAgICAgICAgICAgICAgICAgbG9hZGluZ0RhdGE6IGZhbHNlXG4gICAgICAgICAgICAgICAgfSk7XG4gICAgICAgICAgICB9KTtcbiAgICB9XG5cbiAgICBwdWJsaWMgcmVuZGVyKCkge1xuICAgICAgICByZXR1cm4gKFxuICAgICAgICAgICAgPHNlY3Rpb24gY2xhc3NOYW1lPVwicmVzdW1lLXNlY3Rpb25cIj5cbiAgICAgICAgICAgICAgICB7XG4gICAgICAgICAgICAgICAgICAgIHRoaXMuc3RhdGUubG9hZGluZ0RhdGEgP1xuICAgICAgICAgICAgICAgICAgICAgICAgPExvYWRpbmdWaWV3IFRpdGxlPVwiUG9zdFwiLz4gOiBcbiAgICAgICAgICAgICAgICAgICAgICAgIDxEZXRhaWwgICBJdGVtPXt0aGlzLnN0YXRlLkl0ZW19IC8+ICAgICAgICAgICAgICAgICAgICAgXG4gICAgICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgICAgICA8L3NlY3Rpb24+XG4gICAgICAgICk7XG4gICAgfVxufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL1BhZ2UvUG9zdERldGFpbExheW91dC50c3giLCIndXNlIHN0cmljdCc7XG5cbmltcG9ydCBJdGVtIGZyb20gXCIuLi9Nb2RlbHMvUGFnZVwiO1xuaW1wb3J0ICogYXMgUmVhY3QgZnJvbSBcInJlYWN0XCI7XG5cbmludGVyZmFjZSBQcm9wcyB7XG4gICAgSXRlbTogSXRlbVxufVxuXG5leHBvcnQgIGRlZmF1bHQgY2xhc3MgUG9zdERldGFpbFZpZXcgZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8UHJvcHMsIGFueT5cbntcbiAgICBwdWJsaWMgcmVuZGVyKCkge1xuICAgICAgICBsZXQgSXRlbT10aGlzLnByb3BzLkl0ZW07XG4gICAgICAgIHJldHVybiAoXG4gICAgICAgICAgICA8ZGl2PlxuICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPVwic3ViaGVhZGluZ1wiPlxuICAgICAgICAgICAgICAgICAgICB7SXRlbS5GdWxsTmFtZX1cbiAgICAgICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgICAgICAgICA8cD4ge0l0ZW0uQ29udGVudH0gPC9wPlxuICAgICAgICAgICAgICAgIDxwPiB7SXRlbS5DYXRlZ29yeX0gPC9wPlxuICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICk7XG4gICAgfTtcbn1cbiAgICBcblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvUGFnZS9Qb3N0RGV0YWlsVmlldy50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5pbXBvcnQge1JvdXRlQ29tcG9uZW50UHJvcHMsIFJvdXRlUHJvcHN9IGZyb20gJ3JlYWN0LXJvdXRlcic7XG5pbXBvcnQgSXRlbSBmcm9tIFwiLi4vTW9kZWxzL1BhZ2VcIjtcbmltcG9ydCBFbXB0eUxpc3RWaWV3IGZyb20gXCIuLi9Db21wb25lbnRzL0VtcHR5TGlzdC9FbXB0eUxpc3RWaWV3XCI7XG5pbXBvcnQgTGlzdFZpZXcgZnJvbSBcIi4uL0NvbXBvbmVudHMvUGFnZUxpc3QvTGlzdFZpZXdcIjtcbmltcG9ydCBMb2FkaW5nVmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9Mb2FkaW5nL0xvYWRpbmdWaWV3XCI7XG5cbmludGVyZmFjZSAgUHJvcHMgZXh0ZW5kcyBSb3V0ZUNvbXBvbmVudFByb3BzPGFueT57XG4gICAgc2hvcnRuYW1lOiBzdHJpbmc7XG59XG5cblxuaW50ZXJmYWNlIElQb3N0U3RhdGUge1xuICAgIGxvYWRpbmdEYXRhOiBib29sZWFuLFxuICAgIGl0ZW1zOiBJdGVtW11cbn1cblxuZXhwb3J0IGNsYXNzIFBvc3RMYXlvdXQgZXh0ZW5kcyBSZWFjdC5Db21wb25lbnQ8UHJvcHMsIElQb3N0U3RhdGU+IHtcbiAgICBjb25zdHJ1Y3Rvcihwcm9wczpQcm9wcywgc3RhdGU6IElQb3N0U3RhdGUpIHtcbiAgICAgICAgc3VwZXIocHJvcHMsIHN0YXRlKTtcbiAgICAgICAgdGhpcy5zdGF0ZSA9IHtcbiAgICAgICAgICAgIGxvYWRpbmdEYXRhOiB0cnVlLFxuICAgICAgICAgICAgaXRlbXM6IFtdXG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgcHJpdmF0ZSBwYXRocyA9IHtcbiAgICAgICAgZ2V0TGlzdDogJy9BcGkvUGFnZS9Qb3N0cydcbiAgICB9O1xuXG4gICAgcHVibGljIGNvbXBvbmVudERpZE1vdW50KCkge1xuICAgICAgICBmZXRjaCh0aGlzLnBhdGhzLmdldExpc3QsIHtcbiAgICAgICAgICAgIGNyZWRlbnRpYWxzOiAnaW5jbHVkZSdcbiAgICAgICAgfSlcbiAgICAgICAgICAgIC50aGVuKChyZXNwb25zZSkgPT4ge1xuICAgICAgICAgICAgICAgIHJldHVybiByZXNwb25zZS50ZXh0KCk7XG4gICAgICAgICAgICB9KVxuICAgICAgICAgICAgLnRoZW4oKGRhdGEpID0+IHtcbiAgICAgICAgICAgICAgICB0aGlzLnNldFN0YXRlKHtcbiAgICAgICAgICAgICAgICAgICAgaXRlbXM6IEpTT04ucGFyc2UoZGF0YSksXG4gICAgICAgICAgICAgICAgICAgIGxvYWRpbmdEYXRhOiBmYWxzZVxuICAgICAgICAgICAgICAgIH0pO1xuICAgICAgICAgICAgfSk7XG4gICAgfVxuXG4gICAgcHVibGljIHJlbmRlcigpIHtcbiAgICAgICAgY29uc3QgaGFzUHJvamVjdHMgPSB0aGlzLnN0YXRlLml0ZW1zLmxlbmd0aCA+IDA7XG5cbiAgICAgICAgcmV0dXJuIChcbiAgICAgICAgICAgIDxzZWN0aW9uIGNsYXNzTmFtZT1cInJlc3VtZS1zZWN0aW9uXCI+XG4gICAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPVwic3ViaGVhZGluZ1wiPlxuICAgICAgICAgICAgICAgICAgICAgIE5ld3NcbiAgICAgICAgICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICAgICAgICAge1xuICAgICAgICAgICAgICAgICAgICB0aGlzLnN0YXRlLmxvYWRpbmdEYXRhID8gICAgICAgICAgICAgICAgICBcbiAgICAgICAgICAgICAgICAgICAgICAgIDxMb2FkaW5nVmlldyBUaXRsZT17XCJOZXdzXCJ9Lz4gOlxuICAgICAgICAgICAgICAgICAgICBoYXNQcm9qZWN0cyA/IFxuICAgICAgICAgICAgICAgICAgICAgICAgPExpc3RWaWV3IGl0ZW1zPXt0aGlzLnN0YXRlLml0ZW1zfS8+IDogPEVtcHR5TGlzdFZpZXcgVGl0bGU9e1wiTmV3c1wifS8+XG4gICAgICAgICAgICAgICAgfVxuICAgICAgICAgICAgPC9zZWN0aW9uPlxuICAgICAgICApO1xuICAgIH1cbn1cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9QYWdlL1Bvc3RMYXlvdXQudHN4IiwiaW1wb3J0ICogYXMgUmVhY3QgZnJvbSAncmVhY3QnO1xuaW1wb3J0IHsgUm91dGVDb21wb25lbnRQcm9wcyB9IGZyb20gJ3JlYWN0LXJvdXRlcic7XG5cbmludGVyZmFjZSAgUHJvcHMgZXh0ZW5kcyBSb3V0ZUNvbXBvbmVudFByb3BzPGFueT57XG4gICAgc2hvcnRuYW1lOiBzdHJpbmdcblxufVxuZXhwb3J0IGNsYXNzIFJTU0xheW91dCBleHRlbmRzIFJlYWN0LkNvbXBvbmVudDxQcm9wcywge30+IHtcbiAgICBjb25zdHJ1Y3Rvcihwcm9wczogUHJvcHMpIHtcbiAgICAgICAgc3VwZXIocHJvcHMpO1xuICAgIH1cblxuXG4gICAgcHVibGljIHJlbmRlcigpIHtcbiAgICAgICAgcmV0dXJuIDxzZWN0aW9uIGNsYXNzTmFtZT1cInJlc3VtZS1zZWN0aW9uXCI+XG4gICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cInN1YmhlYWRpbmdcIj5cbiAgICAgICAgICAgICAgIHt0aGlzLnByb3BzLm1hdGNoLnBhcmFtcy5zaG9ydG5hbWV9XG4gICAgICAgICAgICA8L2Rpdj5cbiAgICAgICAgPC9zZWN0aW9uPjtcbiAgICB9XG59XG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvUlNTL0xheW91dC50c3giLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5pbXBvcnQge1JvdXRlfSBmcm9tICdyZWFjdC1yb3V0ZXItZG9tJztcbmltcG9ydCB7TGF5b3V0fSBmcm9tICcuL0xheW91dC9MYXlvdXQnO1xuaW1wb3J0IHtIb21lTGF5b3V0fSBmcm9tICcuL0hvbWUvSG9tZUxheW91dCc7XG5cbmltcG9ydCB7UG9zdExheW91dH0gZnJvbSBcIi4vUGFnZS9Qb3N0TGF5b3V0XCI7XG5pbXBvcnQge1BhZ2VMYXlvdXR9IGZyb20gXCIuL1BhZ2UvUGFnZUxheW91dFwiO1xuaW1wb3J0IHtSU1NMYXlvdXR9IGZyb20gXCIuL1JTUy9MYXlvdXRcIjtcblxuaW1wb3J0IHtQb3N0RGV0YWlsTGF5b3V0fSBmcm9tIFwiLi9QYWdlL1Bvc3REZXRhaWxMYXlvdXRcIjtcblxuXG5pbXBvcnQge0xvZ0xheW91dH0gZnJvbSAnLi9Mb2cvTG9nTGF5b3V0JztcbmltcG9ydCB7TG9nRGV0YWlsTGF5b3V0fSBmcm9tICcuL0xvZy9Mb2dEZXRhaWxMYXlvdXQnO1xuXG5pbXBvcnQge1ZpZGVvTGF5b3V0fSBmcm9tICcuL1ZpZGVvL1ZpZGVvTGF5b3V0JztcblxuXG5pbXBvcnQge0FsYnVtTGF5b3V0fSBmcm9tIFwiLi9BbGJ1bS9BbGJ1bUxheW91dFwiO1xuXG5leHBvcnQgY29uc3Qgcm91dGVzID1cbiAgICA8TGF5b3V0PlxuICAgICAgICA8Um91dGUgZXhhY3QgcGF0aD0nLycgY29tcG9uZW50PXtIb21lTGF5b3V0fS8+XG4gICAgICAgIDxSb3V0ZSBwYXRoPScvSW5kZXgnIGNvbXBvbmVudD17SG9tZUxheW91dH0vPlxuICAgICAgICA8Um91dGUgcGF0aD0nL1Bob3RvcycgY29tcG9uZW50PXtBbGJ1bUxheW91dH0vPlxuICAgICAgICA8Um91dGUgcGF0aD0nL0FsYnVtcycgY29tcG9uZW50PXtBbGJ1bUxheW91dH0vPlxuICAgICAgICA8Um91dGUgcGF0aD0nL1ZpZGVvcycgY29tcG9uZW50PXtWaWRlb0xheW91dH0vPlxuICAgICAgICA8Um91dGUgcGF0aD0nL0xvZ3MnIGNvbXBvbmVudD17TG9nTGF5b3V0fS8+XG4gICAgICAgIDxSb3V0ZSBleGFjdCBwYXRoPScvUlNTJyBjb21wb25lbnQ9e1JTU0xheW91dH0vPlxuICAgICAgICA8Um91dGUgZXhhY3QgcGF0aD0nL1JTUy86c2hvcnRuYW1lJyBjb21wb25lbnQ9e1JTU0xheW91dH0vPlxuXG4gICAgICAgICAgICA8Um91dGUgcGF0aD0nL0xvZy86c2hvcnRuYW1lJyBjb21wb25lbnQ9e0xvZ0RldGFpbExheW91dH0vPlxuXG4gICAgICAgIDxSb3V0ZSBwYXRoPScvQWxidW0vOnNob3J0bmFtZScgY29tcG9uZW50PXtBbGJ1bUxheW91dH0vPlxuXG4gICAgICAgIDxSb3V0ZSBleGFjdCBwYXRoPScvUGFnZXMnIGNvbXBvbmVudD17UGFnZUxheW91dH0vPlxuXG4gICAgICAgICAgICA8Um91dGUgcGF0aD0nL1BhZ2UvOnNob3J0bmFtZScgY29tcG9uZW50PXtQb3N0RGV0YWlsTGF5b3V0fS8+XG5cbiAgICAgICAgPFJvdXRlIHBhdGg9Jy9Qb3N0cycgY29tcG9uZW50PXtQb3N0TGF5b3V0fS8+XG4gICAgICAgIDxSb3V0ZSBwYXRoPScvUG9zdC86c2hvcnRuYW1lJyBjb21wb25lbnQ9e1Bvc3REZXRhaWxMYXlvdXR9Lz5cblxuXG4gICAgICAgIHsvKlRPRE86IExvZ3MgLyBQb3N0cyBhbmQgUGFnZXMgLyBEZXRhaWxzICovfVxuICAgIDwvTGF5b3V0PjtcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9Sb3V0ZXMudHN4IiwiLy8gcmVtb3ZlZCBieSBleHRyYWN0LXRleHQtd2VicGFjay1wbHVnaW5cblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL0NsaWVudEFwcC9TdHlsZXMvcmVzdW1lLnNjc3Ncbi8vIG1vZHVsZSBpZCA9IC4vQ2xpZW50QXBwL1N0eWxlcy9yZXN1bWUuc2Nzc1xuLy8gbW9kdWxlIGNodW5rcyA9IDEiLCJpbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5pbXBvcnQgeyBSb3V0ZUNvbXBvbmVudFByb3BzLCBSb3V0ZVByb3BzIH0gZnJvbSAncmVhY3Qtcm91dGVyJztcbmltcG9ydCBJdGVtIGZyb20gXCIuLi9Nb2RlbHMvTWVudUl0ZW1cIjtcbmltcG9ydCBMb2FkaW5nVmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9Mb2FkaW5nL0xvYWRpbmdWaWV3XCI7XG5pbXBvcnQgRW1wdHlMaXN0VmlldyBmcm9tIFwiLi4vQ29tcG9uZW50cy9FbXB0eUxpc3QvRW1wdHlMaXN0Vmlld1wiO1xuaW1wb3J0IExpc3RWaWV3IGZyb20gXCIuLi9Db21wb25lbnRzL1ZpZGVvTGlzdC9MaXN0Vmlld1wiO1xuXG5pbnRlcmZhY2UgIFByb3BzIGV4dGVuZHMgUm91dGVDb21wb25lbnRQcm9wczxhbnk+e1xuICAgIFxufVxuaW50ZXJmYWNlIExpc3RDb250YWluZXJTdGF0ZSB7XG4gICAgbG9hZGluZ0RhdGE6IGJvb2xlYW4sXG4gICAgaXRlbXM6IEl0ZW1bXVxufVxuZXhwb3J0IGNsYXNzIFZpZGVvTGF5b3V0IGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PFByb3BzLCBMaXN0Q29udGFpbmVyU3RhdGU+IHtcbiAgICBjb25zdHJ1Y3Rvcihwcm9wczogUHJvcHMsIHN0YXRlOiBMaXN0Q29udGFpbmVyU3RhdGUpe1xuICAgICAgICBzdXBlcihwcm9wcywgc3RhdGUpO1xuICAgICAgICB0aGlzLnN0YXRlID0ge1xuICAgICAgICAgICAgbG9hZGluZ0RhdGE6IHRydWUsXG4gICAgICAgICAgICBpdGVtczogW11cbiAgICAgICAgfTtcbiAgICB9XG4gICAgcHJpdmF0ZSBwYXRocyA9IHtcbiAgICAgICAgZ2V0TGlzdDogJy9BcGkvVmlkZW8vJ1xuICAgIH07XG5cbiAgICBwdWJsaWMgY29tcG9uZW50RGlkTW91bnQoKSB7XG4gICAgICAgIGZldGNoKHRoaXMucGF0aHMuZ2V0TGlzdCwge1xuICAgICAgICAgICAgY3JlZGVudGlhbHM6ICdpbmNsdWRlJyB9KVxuICAgICAgICAgICAgLnRoZW4oKHJlc3BvbnNlKSA9PiB7XG4gICAgICAgICAgICAgICAgcmV0dXJuIHJlc3BvbnNlLnRleHQoKTtcbiAgICAgICAgICAgIH0pXG4gICAgICAgICAgICAudGhlbigoZGF0YSkgPT4ge1xuICAgICAgICAgICAgICAgIHRoaXMuc2V0U3RhdGUoe1xuICAgICAgICAgICAgICAgICAgICBpdGVtczogSlNPTi5wYXJzZShkYXRhKSxcbiAgICAgICAgICAgICAgICAgICAgbG9hZGluZ0RhdGE6IGZhbHNlXG4gICAgICAgICAgICAgICAgfSk7XG4gICAgICAgICAgICB9KTtcbiAgICB9XG4gICAgXG4gICAgcHVibGljIHJlbmRlcigpIHtcbiAgICAgICAgY29uc3QgaGFzUHJvamVjdHMgPSB0aGlzLnN0YXRlLml0ZW1zLmxlbmd0aCA+IDA7XG5cbiAgICAgICAgcmV0dXJuIDxzZWN0aW9uIGNsYXNzTmFtZT1cInJlc3VtZS1zZWN0aW9uXCI+XG4gICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cInN1YmhlYWRpbmdcIj5cbiAgICAgICAgICAgICAgIFZJREVPU1xuICAgICAgICAgICAgPC9kaXY+XG4gICAgICAgICAgICB7XG4gICAgICAgICAgICAgICAgdGhpcy5zdGF0ZS5sb2FkaW5nRGF0YSA/XG4gICAgICAgICAgICAgICAgICAgIDxMb2FkaW5nVmlldyBUaXRsZT17XCJWaWRlb3NcIn0vPiA6XG4gICAgICAgICAgICAgICAgICAgIGhhc1Byb2plY3RzID9cbiAgICAgICAgICAgICAgICAgICAgICAgIDxMaXN0VmlldyBpdGVtcz17dGhpcy5zdGF0ZS5pdGVtc30vPiA6ICA8RW1wdHlMaXN0VmlldyBUaXRsZT17XCJWaWRlb3NcIn0vPlxuICAgICAgICAgICAgfVxuICAgICAgICA8L3NlY3Rpb24+O1xuICAgIH1cbn1cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9WaWRlby9WaWRlb0xheW91dC50c3giLCJpbXBvcnQgJ2Jvb3RzdHJhcCc7XG5pbXBvcnQgKiBhcyBSZWFjdCBmcm9tICdyZWFjdCc7XG5pbXBvcnQgKiBhcyBSZWFjdERPTSBmcm9tICdyZWFjdC1kb20nO1xuaW1wb3J0IHsgQXBwQ29udGFpbmVyIH0gZnJvbSAncmVhY3QtaG90LWxvYWRlcic7XG5pbXBvcnQgeyBCcm93c2VyUm91dGVyIH0gZnJvbSAncmVhY3Qtcm91dGVyLWRvbSc7XG5pbXBvcnQgKiBhcyBSb3V0ZXNNb2R1bGUgZnJvbSAnLi9Sb3V0ZXMnO1xuXG5sZXQgcm91dGVzID0gUm91dGVzTW9kdWxlLnJvdXRlcztcblxuZnVuY3Rpb24gcmVuZGVyQXBwKCkge1xuICAgIC8vIFRoaXMgY29kZSBzdGFydHMgdXAgdGhlIFJlYWN0IGFwcCB3aGVuIGl0IHJ1bnMgaW4gYSBicm93c2VyLiBJdCBzZXRzIHVwIHRoZSByb3V0aW5nXG4gICAgLy8gY29uZmlndXJhdGlvbiBhbmQgaW5qZWN0cyB0aGUgYXBwIGludG8gYSBET00gZWxlbWVudC5cbiAgICBjb25zdCBiYXNlVXJsID0gZG9jdW1lbnQuZ2V0RWxlbWVudHNCeVRhZ05hbWUoJ2Jhc2UnKVswXS5nZXRBdHRyaWJ1dGUoJ2hyZWYnKSE7XG4gICAgUmVhY3RET00ucmVuZGVyKFxuICAgICAgICA8QXBwQ29udGFpbmVyPlxuICAgICAgICAgICAgPEJyb3dzZXJSb3V0ZXIgY2hpbGRyZW49eyByb3V0ZXMgfSBiYXNlbmFtZT17IGJhc2VVcmwgfSAvPlxuICAgICAgICA8L0FwcENvbnRhaW5lcj4sXG4gICAgICAgIGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdyZWFjdC1hcHAnKVxuICAgICk7XG59XG5yZW5kZXJBcHAoKTtcblxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2Jvb3QudHN4Il0sInNvdXJjZVJvb3QiOiIifQ==