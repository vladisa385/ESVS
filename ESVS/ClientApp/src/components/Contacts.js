import React, { Component } from 'react';
import styled from 'styled-components';
import TopPic from '../assets/3.jpg'
import Col from 'react-bootstrap/es/Col';
import Row from 'react-bootstrap/es/Row';
import { Email } from './Footer'
import { Mail, MapPin, Phone, Printer } from 'styled-icons/feather';

const Picture = styled(Col)`
  background-image: url(${TopPic});
  background-size: cover;
  background-position: center top;
  height: 300px;
  border-bottom: 2px solid #5cace1;
`;
const PageContainer = styled.div`
  padding: 15px;
  height: 100%;
`;
const TextContainer = styled(Col).attrs({
  md: 6
})`
  height: 100%;
`;
const Hr = styled.hr`
  background-color: white;
  height: 1px;
  margin: 30px 130px 0 15px;
`;
const Title = styled.p`
  font-size: 22px;
`;
const Ul = styled.ul`
  list-style: none;
  padding: 0;
  li {
    padding-bottom: 5px;
    padding-left: 1.6em;
    svg {
      height: 1.3rem;
      width: 1.3rem;
      margin-left: -1.6em;
      color: #5cace1;
    }
  }
`;
const Wrapper = styled(Row)`
  height: 100%;
`;

export class Contacts extends Component {
  displayName = Contacts.name;

  render() {
    return (
      <React.Fragment>
        <Picture />
        <Hr />
        <PageContainer>
          <Wrapper>
            <TextContainer>
              <Title>Контакты</Title>
              <p>
                Вы всегда можете связаться с нами,<br />
                координаты, указанные в этом разделе.
            </p>
            <br />
            </TextContainer>
            <TextContainer>
              <Ul>
                <li>
                  <MapPin /> ул. Вейнбаума, 26<br />Красноярск, Россия 660049
                </li>
                <li>
                  <Phone /> +7 (391) 212-34-02
                </li>
                <li>
                  <Printer /> +7 (391) 227-95-78
                </li>
                <li>
                  <Mail /> <Email>office@kmiac.ru</Email>
                </li>
              </Ul>
            </TextContainer>
          </Wrapper>
        </PageContainer>
      </React.Fragment>
    );
  }
}
