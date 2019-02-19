import { combineReducers } from 'redux';
import * as PhasesTable from './phasesTable';
import * as errorReducer from './errorReducer';
import phaseTable from './phasesTable';
import authReducer from './authReducer';
// import * as Counter from './counter';
// import * as WeatherForecasts from './WeatherForecasts';
import { routerReducer, routerMiddleware } from 'react-router-redux';

const reducers = {
    // counter: Counter.reducer,
    // weatherForecasts: WeatherForecasts.reducer,
    phasesTable: PhasesTable.reducer,
    errors: errorReducer.reducer,
    auth: authReducer
  };


export default combineReducers({
    ...reducers,
    routing: routerReducer
  });