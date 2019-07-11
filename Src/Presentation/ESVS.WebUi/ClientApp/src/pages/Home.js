import React, { Component } from 'react';
import styled from 'styled-components'
import Col from 'react-bootstrap/Col';
import Link from 'react-router-dom/Link';
import Picture from '../components/Picture'
import TopPic from '../assets/1.jpg'
import Row from 'react-bootstrap/Row';
import { PageContainer, Title, HR } from '../elements/Misc'
import Calendar from '../components/Calendar';

const AboutButton = styled(Link).attrs({
  className: "btn btn-primary"
})`
  padding-left: 22px;
  padding-right: 22px;
  background-color: #3c99d7;
  border-color: #3c99d7;
  :hover {
    background-color: #5cace1;
    border-color: #5cace1;
  }
`;

const WrappedCalendar = styled(Calendar)`
  padding-top: 17px;
`;

const Wrapper = styled(Row)`
  height: 100%;
`;


export class Home extends Component {
  render() {
    return (
      <React.Fragment>
        <Picture picture={TopPic} />
        <PageContainer>
          <Wrapper>
            <Col md={8}>
              <HR />
              <Title>О системе</Title>
              <br />
              <p>
                ЕСВС — это комплекс организационных мероприятий и технических средств
                для централизованного ведения и синхронизации электронных справочников
                для системы здравоохранения и ОМС Красноярского края.
              </p>
              <br />
              <AboutButton to={'/about'}>Подробнее</AboutButton>
            </Col>
            <Col md={4}>
              <WrappedCalendar />
            </Col>
          </Wrapper>
        </PageContainer>
      </React.Fragment>
    );
  }
}
