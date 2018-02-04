import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';
import MenuList from "./Components/MenuContainer";


export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
            <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Pokaż Menu</span>
                        <span className='icon-bar'/>
                        <span className='icon-bar'/>
                        <span className='icon-bar'/>
                    </button>
                    <Link className='navbar-brand' to={ '/' }>LifeLike</Link>
                </div>
                <div className='clearfix'/>
                <div className='navbar-collapse collapse'>
                     
                        <MenuList />              
                </div>
            </div>
        </div>;
    }
}
