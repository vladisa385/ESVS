import styled from 'styled-components';
import Col from 'react-bootstrap/es/Col';

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
