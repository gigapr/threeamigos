import { combineReducers } from 'redux';
import * as phasesTable from './phasesTable';
import * as authentication from './authentication';
import { routerReducer } from 'react-router-redux';

const reducers = {
  phasesTable: phasesTable.reducer,
  auth: authentication.reducer
};

export default combineReducers({
  ...reducers,
  routing: routerReducer
});