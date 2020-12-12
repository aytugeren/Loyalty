import React, {Component, Fragment} from 'react';
import { Col, Row, Button, Form, FormGroup, Label, Input, Modal,ModalBody,ModalFooter,ModalHeader } from 'reactstrap';
import axios from 'axios';
import '../css/Customer.css';
import * as IconName from 'react-icons/fa';
import { AiTwotoneRightSquare } from 'react-icons/ai';


export default class Customer extends Component {

  constructor(props) {
    super(props);
    this.state = {
      firstname : "",
      surname : "",
      email : "",
      show : false
    }
  }
  

  addCustomer = (url = "http://localhost:53055/api/Customer/SignUp") =>{
    return {
      update : (body) => axios.post(url,body)
    }
  }

  refreshPage = () =>{
    window.location.reload();
  }

  submitCustomer = () => {
  this.addCustomer().update(this.state).then(this.refreshPage()).catch(err => console.log(err));
  this.handleClose();
  }


  handleClose = () => {
    var sshow = this.state.show;
    this.setState({show : !sshow})
  }

  render() {
    return (
      <Fragment>
      
      <Modal isOpen={this.state.show} toggle={this.handleClose} size="l" className="popupModal">
        <ModalHeader><IconName.FaWindowClose onClick={this.handleClose} /></ModalHeader>
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
      </ModalBody>
      <ModalFooter></ModalFooter>
      </Modal>
      <Button variant="primary" onClick={this.handleClose} show={this.state.show}>
        Add Customer
      </Button>
      </Fragment>
    );
  }
}


