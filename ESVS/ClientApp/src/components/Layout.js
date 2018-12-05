import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

export class Layout extends Component {
  displayName = Layout.name

  render() {
    return (
      <Grid fluid>
        <Row>
          <Col md={2}></Col>
          <Col md={8}>
            {this.props.children}
          </Col>
          <Col md={2}></Col>
        </Row>
      </Grid>
    );
  }
}
