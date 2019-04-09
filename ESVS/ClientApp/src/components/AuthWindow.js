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
  box-shadow: 0 0 8px 4px rgba(0, 0, 0, 0.2);
  width: 200px
`;

const ErrorMessage = styled.p`
  background-color: rgba(255,76,59,0.2);
  border: 2px solid rgba(255,76,59,0.5);
  border-radius: .25rem;
  padding: 6px;
  text-align: center;
  margin-bottom: 0;
`;

const TextInput = styled(Form.Control)`
  && {
    :invalid {
      border-color: rgb(255,76,59,0.2);
    }
  }
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
    this.API = 'http://localhost:5000/api/Account/Login?Email=';
    this.authorize = this.authorize.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);
    // this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleInputChange(e) {
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
      // const APIcall = this.API + this.state.email +
      //   '&Password=' + this.state.password +
      //   '&RememberMe=' + this.state.rememberMe;
      const APIcall = 'httpstat.us/202';
      fetch(APIcall, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(res => res.ok ? res.text() : console.log('Ответ сервера воняет говном'))
        .then(data => {
          console.log('Чета есть, зырь ниже');
          console.log(data);
          this.setState({ isLoading: false });
        })
        .catch(error => {
          console.log('Дружок-пирожок, ошибочка: ', error);
          this.setState( {isLoading: false, fetchFailed: true} );
        })
    })
  }

  render() {
    const { isLoading, email, password, rememberMe, fetchFailed, validated } = this.state;

    return (
      <Modal {...this.props} aria-labelledby="contained-modal-title-vcenter" centered>
      <Header closeButton> <Title>Авторизация</Title> </Header>
        <Form validated={validated} ref={this.formRef}>
          <ModalWrapper>
            <Modal.Body>
              <Form.Group> <TextInput name="email"
                                       type="login"
                                       placeholder="Логин"
                                       value={email}
                                       onChange={this.handleInputChange}
                                       required />
                <Form.Control.Feedback type="valid">Введите логин</Form.Control.Feedback>
              </Form.Group>
              <Form.Group> <TextInput name="password"
                                       type="password"
                                       placeholder="Пароль"
                                       value={password}
                                       onChange={this.handleInputChange}
                                       required />
                <Form.Control.Feedback type="valid">Введите пароль</Form.Control.Feedback>
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
