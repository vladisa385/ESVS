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

function BarItem(props) {
  return (
    <LinkContainer to={props.to} exact>
      <NavLink>{props.label}</NavLink>
    </LinkContainer>
  );
}

export class NavigationBar extends Component {
  render() {
    const authorized = this.props.authorized;

    return (
      <NavBar>
          <Nav>
            <BarItem to={'/'} label={'Главная'} />
            <BarItem to={'/about'} label={'Описание\xa0системы'} />
            <BarItem to={'/contacts'} label={'Контакты'} />
            { authorized &&
              <BarItem to={'/esvs'} label={'Справочники'} />
            }
          </Nav>
          <NavBrand>
            <NavText>ЕДИНАЯ СИСТЕМА ВЕДЕНИЯ<br />СПРАВОЧНИКОВ</NavText>
            <Logo />
          </NavBrand>
      </NavBar>
    );
  }
}
