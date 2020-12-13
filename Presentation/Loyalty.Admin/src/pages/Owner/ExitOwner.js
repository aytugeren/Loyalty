import React, { Component } from 'react'
import {Button} from 'reactstrap'
import Cookies from 'universal-cookie'
import '../../css/Owner.css'

export class ExitOwner extends Component {

    constructor(props) {
        super(props);
    }


    removeCookies = () => {
        var cookies = new Cookies();
        cookies.remove("id", {path: "/"});
        cookies.remove("firstname", {path: "/"});
        cookies.remove("surname", {path: "/"});
        cookies.remove("email", {path: "/"});
        cookies.remove("password", {path: "/"});
        window.location.reload();
    }

    render() {
        return (
            <div>
                <Button className="danger" onClick={this.removeCookies}>Exit</Button>
            </div>
        )
    }
}

export default ExitOwner
