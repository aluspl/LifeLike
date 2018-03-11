'use strict';

import Item from "../Models/Page";
import * as React from "react";

interface Props {
    Item: Item
}

export  default class PostDetailView extends React.Component<Props, any>
{
    public render() {
        let Item=this.props.Item;
        return (
            <div>
                <div className="subheading">
                    {Item.FullName}
                </div>
                <p> {Item.Content} </p>
                <p> {Item.Category} </p>
            </div>
        );
    };
}
    