import { SET_CURRENT_USER, GET_ERRORS } from '../actions/authentication';
import isEmpty from '../validation/is-empty';

const initialState = {
    isAuthenticated: false,
    user: {},
    errors: {}
}

export const reducer = (state, action) => {

    state = state || initialState;

    switch (action.type) {
        case SET_CURRENT_USER:
            return {
                ...state,
                isAuthenticated: !isEmpty(action.payload),
                user: action.payload
            }
        case GET_ERRORS:
            return action.payload;
        default:
            return state;
    }
}