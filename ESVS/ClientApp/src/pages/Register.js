import React, { Component } from 'react';
import styled from 'styled-components';
import Form from 'react-bootstrap/es/Form';
import Button from 'react-bootstrap/es/Button'

const Wrapper = styled.div`
  margin: 30px 150px 30px 150px;
`;
const Header = styled.h3`
  margin-top: 30px;
  padding-bottom: 25px;
  text-align: center;
`;

export class Register extends Component {
  render() {
    return(
      <React.Fragment>
      <Header>Регистрация в системе</Header>
        <Wrapper>
          <p>Вы можете подать заявление на регистрацию в системе, используя форму, представленную ниже. С вами свяжутся по указанному адресу в течение недели.</p>
          <Form>
            <Form.Group>
              <Form.Label>ФИО</Form.Label>
              <Form.Control name="name"
                             type="text"
                             required />
            </Form.Group>
            <Form.Group>
              <Form.Label>Организация</Form.Label>
              <Form.Control name="org"
                             type="text"
                             required />
            </Form.Group>
            <Form.Group>
              <Form.Label>Электронная почта</Form.Label>
              <Form.Control name="email"
                             type="email"
                             required />
            </Form.Group>
            <Form.Group>
              <Form.Label>Причина подачи заявки</Form.Label>
              <Form.Control name="reason"
                             type="text"
                             required />
              <Button type="submit">Подать заявку</Button>
            </Form.Group>
          </Form>
        </Wrapper>
      </React.Fragment>
    );
  }
}
