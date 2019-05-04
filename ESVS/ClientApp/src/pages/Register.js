import React, { Component } from 'react';
import styled from 'styled-components';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { ModalHeader, ModalTitle, ModalButton, HR, Header, Description } from '../elements/Misc';

const SubmitButton = styled(Button)`
  margin: 25px 0 30px 0;
  background-color: #3c99d7;
  border-color: #3c99d7;
  :hover {
    background-color: #5cace1;
    border-color: #5cace1;
  }
`;

function Input(props) {
  return (
    <Form.Group>
      <Form.Label>{props.label}</Form.Label>
      <Form.Control  name={props.name}
                     type={props.type}
                     as={props.as}
                     rows={props.rows}
                     required />
    </Form.Group>
  );
}


export class Register extends Component {
  constructor(props) {
    super(props);
    this.state = { modalShow: false };
    this.submit = this.submit.bind(this);
  }

  submit(e) {
    e.preventDefault();
    this.setState({ modalShow: true });
    // ЭХ, АПИШКУ ХОЧЕТСЯ...
  }

  render() {
    let modalClose = () => this.setState({ modalShow: false });
    return (
      <React.Fragment>
        <Container>
          <Header>Регистрация в системе</Header>
          <Row className="justify-content-md-center">
            <Description>
              <p>Вы можете подать заявление на регистрацию в системе, используя форму, представленную ниже.
                С вами свяжутся по указанному адресу электронной почты в течение недели.</p>
            </Description>
            <Col md="7">
              <HR />
            <Form onSubmit={this.submit}>
              <Input label={"ФИО"}
                     name={"name"}
                     type={"text"} />
              <Input label={"Организация"}
                     name={"org"}
                     type={"text"} />
              <Input label={"Электронная почта"}
                     name={"email"}
                     type={"email"} />
              <Input label={"Причина подачи заявки"}
                     name="reason"
                     type="text"
                     as="textarea"
                     rows="3" />
              <HR />
              <SubmitButton type="submit" block>Подать заявку</SubmitButton>
            </Form>
            </Col>
          </Row>
        </Container>

        <Modal show={this.state.modalShow} onHide={modalClose}>
          <ModalHeader closeButton>
            <ModalTitle>Регистрация в системе</ModalTitle>
          </ModalHeader>
          <Modal.Body>Заявка на регистрацию в системе успешно подана.</Modal.Body>
          <Modal.Footer>
            <ModalButton onClick={modalClose}
                         className={"mx-auto"}
                         variant={"light"}
                         type={"submit"}> ОК </ModalButton>
          </Modal.Footer>
        </Modal>

      </React.Fragment>
    );
  }
}
