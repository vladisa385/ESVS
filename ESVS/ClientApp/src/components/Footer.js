import React, { Component } from 'react';
import styled from 'styled-components'
import Col from 'react-bootstrap/es/Col';
import Row from 'react-bootstrap/es/Row';
import Link from 'react-router-dom/es/Link';
import { Email, HR } from './Misc'

const Wrapper = styled.div`
  background-color: #35495d;
  padding: 0 10px 10px 10px;
`;

const ColumnContainer = styled(Col).attrs({
  sm: 4
})``;

const Text = styled.p`
  color: white;
  font-size: 13px;
  margin: 0;
`;

class Column extends Component {
  render() {
    return (
      <ColumnContainer>
        <HR/>
        <Text>
          {this.props.children}
        </Text>
      </ColumnContainer>
    );
  }
}

const BarLink = styled(Link)`
  color: white;
  :hover {
    color: #5cace1;
    text-decoration: none;
  }
`;

export class Footer extends Component {
  render() {
    return (
      <Wrapper>
        <Row>
          <Column>
            ул. Вейнбаума, 26<br />
            Красноярск, Россия 660049
          </Column>
          <Column>
            +7 (391) 212-34-02 (тел.)<br />
            +7 (391) 227-95-78 (факс)<br />
            <Email>office@kmiac.ru</Email>
          </Column>
          <Column>
            <BarLink to={'/'}>Главная</BarLink><br />
            <BarLink to={'/about'}>Описание системы</BarLink><br />
            <BarLink to={'/contacts'}>Контакты</BarLink>
          </Column>
        </Row>
        <br />
        <Text>© 2019 Единая система ведения справочников (ЕСВС)</Text>
      </Wrapper>
    );
  }
}
