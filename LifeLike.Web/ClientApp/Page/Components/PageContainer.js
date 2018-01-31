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
import List from './List/List';
import EmptyListView from '../../Shared/Components/EmptyListView/EmptyListView';
import LoadingView from '../../Shared/Components/LoadingView/LoadingView';
var ListContainer = (function (_super) {
    __extends(ListContainer, _super);
    function ListContainer() {
        var _this = _super.call(this) || this;
        _this.paths = {
            getList: '/Api/Page/Pages'
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
        var hasProjects = this.state.items.length > 0;
        return (this.state.loadingData ?
            React.createElement(LoadingView, { Title: "Posts" }) :
            hasProjects ?
                React.createElement(List, { items: this.state.items }) : React.createElement(EmptyListView, null));
    };
    return ListContainer;
}(React.Component));
export default ListContainer;
//# sourceMappingURL=PageContainer.js.map