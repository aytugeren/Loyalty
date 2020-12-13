import Cookies from 'universal-cookie';
import React, { Component } from 'react'

export default class ShopSettings extends Component {

    componentDidMount() {
        var cookies = new Cookies();
        if(!cookies.get('id')){
            this.props.history.push('./login');
        }
    }

    render() {
        return (
            <div>
                <h2>Shop Settings</h2>
            </div>
        )
    }
}
