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
import './style.scss';
var LoadingView = (function (_super) {
    __extends(LoadingView, _super);
    function LoadingView() {
        var _this = _super.call(this) || this;
        _this.state = {
            Title: "Data"
        };
        return _this;
    }
    LoadingView.prototype.render = function () {
        return (React.createElement("section", { className: 'EmptyListWarning' },
            React.createElement("section", { className: 'EmptyListWarning-textContainer' },
                React.createElement("p", { className: 'text-center' },
                    "Loading ",
                    this.state.Title,
                    "... "))));
    };
    return LoadingView;
}(React.Component));
export default LoadingView;
//# sourceMappingURL=LoadingView.js.map