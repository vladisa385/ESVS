import React, { Component } from 'react';
import Modal from 'react-bootstrap/es/Modal';
import Button from 'react-bootstrap/es/Button';
import Form from 'react-bootstrap/es/Form';
import styled from 'styled-components';

const Title = styled(Modal.Title)`
  font-size: 16px;
  color: white;
`;
const Header = styled(Modal.Header)`
  background-color: #35495d;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
  span {
    color: white;
  }
`;
const LoginButton = styled(Button).attrs({
  className: "mx-auto",
  variant: "light"
})`
  box-shadow: 0 0 8px 4px rgba(0, 0, 0, 0.2);
  width: 200px
`;
const ModalWrapper = styled.div`
  background-color: #dadfe1;
`;

export class AuthWindow extends Component {
  displayName = AuthWindow.name;

  login() {

  }

  render() {
    return (
      <Modal
        {...this.props}
        aria-labelledby="contained-modal-title-vcenter"
        centered>
      <Header closeButton>
        <Title>Авторизация</Title>
      </Header>
      <ModalWrapper>
        <Modal.Body>
          <Form>
            <Form.Group>
              <Form.Control type="login" placeholder="Логин" />
            </Form.Group>
          </Form>
          <Form.Group>
            <Form.Control type="password" placeholder="Пароль" />
          </Form.Group>
          <Form.Group>
            <Form.Check type="checkbox" label="Запомнить этот компьютер" />
          </Form.Group>
        </Modal.Body>
        <Modal.Footer>
          <LoginButton onClick={this.props.onHide}>Войти</LoginButton>
        </Modal.Footer>
      </ModalWrapper>
    </Modal>
    );
  }
}
