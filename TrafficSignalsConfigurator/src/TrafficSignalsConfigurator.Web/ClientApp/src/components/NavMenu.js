import { Link } from 'react-router-dom';
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { logoutUser } from '../actions/authentication';
import { withRouter } from 'react-router-dom';

class Navbar extends Component {

    onLogout(e) {
        e.preventDefault();
        this.props.logoutUser(this.props.history);
    }

    render() {
        const {isAuthenticated, user} = this.props.auth;
        const authLinks = (
            <div>
                <a href="/" className="nav-link" onClick={this.onLogout.bind(this)}>
                    {user.name} Logout
                </a>
                <Link to={'/'}>Home</Link>
                <Link to={'/counter'}>Counter</Link> 
                <Link to={'/phasesTable'}>Phases Table</Link>
                <Link to={'/fetchdata'}>Fetch data</Link>
                <Link to={'/login'}>Login</Link>
                <Link to={'/register'}>Register</Link>
            </div>
        )
      const guestLinks = (
            <div>
                <Link className="nav-link" to="/register">Sign Up</Link>
                <br/>
                <Link className="nav-link" to="/login">Sign In</Link>
            </div>
      )
        return(
            <div>
                {isAuthenticated ? authLinks : guestLinks}
            </div>
        )
    }
}
Navbar.propTypes = {
    logoutUser: PropTypes.func.isRequired,
    auth: PropTypes.object.isRequired
}

const mapStateToProps = (state) => ({
    auth: state.auth
})

export default connect(mapStateToProps, { logoutUser })(withRouter(Navbar));