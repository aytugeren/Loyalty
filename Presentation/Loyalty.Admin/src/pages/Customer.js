import React, {Component} from 'react';
import { Col, Row, Button, Form, FormGroup, Label, Input } from 'reactstrap';
import axios from 'axios';


export class Customer extends Component {

  constructor(props) {
    super(props);
    this.state = {
      firstname : "",
      surname : "",
      email : ""
    }
  }

  addCustomer = (url = "http://localhost:53055/api/Customer/SignUp") =>{
    return {
      update : (body) => axios.post(url,body)
    }
  }

  success = () => {
    console.log(this.state);
  }

  submitCustomer = () => {
  this.addCustomer().update(this.state).then(this.success()).catch(err => console.log(err));
  }

  render() {
    return (
      <div className="reports">
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
                  onChange = {(e) => this.setState({firstname : e.target.value})}
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
                  onChange = {(e) => this.setState({surname : e.target.value})}
                />
              </FormGroup>
            </Col>
          </Row>
          <Row form>
            <Col md={6}>
              <FormGroup>
                <Label for="email">Email</Label>
                <Input type="text" name="email" id="email" 
                  onChange = {(e) => this.setState({email : e.target.value})}
                />
              </FormGroup>
            </Col>
          </Row>
          <Button type="button" onClick={() => this.submitCustomer()}>
            Sign in
          </Button>
        </Form>
      </div>
    );
  }
}

export default Customer

