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
var HomeLayout = (function (_super) {
    __extends(HomeLayout, _super);
    function HomeLayout() {
        var _this = _super.call(this) || this;
        _this.state = { currentCount: 0 };
        return _this;
    }
    HomeLayout.prototype.render = function () {
        return React.createElement("div", null, "Home");
    };
    return HomeLayout;
}(React.Component));
export { HomeLayout };
//# sourceMappingURL=HomeLayout.js.map