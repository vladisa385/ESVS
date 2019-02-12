import React, { Component } from 'react';
import styled from 'styled-components'
import moment from 'moment';
import 'moment/locale/ru'

const Wrapper = styled.div`
  height: 100%;
  p:first-letter {
    text-transform: capitalize;
  }
`;
const Holidays = styled.div`
  background-color: white;
  height: 250px;
`;

function DayOfTheWeek(props) {
  return (
    <div className={ props.className }>
      <p>{ moment().format('dddd') }</p>
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
const Date = styled.p`
  font-size: 50px;
`;
const Month = styled.p`

`;
function DateWrapper(props) {
 return (
    <div className={ props.className }>
      <Date>{ moment().format('D') }</Date>
      <Month>{ moment().format('MMMM') }</Month>
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
  displayName = Calendar.name;

  render() {
    return (
      <Wrapper>
        <Top />
        <Body />
        <Holidays />
      </Wrapper>
    );
  }
}
