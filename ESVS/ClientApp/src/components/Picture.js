import React, { Component } from 'react';
import styled from 'styled-components';

const Pic = styled.div`
  background-image: url(${props => props.picture});
  background-size: cover;
  background-position: center top;
  height: 300px;
  border-bottom: 2px solid #5cace1;
`;


export default class Picture extends Component {
  render() {
    return (
      <Pic picture={this.props.picture} />
    );
  }
}
