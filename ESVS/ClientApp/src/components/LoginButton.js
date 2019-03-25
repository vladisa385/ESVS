import React, { Component, Fragment } from 'react';
import styled from 'styled-components';
import Button from 'react-bootstrap/es/Button';

const StyledButton = styled(Button).attrs({
  className: "mx-auto",
  variant: "light"
})`
  box-shadow: 0 0 8px 4px rgba(0, 0, 0, 0.2);
  width: 200px
`;

const ErrorMessage = styled.p`
  color: #FF5733;
`;

const API = 'http://localhost:5000/api/Account/Login?Email=s%40gmail.com&Password=Sdashkhdkasj141414&RememberMe=false';

export class LoginButton extends Component {
  constructor(props) {
    super(props);
    this.authorize = this.authorize.bind(this);
    this.state = { isLoading: false, fetchFailed: false };
  }

  authorize() {
    this.setState({ isLoading: true }, () => {
      fetch(API)
        .then(res => res.ok ? res.json() : console.log('cheta pizda'))
        .then(data => {
          console.log(data);
          this.setState({ isLoading: false });
        })
        .catch(error => {
          console.log('pizda: ', error);
          this.setState( {isLoading: false, fetchFailed: true} );
        })
    })
  }

  handleFetchError() {

  }

  render() {
    const { isLoading } = this.state;

    return(
      <Fragment>
        <StyledButton disabled={isLoading} onClick={!isLoading ? this.authorize : null}>
          {isLoading? 'Входим...' : 'Войти'}
        </StyledButton>
        { this.state.fetchFailed &&
          <ErrorMessage> ПИЗДА НЕРОБОТОЕТ!!!!11 </ErrorMessage>
        }
      </Fragment>
    );
  }
}
