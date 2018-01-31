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
import PostContainer from './Components/PostContainer';
var PostLayout = (function (_super) {
    __extends(PostLayout, _super);
    function PostLayout() {
        return _super.call(this) || this;
    }
    PostLayout.prototype.render = function () {
        var contents = React.createElement(PostContainer, null);
        return React.createElement("div", null,
            React.createElement("h1", null, "Logs"),
            contents);
    };
    return PostLayout;
}(React.Component));
export { PostLayout };
//# sourceMappingURL=PostLayout.js.map