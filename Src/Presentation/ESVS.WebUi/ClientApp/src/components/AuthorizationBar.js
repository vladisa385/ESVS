import React, { Component } from 'react';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import styled from 'styled-components'
import { LinkContainer } from 'react-router-bootstrap';
import NavItem from 'react-bootstrap/NavItem';
import AuthWindow from './AuthWindow';
import { URL } from '../App';

const AuthBar = styled(Navbar).attrs({
  className: "navigation py-0 flex-row-reverse"
})`
  background-color: #35495d;
`;

const AuthBarText = styled(NavItem).attrs({
  className: "py-1 px-2"
})`
  &&& { color: white; }
`;

const AuthBarLink = styled(AuthBarText)`
  &&& { 
    :hover { 
      color: #5cace1;
      cursor: pointer;
    } 
  }
`;


export class AuthorizationBar extends Component {
  constructor(props) {
    super(props);
    this.state = { modalShow: false };
    this.unauthorize = this.unauthorize.bind(this);
  }

  unauthorize() {
    const API = 'http://' + URL + ':33333/api/Account/LogOff';
    fetch(API, {
      method: 'PUT',
      credentials: 'include',
      headers: { 'Accept' : 'application/json' }
    })
      .then(() => this.props.setAuthorizedAs(''))
      .catch(err => console.error(err));
  }

  render() {
    let modalClose = () => this.setState({ modalShow: false });
    const authorizedAs = this.props.authorizedAs;

    return (
      <AuthBar>
        <Nav>
          { !authorizedAs &&
            <React.Fragment>
              <AuthBarLink onClick={() => this.setState({ modalShow: true })}>Войти</AuthBarLink>
              <LinkContainer to={'register'} exact>
                <AuthBarLink>Регистрация</AuthBarLink>
              </LinkContainer>
            </React.Fragment>
          }

          { !!authorizedAs &&
            <React.Fragment>
              <AuthBarText>{ `Вы вошли как ${authorizedAs}` }</AuthBarText>
              <LinkContainer to={'users'} exact>
                <AuthBarLink>Управление</AuthBarLink>
              </LinkContainer>
              <AuthBarLink onClick={() => this.unauthorize()}>Выйти</AuthBarLink>
            </React.Fragment>
          }
        </Nav>

        {!authorizedAs &&
          <AuthWindow show={this.state.modalShow}
                      hide={modalClose}
                      setAuthorizedAs={this.props.setAuthorizedAs} />
        }
      </AuthBar>
    );
  }
}
