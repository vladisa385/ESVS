import React, { Component } from 'react';
import styled from 'styled-components'
import Col from 'react-bootstrap/es/Col';
import Link from 'react-router-dom/es/Link';
import TopPic from '../assets/1.jpg'
import Row from 'react-bootstrap/es/Row';
import Calendar from './Calendar';

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
  md: 8
})`
  height: 100%;
`;
const Hr = styled.hr`
  background-color: white;
  height: 1px;
`;
const Title = styled.p`
  font-size: 22px;
`;
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
const CalendarContainer = styled(Col).attrs({
  md: 4
})`
  padding-top: 17px;
`;
const Wrapper = styled(Row)`
  height: 100%;
`;

export class Home extends Component {
  displayName = Home.name;

  render() {
    return (
      <React.Fragment>
        <Picture />
        <PageContainer>
          <Wrapper>
            <TextContainer>
              <Hr />
              <Title>О системе</Title>
              <br />
              <p>
                ЕСВС — это комплекс организационных мероприятий и технических средств
                для централизованного ведения и синхронизации электронных справочников
                для системы здравоохранения и ОМС Красноярского края.
              </p>
              <br />
              <AboutButton to={'/about'}>Подробнее</AboutButton>
            </TextContainer>
            <CalendarContainer>
              <Calendar />
            </CalendarContainer>
          </Wrapper>
        </PageContainer>
      </React.Fragment>
    );
  }
}
