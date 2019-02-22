import React from 'react';
import { Route } from 'react-router';
import Layout from './components/layout';
import Home from './components/home';
import PhasesTable from './components/phasesTable';
import Login from './components/login';
import Register from './components/register';
import store from './store/configureStore';

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

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/login' component={Login} />
    <Route path='/register' component={Register} />
    <Route path='/phasesTable' component={PhasesTable} />
  </Layout>
);
