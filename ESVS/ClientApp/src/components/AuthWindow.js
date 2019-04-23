import React, { Component } from 'react';
import Modal from 'react-bootstrap/es/Modal';
import Form from 'react-bootstrap/es/Form';
import styled from 'styled-components';
import Button from 'react-bootstrap/es/Button';

const Title = styled(Modal.Title)`
  font-size: 16px;
  color: white;
`;

const Header = styled(Modal.Header)`
  background-color: #35495d;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
  span {
    color: white;
  }
`;

const ModalWrapper = styled.div`
  background-color: #dadfe1;
`;

const LoginButton = styled(Button).attrs({
  className: "mx-auto",
  variant: "light",
  type: "submit"
})`
  box-shadow: 0 0 8px 4px rgba(0,0,0,0.2);
  width: 200px
`;

const ErrorMessage = styled.p`
  background-color: rgba(255,76,59,0.1);
  border: 2px solid rgba(255,76,59,0.5);
  border-radius: .25rem;
  padding: 6px;
  text-align: center;
  margin-bottom: 0;
`;

const Checkbox = styled(Form.Check)`
  label:valid {
    color: black;
  }
`;


export class AuthWindow extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      password: '',
      rememberMe: true,
      isLoading: false,
      fetchFailed: false,
      validated: false
    };
    this.formRef = React.createRef();
    this.API = 'http://localhost:33333/api/Account/Login';
    this.authorize = this.authorize.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);
    // this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleInputChange(e) {
    this.setState({fetchFailed: false});

    const target = e.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  }

  handleSubmit() {
    const form = this.formRef.current;
    this.setState({validated: true});
    return form.checkValidity();
  }

  authorize() {
    if (!this.handleSubmit()) { return; }
    console.log("Email: " + this.state.email);
    console.log("Password: " + this.state.password);
    console.log("RememberMe: " + this.state.rememberMe);
    this.setState({ isLoading: true, fetchFailed: false }, () => {
      fetch(this.API, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: {
          "email" : this.state.email,
          "password" : this.state.password,
          "rememberMe" : this.state.rememberMe
        }
      })
        // .then(res => res.ok ? res.text() : console.log('Ответ сервера воняет говном'))
        .then(res => console.log(res.json()))
        .catch(err => {
          console.log('Дружок-пирожок, ошибочка: ', err);
          this.setState( {isLoading: false, fetchFailed: true} );
        })
    })
  }

  render() {
    const { isLoading, email, password, rememberMe, fetchFailed, validated } = this.state;

    return (
      <Modal {...this.props} aria-labelledby="contained-modal-title-vcenter" centered>
      <Header closeButton> <Title>Авторизация</Title> </Header>
        <Form ref={this.formRef}>
          <ModalWrapper>
            <Modal.Body>
              <Form.Group> <Form.Control name="email"
                                       type="login"
                                       placeholder="Логин"
                                       value={email}
                                       onChange={this.handleInputChange}
                                       required />
                <Form.Control.Feedback type="invalid">Введите логин</Form.Control.Feedback>
              </Form.Group>
              <Form.Group> <Form.Control name="password"
                                       type="password"
                                       placeholder="Пароль"
                                       value={password}
                                       onChange={this.handleInputChange}
                                       required />
                <Form.Control.Feedback type="invalid">Введите пароль</Form.Control.Feedback>
              </Form.Group>
              <Form.Group> <Checkbox name="rememberMe"
                                      type="checkbox"
                                      label="Запомнить этот компьютер"
                                      checked={rememberMe}
                                      onChange={this.handleInputChange} />
              </Form.Group>
              { fetchFailed &&
                <ErrorMessage>Неверный логин или пароль</ErrorMessage>
              }
            </Modal.Body>
            <Modal.Footer>
              <LoginButton disabled={isLoading} onClick={!isLoading ? this.authorize : null}>
                {isLoading ? 'Входим...' : 'Войти'}
              </LoginButton>
            </Modal.Footer>
          </ModalWrapper>
        </Form>
      </Modal>
    );
  }
}
