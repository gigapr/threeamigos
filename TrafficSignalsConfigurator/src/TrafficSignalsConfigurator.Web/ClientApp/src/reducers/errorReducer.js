import { GET_ERRORS } from '../actions/authentication';

const initialState = {};

export const reducer = (state, action) => {

    state = state || initialState;

    switch(action.type) {
        case GET_ERRORS:
            return action.payload;
        default: 
            return state;
    }
 };