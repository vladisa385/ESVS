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

const IconWrapper = styled.span`
  :hover { 
    cursor: pointer;
    svg { color: #69bfff; }
  }
`;

const UsersRow = (props) => {
  const { id, firstName, lastName, email, userrole, header, modalSet } = props;

  return (
    <tr className={props.className}>
      <th>{id}</th>
      <th>{firstName}</th>
      <th>{lastName}</th>
      <th>{email}</th>
      <th>{userrole}</th>
      { header ?
        <th />
        :
        <th>
          <IconWrapper onClick={() => modalSet(firstName + ' ' + lastName, email, userrole)}>
             <FileText />
          </IconWrapper>
        </th>
      }
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
  const { id, name, org, email, reason, header, modalSet } = props;

  return (
    <tr className={props.className}>
      <th>{id}</th>
      <th>{name}</th>
      <th>{org}</th>
      <th>{email}</th>
      <th>{reason}</th>
      { header ?
        <th />
        :
        <th>
          <IconWrapper onClick={() => modalSet(name, org, email, reason)}>
            <FileText />
          </IconWrapper>
        </th>
      }
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

const FakeRows = (props) => {
  return (
    <React.Fragment>
      <StyledAppsRow modalSet={props.modalSet}
                     id="1"
                     name={'Иванов Иван Иванович'}
                     org={'Организация №1'}
                     email={'mail@mail.ru'}
                     reason={'Веская причина №1'}
                     header={false} />
      <StyledAppsRow modalSet={props.modalSet}
                     id="2"
                     name={'Петров Петр Петрович'}
                     org={'Организация №2'}
                     email={'gmail@gmail.com'}
                     reason={'Веская причина №2'}
                     header={false} />
      <StyledAppsRow modalSet={props.modalSet}
                     id="3"
                     name={'Сергеев Сергей Сергеевич'}
                     org={'Организация №3'}
                     email={'yal@ya.ru'}
                     reason={'Веская причина №3'}
                     header={false} />
      <StyledAppsRow modalSet={props.modalSet}
                     id="4"
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
        <FakeRows modalSet={props.modalSet} />
      </tbody>
    </Table>
  );
};

const StyledAppTable = styled(ApplicationTable)`
  background-color: #dadfe1;
  font-size: 12px;
`;

const UsersFakeRows = (props) => {
  return (
    <React.Fragment>
      <StyledUsersRow modalSet={props.modalSet}
                      id="1"
                      firstName="Владислав"
                      lastName="Конюхов"
                      email="vladisa375@gmail.com"
                      userrole="Администратор"
                      header={false} />
      <StyledUsersRow modalSet={props.modalSet}
                      id="2"
                      firstName="Никита"
                      lastName="Беляев"
                      email="test@test.ru"
                      userrole="Пользователь"
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
                  userrole="Роль"
                  header={true} />
      </thead>
      <tbody>
        <UsersFakeRows modalSet={props.modalSet}/>
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
            <Col xs={1} />
            <Col xs={7} className="px-0">
              <p> <strong>Имя: </strong>{props.name} </p>
              <p><strong>Роль: </strong>{props.userrole}</p>
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
      appsModalShow: false,
      usersModalShow : false,
      appsModalName: '',
      appsModalEmail: '',
      appsModalOrg: '',
      appsModalReason: '',
      usersModalName: '',
      usersModalEmail: '',
      usersModalRole: ''
    };
    this.getUsers = this.getUsers.bind(this);
    this.setAppsModal = this.setAppsModal.bind(this);
    this.setUsersModal = this.setUsersModal.bind(this);
  }

  componentDidMount() {
    this.getUsers();
  }

  getUsers() {
    // Ну тут я типа делаю fetch'и в дырявый API
    this.setState({ loading: false });
  }

  setAppsModal = (name, email, org, reason) => this.setState( {
    appsModalShow: true,
    appsModalName: name,
    appsModalEmail: email,
    appsModalOrg: org,
    appsModalReason: reason
  });

  setUsersModal = (name, email, userrole) => this.setState( {
    usersModalShow: true,
    usersModalName: name,
    usersModalEmail: email,
    usersModalRole: userrole
  });

  render() {
    const { loading,
            appsModalShow,
            usersModalShow,
            appsModalName,
            appsModalEmail,
            appsModalOrg,
            appsModalReason,
            usersModalName,
            usersModalEmail,
            usersModalRole } = this.state;
    let modalClose = () => this.setState({
      appsModalShow: false,
      usersModalShow: false
    });


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
              <StyledAppTable modalSet={this.setAppsModal} />
            </Col>
            <Col md={12}>
              <Header>Пользователи системы</Header>
              <HR />
            </Col>
            <Col md={12}>
              <StyledUsersTable modalSet={this.setUsersModal} />
            </Col>
          </Row>
        }
        <AppsModal modalShow={appsModalShow}
                   modalClose={modalClose}
                   name={appsModalName}
                   email={appsModalEmail}
                   org={appsModalOrg}
                   reason={appsModalReason} />

        <UsersModal modalShow={usersModalShow}
                    modalClose={modalClose}
                    name={usersModalName}
                    email={usersModalEmail}
                    userrole={usersModalRole} />
      </Container>
    );
  }
}
