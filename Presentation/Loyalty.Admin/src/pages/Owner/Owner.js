import React, { Component, Fragment } from "react";
import {
  Col,
  Row,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Alert
} from "reactstrap";
import * as IconName from "react-icons/fa";
import axios from "axios";

export default class Owner extends Component {
  constructor(props) {
    super(props);
    this.state = {
      firstname: "",
      surname: "",
      email: "",
      password: "",
      show: false,
    };
  }

  addOwner = (url = "http://localhost:53055/api/Owner/SignUp") => {
    return {
      update: (body) => axios.post(url, body),
    };
  };

  success = () => {
      <Alert color="success">Aferin lan!</Alert>
  };

  submitOwner = () => {
    this.addOwner()
      .update(this.state)
      .then(this.success())
      .catch((err) => <Alert color="danger">Mal!</Alert>);
    this.handleClose();
  };

  handleClose = () => {
    var sshow = this.state.show;
    this.setState({ show: !sshow });
  };

  render() {
    return (
      <div>
        <Fragment>
          <Modal isOpen={this.state.show} toggle={this.handleClose} size="l">
            <ModalHeader>
              <IconName.FaWindowClose onClick={this.handleClose} />
            </ModalHeader>
            <ModalBody>
              <div className="popupModal">
                <Form method="POST">
                  <Row form>
                    <Col md={6}>
                      <FormGroup>
                        <Label for="firstname">Firstname</Label>
                        <Input
                          type="text"
                          name="firstname"
                          id="firstname"
                          placeholder="Firstname"
                          onChange={(e) =>
                            this.setState({ firstname: e.target.value })
                          }
                        />
                      </FormGroup>
                    </Col>
                    <Col md={6}>
                      <FormGroup>
                        <Label for="surname">Surname</Label>
                        <Input
                          type="text"
                          name="surname"
                          id="surname"
                          placeholder="Surname"
                          onChange={(e) =>
                            this.setState({ surname: e.target.value })
                          }
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row form>
                    <Col md={6}>
                      <FormGroup>
                        <Label for="email">Email</Label>
                        <Input
                          type="text"
                          name="email"
                          id="email"
                          placeholder="Email"
                          onChange={(e) =>
                            this.setState({ email: e.target.value })
                          }
                        />
                      </FormGroup>
                    </Col>
                    <Col md={6}>
                      <FormGroup>
                        <Label for="password">Password</Label>
                        <Input
                          type="password"
                          name="password"
                          id="password"
                          placeholder="*******"
                          onChange={(e) =>
                            this.setState({ password: e.target.value })
                          }
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Button type="button" onClick={() => this.submitOwner()}>
                    Sign in
                  </Button>
                </Form>
              </div>
            </ModalBody>
            <ModalFooter></ModalFooter>
          </Modal>
          <Button
            variant="primary"
            onClick={this.handleClose}
            show={this.state.show}
          >
            Sign Up
          </Button>
        </Fragment>
      </div>
    );
  }
}
