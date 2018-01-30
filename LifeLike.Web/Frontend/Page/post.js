"use strict";
exports.__esModule = true;
var ReactDOM = require("react-dom");
var React = require("react");
require("../Shared/Styles/helpers.scss");
var PostContainer_1 = require("./Components/PostContainer");
ReactDOM.render(React.createElement(PostContainer_1["default"], null), document.getElementById('react-root'));
if (module.hot) {
    module.hot.accept();
}
