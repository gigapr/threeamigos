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
        const { isAuthenticated, user } = this.props.auth;
        
        const authLinks = (loggedInUser) => (
            <ul className="nav navbar-nav navbar-right">
                <li>
                    <a href="/" onClick={this.onLogout.bind(this)}><span className="glyphicon glyphicon-user"></span> 
                    {loggedInUser.username}
                     Logout</a>
                </li>
            </ul>

        )
        const guestLinks = (
            <ul className="nav navbar-nav navbar-right">
                <li><a href="/register"><span className="glyphicon glyphicon-user"></span> Sign Up</a></li>
                <li><a href="/login"><span className="glyphicon glyphicon-log-in"></span> Login</a></li>
            </ul >
        )

        return (
            <nav className="navbar navbar-inverse">
                <div className="container-fluid">
                    <div className="navbar-header">
                        <a className="navbar-brand" href="/">Home</a>
                    </div>
                    <ul className="nav navbar-nav">
                        <li><a href="/phasesTable">Phases Table</a></li>
                    </ul>

                    {isAuthenticated ? authLinks(user) : guestLinks}
                </div>
            </nav>
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