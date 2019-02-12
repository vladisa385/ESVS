import React, { Component } from 'react';
import styled from 'styled-components'
import Col from 'react-bootstrap/es/Col';
import Row from 'react-bootstrap/es/Row';
import TopPic from '../assets/2.jpg'
import Promo from '../assets/promo.jpg'

const Picture = styled(Col)`
  background-image: url(${TopPic});
  background-size: cover;
  background-position: center top;
  height: 300px;
  border-bottom: 2px solid #5cace1;
`;
// const MainContainer = styled.div`
//   background: #dadfe1;
//   padding: 0;
// `;
const PageContainer = styled.div`
  padding: 15px;
`;
const TextContainer = styled(Col).attrs({
  md: 8
})``;
const Hr = styled.hr`
  background-color: white;
  height: 1px;
`;
const Title = styled.p`
  font-size: 22px;
`;
const PromoContainer = styled(Col).attrs({
  md: 4
})``;
const PromoPicture = styled.img.attrs({
  src: Promo
})`
  max-height: 100%;
  max-width: 100%;
  border: solid #5cace1;
`;

export class About extends Component {
  displayName = About.name;

  render() {
    return (
      <React.Fragment>
        <Picture />
        <PageContainer>
          <Row>
            <TextContainer>
              <Hr />
              <Title>Описание системы</Title>
              <br />
              <p>
                ЕСВС обеспечивает:<br />
                - приведение всех используемых справочников к единому формату;<br />
                - формирование справочников сложной структуры;<br />
                - функция редактирования справочников;<br />
                - печать данных из справочников;<br />
                - экспорт справочников и их составляющих во внешние форматы.<br />
                <br />
                Справочник ЕСВС включает:<br />
                - справочные данные;<br />
                - иерархическую структуру для справочных данных;<br />
                - дополнительные сведения о записях справочника.<br />
              </p>
              <br />
            </TextContainer>
            <PromoContainer>
              <br />
              <PromoPicture />
            </PromoContainer>
          </Row>
        </PageContainer>
      </React.Fragment>
    );
  }
}
