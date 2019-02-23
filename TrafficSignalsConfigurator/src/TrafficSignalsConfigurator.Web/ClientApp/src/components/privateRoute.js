import { Route } from 'react-router';
import React from 'react';
import { Redirect, Switch } from 'react-router-dom'

const PrivateRoute = ({ component: Component, isAuthenticated, ...rest }) => {
    return <Route {...rest} render={(props) => (
        isAuthenticated === true ? 
                <Component {...props} /> : 
                window.location.pathname = '/login'
    )} />
};

export default PrivateRoute;

