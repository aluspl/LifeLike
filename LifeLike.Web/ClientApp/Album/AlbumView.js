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
import ListContainer from './Components/ListContainer';
var AlbumLayout = (function (_super) {
    __extends(AlbumLayout, _super);
    function AlbumLayout() {
        var _this = _super.call(this) || this;
        _this.state = { currentCount: 0 };
        return _this;
    }
    AlbumLayout.prototype.render = function () {
        var contents = React.createElement(ListContainer, null);
        return React.createElement("div", null,
            React.createElement("h1", null, "Albums"),
            contents);
    };
    return AlbumLayout;
}(React.Component));
export { AlbumLayout };
//# sourceMappingURL=AlbumView.js.map