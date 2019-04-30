import React, { Component } from 'react';
import { AuthorizationBar } from './AuthorizationBar';
import { NavigationBar } from './NavigationBar';
import { Footer } from './Footer';
import styled from 'styled-components'
import Col from 'react-bootstrap/es/Col';

const Wrapper = styled(Col)`
  background-color: #dadfe1;
  width: ${props => props.width};
  height: 100%;
  padding: 0;
  margin: auto;
`;

const FooterWrapper = styled(Wrapper).attrs({
  id: "footer"
})`
  width: 850px;
  height: auto;
`;

const PageBody = styled.div`
  flex: 1 0 auto;
`;

const NavBackground = styled.div`
  background-color: #ecf0f1;
  height: 68px;
  margin-bottom: -68px;
`;

export class Layout extends Component {
  render() {
    const width = this.props.wide ? 'auto' : '850px';

    return (
      <React.Fragment>
        <PageBody>
          <AuthorizationBar authorizedAs={this.props.authorizedAs}
                            setAuthorizedAs={this.props.setAuthorizedAs} />
          <NavBackground />
          <Wrapper width={width}>
            <NavigationBar authorized={!!this.props.authorizedAs} />
            { this.props.children }
          </Wrapper>
        </PageBody>
        { !this.props.wide &&
          <FooterWrapper>
            <Footer />
          </FooterWrapper>
        }
      </React.Fragment>
    );
  }
}
