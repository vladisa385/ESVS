import React, { Component } from 'react';
import styled from 'styled-components';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table';
import Modal from 'react-bootstrap/Modal';
import Spinner from '../components/Spinner';
import { TreeSearchField } from '../components/TreeSearchField';
import { HR, ModalButton, ModalHeader, ModalTitle } from '../elements/Misc';
import { FileText } from 'styled-icons/feather/FileText';
import VladPic from '../assets/vlad.png';

const Header = styled.h5`
  margin: 20px 0 35px 15px;
`;

const UsersRow = (props) => {
  return (
    <tr className={props.className}>
      <th>{props.id}</th>
      <th>{props.firstName}</th>
      <th>{props.lastName}</th>
      <th>{props.email}</th>
      <th>{props.role}</th>
      { props.header ? <th></th> : <th> <FileText /> </th> }
    </tr>
  );
};

const StyledUsersRow = styled(UsersRow)`
  svg {
    height: 1.3rem;
    width: 1.3rem;
    color: #5cace1;
  }
`;

const ApplicationsRow = (props) => {
  return (
    <tr className={props.className}>
      <th>{props.id}</th>
      <th>{props.name}</th>
      <th>{props.org}</th>
      <th>{props.email}</th>
      <th>{props.reason}</th>
      { props.header ? <th></th> : <th> <FileText /> </th> }
    </tr>
  );
};

const StyledAppsRow = styled(ApplicationsRow)`
  svg {
    height: 1.3rem;
    width: 1.3rem;
    color: #5cace1;
  }
`;

const FakeRows = () => {
  return (
    <React.Fragment>
      <StyledAppsRow id="1"
                     name={'Иванов Иван Иванович'}
                     org={'Организация №1'}
                     email={'mail@mail.ru'}
                     reason={'Веская причина №1'}
                     header={false} />
      <StyledAppsRow id="2"
                     name={'Петров Петр Петрович'}
                     org={'Организация №2'}
                     email={'gmail@gmail.com'}
                     reason={'Веская причина №2'}
                     header={false} />
      <StyledAppsRow id="3"
                     name={'Сергеев Сергей Сергеевич'}
                     org={'Организация №3'}
                     email={'yal@ya.ru'}
                     reason={'Веская причина №3'}
                     header={false} />
      <StyledAppsRow id="4"
                     name={'Андреев Андрей Андреевич'}
                     org={'Организация №4'}
                     email={'yahoo@yahoo.com'}
                     reason={'Веская причина №4'}
                     header={false} />
    </React.Fragment>
  );
};

const ApplicationTable = (props) => {
  return (
    <Table striped bordered hover size="sm" responsive className={props.className}>
      <thead>
        <ApplicationsRow name="ФИО"
                         org="Организация"
                         email="Электронная почта"
                         reason="Причина подачи"
                         header={true} />
      </thead>
      <tbody>
        <FakeRows />
      </tbody>
    </Table>
  );
};

const StyledAppTable = styled(ApplicationTable)`
  background-color: #dadfe1;
  font-size: 12px;
`;

const UsersFakeRows = () => {
  return (
    <React.Fragment>
      <StyledUsersRow id="1"
                      firstName="Владислав"
                      lastName="Конюхов"
                      email="vladisa375@gmail.com"
                      role="Администратор"
                      header={false} />
      <StyledUsersRow id="2"
                      firstName="Никита"
                      lastName="Беляев"
                      email="test@test.ru"
                      role="Пользователь"
                      header={false} />
    </React.Fragment>
  );
};

const UsersTable = (props) => {
  return (
    <Table striped bordered hover size="sm" responsive className={props.className}>
      <thead>
        <UsersRow id="#"
                  firstName="Имя"
                  lastName="Фамилия"
                  email="Электронная почта"
                  role="Роль"
                  header={true} />
      </thead>
      <tbody>
        <UsersFakeRows />
      </tbody>
    </Table>
  );
};

const StyledUsersTable = styled(UsersTable)`
  background-color: #dadfe1;
  font-size: 12px;
`;

const AppsModal = (props) => {
  return (
    <Modal show={props.modalShow}
           onHide={props.modalClose}
           centered>
      <ModalHeader closeButton>
        <ModalTitle>Заявка</ModalTitle>
      </ModalHeader>
      <Modal.Body>
        <p><strong>ФИО:</strong> {props.name} </p>
        <p><strong>Организация:</strong> {props.org}</p>
        <p><strong>Почта:</strong> {props.email}</p>
        <p><strong>Причина подачи заявки:</strong></p>
        <p>{props.reason}</p>
      </Modal.Body>
      <Modal.Footer>
        <ModalButton onClick={props.modalClose}
                     className={"mx-auto"}
                     variant={"light"}
                     type={"submit"}> Отклонить </ModalButton>
        <ModalButton onClick={props.modalClose}
                     className={"mx-auto"}
                     variant={"light"} > Принять </ModalButton>
      </Modal.Footer>
    </Modal>
  );
};

const Vlad = styled.img.attrs({
  src: VladPic,
  className: "img-responsive"
})`
  height: 160px;
  width: 160px;
  border: 2px solid #5cace1;
`;

const UsersModal = (props) => {
  return (
    <Modal show={props.modalShow}
           onHide={props.modalClose}
           centered
           dialogClassName="modal-90w">
      <ModalHeader closeButton>
        <ModalTitle>Пользователь</ModalTitle>
      </ModalHeader>
      <Modal.Body>
        <Container>
          <Row>
            <Col xs={4} className="px-0">
              <Vlad />
            </Col>
            <Col xs={1}></Col>
            <Col xs={7} className="px-0">
              <p> <strong>Имя: </strong>{props.name} </p>
              <p><strong>Роль: </strong>{props.role}</p>
              <p><strong>Почта: </strong> {props.email} </p>
              <p>В системе с 10.12.2018</p>
            </Col>
          </Row>
        </Container>
      </Modal.Body>
      <Modal.Footer>
        <ModalButton onClick={props.modalClose}
                     className={"mx-auto"}
                     variant={"light"} > ОК </ModalButton>
      </Modal.Footer>
    </Modal>
  );
};

export class Users extends Component {
  constructor(props) {
    super(props);
    this.state = {
      loading: true,
      modalShow: false
    };
    this.getUsers = this.getUsers.bind(this);
  }

  componentDidMount() {
    this.getUsers();
  }

  getUsers() {
    // Ну тут я типа делаю fetch'и в дырявый API
    this.setState({ loading: false });
  }

  render() {
    const { loading } = this.state;
    let modalClose = () => this.setState({ modalShow: false });

    return (
      <Container>
        { loading ?
          <Spinner />
          :
          <Row>
            <Col md={12}>
              <br />
              <TreeSearchField placeholder="Поиск по заявкам и пользователям..." />
            </Col>
            <Col md={12}>
              <Header>Заявки на регистрацию</Header>
              <HR />
            </Col>
            <Col md={12}>
              <StyledAppTable />
            </Col>
            <Col md={12}>
              <Header>Пользователи системы</Header>
              <HR />
            </Col>
            <Col md={12}>
              <StyledUsersTable />
            </Col>
          </Row>
        }
        <AppsModal modalShow={false}
                   modalClose={modalClose}
                   name="Мелех Даниил Артурович"
                   email="hm@gmail.com"
                   org="СФУ"
                   reason="Над одним проектом же работаем, привет!"/>

        <UsersModal modalShow={false}
                    modalClose={modalClose}
                    name="Владислав Конюхов"
                    email="vladisa375@gmail.com"
                    role="Администратор" />
      </Container>
    );
  }
}
