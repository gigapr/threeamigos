import React from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import NavMenu from './navMenu';

export default props => (
  <Grid fluid>
    <Row>
      <Col sm={12}>
        <NavMenu />
      </Col>
    </Row>
    <Row>
      <Col sm={2}></Col>
      <Col sm={8}>
        {props.children}
      </Col>
      <Col sm={2}></Col>
    </Row>
  </Grid>
);
