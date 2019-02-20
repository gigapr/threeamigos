import axios from 'axios';
import setAuthToken from '../setAuthToken';
import jwt_decode from 'jwt-decode';

export const AUTHENTCATION_ERRORS = 'AUTHENTCATION_ERRORS';
export const SET_CURRENT_USER = 'SET_CURRENT_USER';
export const REGISTER_USER = 'REGISTER_USER';

export const registerUser = (user, history) => dispatch => {
    if (!user.username) {
        dispatch({
            type: AUTHENTCATION_ERRORS,
            payload: { username: "Username is required" }
        });
        return;
    }
    if (!user.email) {
        dispatch({
            type: AUTHENTCATION_ERRORS,
            payload: { email: "Email is required" }
        });
        return;
    }
    if (!user.password) {
        dispatch({
            type: AUTHENTCATION_ERRORS,
            payload: { password: "Password is required" }
        });
        return;
    }
    if (!user.password_confirm) {
        dispatch({
            type: AUTHENTCATION_ERRORS,
            payload: { password_confirm: "Password is required" }
        });
        return;
    }
    if (user.password !== user.password_confirm) {
        dispatch({
            type: AUTHENTCATION_ERRORS,
            payload: { password_confirm: "The specified passwords do not match" }
        });
        return;
    }
    axios.post('/api/Auth/register', user)
        .then(res => history.push('/login'))
        .catch(err => {
            dispatch({
                type: AUTHENTCATION_ERRORS,
                payload: err.response.data
            });
        });
}

export const loginUser = (user) => dispatch => {
    if (!user.email) {
        dispatch({
            type: AUTHENTCATION_ERRORS,
            payload: { email: "Email is required" }
        });
        return;
    }
    if (!user.password) {
        dispatch({
            type: AUTHENTCATION_ERRORS,
            payload: { password: "Password is required" }
        });
        return;
    }
    axios.post('/api/Auth/login', user)
        .then(res => {
            const { token } = res.data;
            localStorage.setItem('jwtToken', token);
            setAuthToken(token);
            const decoded = jwt_decode(token);
            dispatch(setCurrentUser(decoded));
        })
        .catch(err => {
            dispatch({
                type: AUTHENTCATION_ERRORS,
                payload: err.response.data
            });
        });
}

export const setCurrentUser = decoded => {
    return {
        type: SET_CURRENT_USER,
        payload: decoded
    }
}

export const logoutUser = (history) => dispatch => {
    localStorage.removeItem('jwtToken');
    setAuthToken(false);
    dispatch(setCurrentUser({}));
    history.push('/login');
}