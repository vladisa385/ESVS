import React, { Component } from 'react';
import styled from 'styled-components'
import Col from 'react-bootstrap/es/Col';
import Row from 'react-bootstrap/es/Row';
import Picture from '../components/Picture'
import TopPic from '../assets/2.jpg'
import Promo from '../assets/promo.jpg'
import { PageContainer, Title, TextContainer, HR } from '../components/Misc'

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
  render() {
    return (
      <React.Fragment>
        <Picture picture={TopPic} />
        <PageContainer>
          <Row>
            <TextContainer>
              <HR />
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
