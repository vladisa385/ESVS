import React, { Component } from 'react';
import styled from 'styled-components'
import Col from 'react-bootstrap/es/Col';
import Row from 'react-bootstrap/es/Row';
import Link from 'react-router-dom/es/Link';

const Wrapper = styled.div`
  background-color: #35495d;
  padding: 0 10px 10px 10px;
`;
const ColumnContainer = styled(Col).attrs({
  sm: 4
})``;
const Hr = styled.hr`
  background-color: white;
  height: 1px;
`;
const Text = styled.p`
  color: white;
  font-size: 13px;
  margin: 0;
`;
const BarLink = styled(Link)`
  color: white;
  :hover {
    color: #5cace1;
    text-decoration: none;
  }
`;
export const Email = styled.a.attrs({
  href: "mailto: office@kmiac.ru"
})`
  color: #5cace1;
  :hover {
    color: #69bfff;
    text-decoration: none;
  }
`;

export class Footer extends Component {
  displayName = Footer.name;

  render() {
    return (
      <Wrapper>
        <Row>
          <ColumnContainer>
            <Hr />
            <Text>
              ул. Вейнбаума, 26<br />
              Красноярск, Россия 660049
            </Text>
          </ColumnContainer>
          <ColumnContainer>
            <Hr />
            <Text>
              +7 (391) 212-34-02 (тел.)<br />
              +7 (391) 227-95-78 (факс)<br />
              <Email>office@kmiac.ru</Email>
            </Text>
          </ColumnContainer>
          <ColumnContainer>
            <Hr />
            <Text>
              <BarLink to={'/'}>Главная</BarLink><br />
              <BarLink to={'/about'}>Описание системы</BarLink><br />
              <BarLink to={'/contacts'}>Контакты</BarLink>
            </Text>
          </ColumnContainer>
        </Row>
        <br />
        <Text>© 2018 Единая система ведения справочников (ЕСВС)</Text>
      </Wrapper>
    );
  }
}
