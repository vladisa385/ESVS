import React, { Component } from 'react';
import styled from 'styled-components';
import Picture from '../components/Picture'
import TopPic from '../assets/3.jpg'
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { PageContainer, Title, HR, Email } from '../elements/Misc'
import { Mail, MapPin, Phone, Printer } from 'styled-icons/feather';

const Hr = styled(HR)`
  margin: 30px 130px 0 15px;
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
  render() {
    return (
      <React.Fragment>
        <Picture picture={TopPic} />
        <Hr />
        <PageContainer>
          <Wrapper>
            <Col md={6}>
              <Title>Контакты</Title>
              <p>
                Вы всегда можете связаться с нами используя<br />
                координаты, указанные в этом разделе.
              </p>
            <br />
            </Col>
            <Col md={6}>
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
            </Col>
          </Wrapper>
        </PageContainer>
      </React.Fragment>
    );
  }
}
