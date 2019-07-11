import React, { Component } from 'react';
import styled from 'styled-components'

const Wrapper = styled.div`
  height: 100%;
`;

const Holidays = styled.div`
  background-color: white;
  height: 250px;
`;

const date = new Date();

function DayOfTheWeek(props) {
  const getDay = () => {
    switch(date.getDay()) {
      case 0: return 'Воскресение';
      case 1: return 'Понедельник';
      case 2: return 'Вторник';
      case 3: return 'Среда';
      case 4: return 'Четверг';
      case 5: return 'Пятница';
      case 6: return 'Суббота';
      default: return '';
    }
  };
  return (
    <div className={props.className}>
      <p>{ getDay() }</p>
    </div>
  );
}

const Top = styled(DayOfTheWeek)`
  background-color: #3c99d7;
  color: white;
  text-align: center;
  p {
    padding-top: 3px;
    padding-bottom: 3px;
    margin: 0;
  }
`;

const DisplayDate = styled.p`
  font-size: 50px;
`;

const Month = styled.p``;

function DateWrapper(props) {
 const getMonth = () => {
    switch (date.getMonth()) {
     case 0:  return 'Январь';
     case 1:  return 'Февраль';
     case 2:  return 'Март';
     case 3:  return 'Апрель';
     case 4:  return 'Май';
     case 5:  return 'Июнь';
     case 6:  return 'Июль';
     case 7:  return 'Август';
     case 8:  return 'Сентябрь';
     case 9:  return 'Октябрь';
     case 10: return 'Ноябрь';
     case 11: return 'Декабрь';
     default: return '';
   }
 };
 return (
    <div className={props.className}>
      <DisplayDate>{ date.getDate() }</DisplayDate>
      <Month> { getMonth() }</Month>
    </div>
  );
}

const Body = styled(DateWrapper)`
  background-color: #5cace1;
  color: white;
  text-align: center;
  p {
    padding-top: 3px;
    padding-bottom: 3px;
    margin: 0;
  }
`;


export default class Calendar extends Component {
  render() {
    return (
      <Wrapper className={this.props.className}>
        <Top />
        <Body />
        <Holidays />
      </Wrapper>
    );
  }
}
