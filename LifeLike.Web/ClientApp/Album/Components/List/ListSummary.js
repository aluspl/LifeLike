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
var LogListSummary = (function (_super) {
    __extends(LogListSummary, _super);
    function LogListSummary() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    LogListSummary.prototype.render = function () {
        return React.createElement("div", { className: 'row' },
            React.createElement("div", { className: 'ProjectsList-summary col-md-12' },
                React.createElement("div", { className: 'row' },
                    React.createElement("div", { className: 'col-md-12' },
                        React.createElement("p", null,
                            "Number of projects: ",
                            React.createElement("strong", null, this.props.items.length))))));
    };
    return LogListSummary;
}(React.Component));
export default LogListSummary;
//# sourceMappingURL=ListSummary.js.map