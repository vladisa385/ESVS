import styled from 'styled-components';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';

export const PageContainer = styled.div`
  padding: 15px;
`;

export const Title = styled.p`
  font-size: 22px;
`;

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

export const ModalButton = styled(Button)`
  box-shadow: 0 0 8px 4px rgba(0,0,0,0.2);
  width: 200px
`;

export const Header = styled.h3`
  margin: 30px 0 30px 0;
  text-align: center;
`;

export const Description = styled.div`
  text-align: center;
  padding: 0 15px 0 15px;
`;

export const FailedMessage = styled.p`
  color: rgb(33, 37, 41, .4);
  text-align: center;
`;
