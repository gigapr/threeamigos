import { SET_CURRENT_USER, AUTHENTCATION_ERRORS } from '../actions/authentication';
import isEmpty from '../validation/is-empty';

const initialState = {
    isAuthenticated: false,
    user: {},
    errors: {}
}

export const reducer = (state = initialState, action) => {

    switch (action.type) {
        case SET_CURRENT_USER:
            const newState = {
                ...state,
                isAuthenticated: !isEmpty(action.payload),
                user: action.payload
            };
            return newState;
        case AUTHENTCATION_ERRORS:
            return {
                ...state,
                isAuthenticated: false,
                errors: action.payload
            }
        default:
            return state;
    }
}