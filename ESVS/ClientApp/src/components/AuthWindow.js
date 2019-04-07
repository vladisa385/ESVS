import React, { Component } from 'react';
import Modal from 'react-bootstrap/es/Modal';
import Form from 'react-bootstrap/es/Form';
import { LoginButton } from './LoginButton'
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

const ModalWrapper = styled.div`
  background-color: #dadfe1;
`;

export class AuthWindow extends Component {
  render() {
    return (
      <Modal {...this.props} aria-labelledby="contained-modal-title-vcenter" centered>
      <Header closeButton>
        <Title>Авторизация</Title>
      </Header>
      <ModalWrapper>
        <Modal.Body>
          <Form>
            <Form.Group>
              <Form.Control type="login" placeholder="Логин" />
            </Form.Group>
            <Form.Group>
              <Form.Control type="password" placeholder="Пароль" />
            </Form.Group>
            <Form.Group>
              <Form.Check type="checkbox" label="Запомнить этот компьютер" />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer> <LoginButton /> </Modal.Footer>
      </ModalWrapper>
    </Modal>
    );
  }
}
