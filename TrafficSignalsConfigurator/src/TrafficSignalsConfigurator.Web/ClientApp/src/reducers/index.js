import { combineReducers } from 'redux';
import * as phasesTable from './phasesTable';
import * as authentication from './authentication';
import * as counter from './counter';
import * as weatherForecasts from './weatherForecasts';
import { routerReducer } from 'react-router-redux';

const reducers = {
    counter: counter.reducer,
    weatherForecasts: weatherForecasts.reducer,
    phasesTable: phasesTable.reducer,
    auth: authentication.reducer
  };


export default combineReducers({
    ...reducers,
    routing: routerReducer
  });