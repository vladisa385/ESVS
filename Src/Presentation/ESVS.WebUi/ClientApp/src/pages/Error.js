import React, { Component } from 'react';
import styled from 'styled-components'

const Message = styled.p`
  font-size: 40px;
  text-align: center;
  margin: auto;
`;

const Wrapper = styled.div`
  height: 100%;
  margin: auto;
`;


export class Error extends Component {
  render() {
    return(
      <Wrapper>
        <Message> {this.props.message} </Message>
      </Wrapper>
    );
  }
}
