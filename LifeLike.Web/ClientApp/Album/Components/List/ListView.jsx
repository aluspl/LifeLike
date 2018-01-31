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
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
require("./List.scss");
require("../../../Shared/Styles/helpers.scss");
var ListItem_1 = require("./ListItem");
var ListView = (function (_super) {
    __extends(ListView, _super);
    function ListView() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListView.prototype.render = function () {
        return <section className='ProjectsList row'>
            <div className='col-md-12'>
                {this.props.items.map(function (item) {
            return <ListItem_1.default key={item.Id} item={item}/>;
        })}
            </div>
        </section>;
    };
    return ListView;
}(React.Component));
exports.default = ListView;
