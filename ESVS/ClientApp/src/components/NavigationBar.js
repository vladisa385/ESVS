import React, { Component } from 'react';
import Navbar from 'react-bootstrap/es/Navbar';
import Nav from 'react-bootstrap/es/Nav';
import logo from '../assets/logo.png'
import { LinkContainer } from 'react-router-bootstrap';
import styled from 'styled-components'
import NavItem from 'react-bootstrap/es/NavItem';

const NavBar = styled(Navbar).attrs({
  className: "py-0 px-0"
})`
  background-color: #ecf0f1;
  .active {
    background-color: #dadfe1;
  }
`;

const NavLink = styled(NavItem)`
   padding: 22px 15px 22px 15px;
   :hover {
     color: #5cace1;
     cursor: pointer;
   }
`;

const NavBrand = styled(Navbar.Brand).attrs({
  className: "order-lg-last py-0 mx-0 ml-auto"
})``;

const NavText = styled(Navbar.Text).attrs({
  className: "py-0"
})`
  font-size: 12px;
  margin-top: 8px;
  padding-right: 15px;
`;

const Logo = styled.img.attrs({
  src: logo,
  className: "d-inline-block align-top",
  alt: "Логотип КМИАЦ"
})`
  height: 52px;
  width: 58px;
`;

export class NavigationBar extends Component {
  render() {
    return (
      <NavBar>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavLink>Главная</NavLink>
            </LinkContainer>
            <LinkContainer to={'/about'} exact>
              <NavLink>Описание&nbsp;системы</NavLink>
            </LinkContainer>
            <LinkContainer to={'/contacts'} exact>
              <NavLink>Контакты</NavLink>
            </LinkContainer>
          </Nav>
          <NavBrand>
            <NavText>ЕДИНАЯ СИСТЕМА ВЕДЕНИЯ<br />СПРАВОЧНИКОВ</NavText>
            <Logo />
          </NavBrand>
      </NavBar>
    );
  }
}
