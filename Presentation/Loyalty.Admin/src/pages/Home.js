import React, { Component } from "react";
import {
  Col,
  Row,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  Alert,
} from "reactstrap";
import Owner from "./Owner/Owner";
import axios from "axios";
import Cookies from 'universal-cookie';

export default class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      password: "",
      data : null
    };

  }

  

  checkOwner = (url = "http://localhost:53055/api/Owner/IsOwnerValid") => {
    return {
      update: (body) => axios.post(url, body),
    };
  };

  success = () => {
    console.log("aferin!");
  };

  handleCheck = () => {
    var cookies = new Cookies();
    this.checkOwner()
      .update(this.state)
      .then(response => {
        if(response.data){
          this.setState(response.data);
          cookies.set('id', response.id, {path: '/'})
          cookies.set('firstname', response.firstname, {path: '/'})
          cookies.set('surname', response.surname, {path: '/'})
          cookies.set('email', response.email, {path: '/'})
          cookies.set('password', response.password, {path: '/'})
          this.props.history.push('/Dashboard');
        }else{
          alert("Hata!");
        }
      })
      .catch((err) => console.log(err));
  };

  render() {
    return (
      <Form>
        <Row form>
          <Owner />
        </Row>
        <Row form>
          <Col md={12}>
            <FormGroup>
              <Label for="Email">Email</Label>
              <Input
                type="email"
                name="email"
                id="Email"
                placeholder="with a placeholder"
                onChange={(e) => this.setState({ email: e.target.value })}
              />
            </FormGroup>
          </Col>
          <Col md={12}>
            <FormGroup>
              <Label for="examplePassword">Password</Label>
              <Input
                type="password"
                name="password"
                id="examplePassword"
                placeholder="password placeholder"
                onChange={(e) => this.setState({ password: e.target.value })}
              />
            </FormGroup>
          </Col>
        </Row>
        <Button onClick={() => this.handleCheck()}>Sign in</Button>
      </Form>
    );
  }
}
