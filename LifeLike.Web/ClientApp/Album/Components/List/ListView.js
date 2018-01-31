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
import './List.scss';
import '../../../Shared/Styles/helpers.scss';
import ListItem from './ListItem';
var ListView = (function (_super) {
    __extends(ListView, _super);
    function ListView() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ListView.prototype.render = function () {
        return React.createElement("section", { className: 'ProjectsList row' },
            React.createElement("div", { className: 'col-md-12' }, this.props.items.map(function (item) {
                return React.createElement(ListItem, { key: item.Id, item: item });
            })));
    };
    return ListView;
}(React.Component));
export default ListView;
//# sourceMappingURL=ListView.js.map