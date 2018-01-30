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
exports.__esModule = true;
var React = require("react");
var ListView_1 = require("./List/ListView");
var EmptyListView_1 = require("../../Shared/Components/EmptyListView/EmptyListView");
var LoadingView_1 = require("../../Shared/Components/LoadingView/LoadingView");
var ListContainer = (function (_super) {
    __extends(ListContainer, _super);
    function ListContainer() {
        var _this = _super.call(this) || this;
        _this.paths = {
            getList: '/Album/List'
        };
        _this.state = {
            loadingData: true,
            items: []
        };
        return _this;
    }
    ListContainer.prototype.componentDidMount = function () {
        var _this = this;
        fetch(this.paths.getList, {
            credentials: 'include'
        })
            .then(function (response) {
            return response.text();
        })
            .then(function (data) {
            _this.setState(function (state, props) {
                state.items = JSON.parse(data);
                state.loadingData = false;
                console.log(state.items);
            });
        });
    };
    ListContainer.prototype.render = function () {
        var hasItems = this.state.items.length > 0;
        console.log(hasItems);
        return (this.state.loadingData ?
            React.createElement(LoadingView_1["default"], { Title: 'Albums' }) :
            hasItems ?
                React.createElement(ListView_1["default"], { items: this.state.items }) : React.createElement(EmptyListView_1["default"], null));
    };
    ListContainer.prototype.componentDidCatch = function (error, info) {
        console.log(error);
        console.log(info);
    };
    return ListContainer;
}(React.Component));
exports["default"] = ListContainer;
