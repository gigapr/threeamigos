import React from 'react';
import { Route } from 'react-router';
import Layout from './components/layout';
import Home from './components/home';
import PhasesTable from './components/phasesTable';
import Login from './components/login';
import Register from './components/register';
import store from './store/configureStore';
import PrivateRoute from './components/privateRoute';
import { connect } from 'react-redux';

import jwt_decode from 'jwt-decode';
import setAuthToken from './setAuthToken';
import { setCurrentUser, logoutUser } from './actions/authentication';

if(localStorage.jwtToken) {
  setAuthToken(localStorage.jwtToken);
  const decoded = jwt_decode(localStorage.jwtToken);
  store().dispatch(setCurrentUser(decoded));

  const currentTime = new Date() / 1000;
  if(decoded.exp < currentTime) {
    store().dispatch(logoutUser());
    window.location.href = '/login'
  }
}

const App = props => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/login' component={Login} />
    <Route path='/register' component={Register} />
    <PrivateRoute path='/phasesTable' component={PhasesTable} isAuthenticated={props.isAuthenticated} />
  </Layout>
);


const mapStateToProps = state => {
  return {
    ...state,
    isAuthenticated: state.auth.isAuthenticated
  };
};

export default connect(mapStateToProps)(App);
