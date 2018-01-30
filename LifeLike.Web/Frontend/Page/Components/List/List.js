"use strict";
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
exports.__esModule = true;
var React = require("react");
require("./List.scss");
require("../../../Shared/Styles/helpers.scss");
var ListItem_1 = require("./ListItem");
var List = (function (_super) {
    __extends(List, _super);
    function List() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    List.prototype.render = function () {
        return React.createElement("section", { className: 'ProjectsList row' },
            React.createElement("div", { className: 'col-md-12' }, this.props.items.map(function (item) {
                return React.createElement(ListItem_1["default"], { key: item.Id, item: item });
            })));
    };
    return List;
}(React.Component));
exports["default"] = List;
