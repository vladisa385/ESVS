import React, { Component } from 'react';
import { AuthorizationBar } from './AuthorizationBar';
import { NavigationBar } from './NavigationBar';
import { Footer } from './Footer';
import styled from 'styled-components'
import Col from 'react-bootstrap/es/Col';

const Wrapper = styled(Col)`
  background-color: #dadfe1;
  width: 850px;
  height: 100%;
  padding: 0;
  margin: auto;
`;
const FooterWrapper = styled(Wrapper).attrs({
  id: "footer"
})`
  height: auto;
`;
const PageBody = styled.div`
  flex: 1 0 auto;
`;
const NavBackground = styled.div` // Костыль
  background-color: #ecf0f1;
  height: 68px;
  margin-bottom: -68px;
`;

export class Layout extends Component {
  displayName = Layout.name;

  render() {
    return (
      <React.Fragment>
        <PageBody>
          <AuthorizationBar />
          <NavBackground />
          <Wrapper>
            <NavigationBar />
            { this.props.children }
          </Wrapper>
        </PageBody>
        <FooterWrapper>
          <Footer />
        </FooterWrapper>
      </React.Fragment>
    );
  }
}
