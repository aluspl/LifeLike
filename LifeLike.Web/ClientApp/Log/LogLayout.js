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
import LogContainer from './Components/ListContainer';
var LogLayout = (function (_super) {
    __extends(LogLayout, _super);
    function LogLayout() {
        var _this = _super.call(this) || this;
        _this.state = { currentCount: 0 };
        return _this;
    }
    LogLayout.prototype.render = function () {
        var contents = React.createElement(LogContainer, null);
        return React.createElement("div", null,
            React.createElement("h1", null, "Logs"),
            contents);
    };
    return LogLayout;
}(React.Component));
export { LogLayout };
//# sourceMappingURL=LogLayout.js.map