import React, { Component } from 'react'
import Cookies from 'universal-cookie';

export default class PointSystem extends Component {

    componentDidMount() {
        var cookies = new Cookies();
        if(!cookies.get('id')){
            this.props.history.push('./login');
        }
    }

    render() {
        return (
            <div>
                <h1>Point system</h1>
            </div>
        )
    }
}
