import styled from 'styled-components';
import Col from 'react-bootstrap/es/Col';
import Modal from 'react-bootstrap/es/Modal';
import Button from 'react-bootstrap/es/Button';

export const PageContainer = styled.div`
  padding: 15px;
`;

export const Title = styled.p`
  font-size: 22px;
`;

export const TextContainer = styled(Col).attrs({
  md: 8
})``;

export const HR = styled.hr`
  background-color: white;
  height: 1px;
`;

export const Email = styled.a.attrs({
  href: "mailto: office@kmiac.ru"
})`
  color: #5cace1;
  :hover {
    color: #69bfff;
    text-decoration: none;
  }
`;

export const ModalTitle = styled(Modal.Title)`
  font-size: 16px;
  color: white;
`;

export const ModalHeader = styled(Modal.Header)`
  background-color: #35495d;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
  span {
    color: white;
  }
`;

export const ModalButton = styled(Button).attrs({
  className: "mx-auto",
  variant: "light",
  type: "submit"
})`
  box-shadow: 0 0 8px 4px rgba(0,0,0,0.2);
  width: 200px
`;


