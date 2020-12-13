import React, { Component } from "react";
import {
  Container,
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
import Cookies from "universal-cookie";
import "../css/Login.css";

export default class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      password: "",
      data: null,
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
      .then((response) => {
        if (response.data) {
          this.setState(response.data);
          cookies.set("id", response.id, { path: "/" });
          cookies.set("firstname", response.firstname, { path: "/" });
          cookies.set("surname", response.surname, { path: "/" });
          cookies.set("email", response.email, { path: "/" });
          cookies.set("password", response.password, { path: "/" });
          this.props.history.push("/Dashboard");
        } else {
          alert("Hata!");
        }
      })
      .catch((err) => console.log(err));
  };

  render() {
    return (
      <Container className="loginContainer">
        <Col md={6}> </Col>
        <Col md={6}>
          <Form className="loginBox">
            <Row form>
              <FormGroup>
                <Input
                  type="email"
                  name="email"
                  id="Email"
                  placeholder="Email"
                  onChange={(e) => this.setState({ email: e.target.value })}
                />
              </FormGroup>
              <FormGroup>
                <Input
                  type="password"
                  name="password"
                  id="examplePassword"
                  placeholder="Password"
                  onChange={(e) => this.setState({ password: e.target.value })}
                />
              </FormGroup>
            </Row>
            <div className="loginButtons">
              <Button onClick={() => this.handleCheck()}>Sign in</Button>
              <Row form>
                <Owner />
              </Row>
            </div>
          </Form>
        </Col>
      </Container>
    );
  }
}
