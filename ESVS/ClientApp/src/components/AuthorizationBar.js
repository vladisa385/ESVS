import React, { Component } from 'react';
import Navbar from 'react-bootstrap/es/Navbar';
import Nav from 'react-bootstrap/es/Nav';
import styled from 'styled-components'
import { AuthWindow } from './AuthWindow';

const AuthBar = styled(Navbar).attrs({
  className: "navigation py-0 flex-row-reverse"
})`
  background-color: #35495d;
`;

const AuthBarLink = styled(Navbar.Text).attrs({
  className: "py-1 px-2"
})`
  &&& {
    color: white;
    :hover {
      color: #5cace1;
      cursor: pointer;
    }
  }
`;

export class AuthorizationBar extends Component {
  displayName = AuthorizationBar.name;
  constructor(...args) {
    super(...args);
    this.state = { modalShow: false };
  }

  render() {
    let modalClose = () => this.setState({ modalShow: false });
    return (
      <AuthBar>
        <Nav>
          <AuthBarLink onClick={() => this.setState({ modalShow: true })}>Вход</AuthBarLink>
          <AuthBarLink>Регистрация</AuthBarLink>
        </Nav>
        <AuthWindow show={this.state.modalShow} onHide={modalClose} />
      </AuthBar>
    );
  }
}
