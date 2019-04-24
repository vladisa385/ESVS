import React, { Component } from 'react';
import styled from 'styled-components';
import Container from 'react-bootstrap/es/Container';
import Row from 'react-bootstrap/es/Row';
import Col from 'react-bootstrap/es/Col';
import Form from 'react-bootstrap/es/Form';
import Button from 'react-bootstrap/es/Button';
import Modal from 'react-bootstrap/es/Modal';
import { HR } from '../components/Misc';
import { ModalHeader, ModalTitle, ModalButton } from '../components/Misc';

const Header = styled.h3`
  margin: 30px 0 30px 0;
  text-align: center;
`;

const Description = styled(Col).attrs({
  md: 11
})`
  text-align: center;
`;

const SubmitButton = styled(Button)`
  margin: 25px 0 30px 0;
  background-color: #3c99d7;
  border-color: #3c99d7;
  :hover {
    background-color: #5cace1;
    border-color: #5cace1;
  }
`;


export class Register extends Component {
  constructor(props) {
    super(props);
    this.state = { modalShow: false };
    this.submit = this.submit.bind(this);
  }

  submit(e) {
    e.preventDefault();
    this.setState({ modalShow: true });
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
              <Form.Group>
                <Form.Label>ФИО</Form.Label>
                <Form.Control  name="name"
                               type="text"
                               required />
              </Form.Group>
              <Form.Group>
                <Form.Label>Организация</Form.Label>
                <Form.Control  name="org"
                               type="text"
                               required />
              </Form.Group>
              <Form.Group>
                <Form.Label>Электронная почта</Form.Label>
                <Form.Control  name="email"
                               type="email"
                               required />
              </Form.Group>
              <Form.Group>
                <Form.Label>Причина подачи заявки</Form.Label>
                <Form.Control  as="textarea"
                               rows="3"
                               name="reason"
                               type="text" />
              </Form.Group>
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
            <ModalButton onClick={modalClose}>ОК</ModalButton>
          </Modal.Footer>
        </Modal>

      </React.Fragment>
    );
  }
}
