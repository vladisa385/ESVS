import React, { Component } from 'react';
import styled from 'styled-components';
import { Search } from 'styled-icons/feather';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';

const Wrapper = styled.div`
  svg {
    height: 1.3rem;
    width: 1.3rem;
  }
`;


export class TreeSearchField extends Component {
  render() {
    return (
      <Wrapper>
        <InputGroup className="mb-3">
          <InputGroup.Prepend>
            <InputGroup.Text id="basic-addon1"> <Search /> </InputGroup.Text>
          </InputGroup.Prepend>
          <FormControl
            placeholder={this.props.placeholder}
            aria-label="Search"
            aria-describedby="basic-addon1"
            onKeyUp={this.props.onkeyup}
          />
        </InputGroup>
      </Wrapper>
    );
  }
}
