"use strict";
exports.__esModule = true;
var ReactDOM = require("react-dom");
var React = require("react");
require("../Shared/Styles/helpers.scss");
var ListContainer_1 = require("./Components/ListContainer");
ReactDOM.render(React.createElement(ListContainer_1["default"], null), document.getElementById('react-root'));
if (module.hot) {
    module.hot.accept();
}