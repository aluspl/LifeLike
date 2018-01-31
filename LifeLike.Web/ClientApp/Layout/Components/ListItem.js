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
import * as React from 'react';
import { NavLink } from "react-router-dom";
var ListItem = (function (_super) {
    __extends(ListItem, _super);
    function ListItem() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListItem.prototype.render = function () {
        return (React.createElement("li", null,
            React.createElement(NavLink, { to: this.props.item.Controller, exact: true, activeClassName: 'active' },
                React.createElement("span", { className: 'glyphicon glyphicon-name${this.props.item.IconName}' }, this.props.item.Name))));
    };
    return ListItem;
}(React.Component));
export default ListItem;
//# sourceMappingURL=ListItem.js.map