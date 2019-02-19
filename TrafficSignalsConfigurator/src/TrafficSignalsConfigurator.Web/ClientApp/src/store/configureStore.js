import { applyMiddleware, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
// import * as Counter from './counter';
import * as WeatherForecasts from './WeatherForecasts';
import * as PhasesTable from '../reducers/phasesTable';
import combineReducers from '../reducers/index'

export default function configureStore(history, initialState) {
  // const reducers = {
  //   counter: Counter.reducer,
  //   weatherForecasts: WeatherForecasts.reducer,
  //   phasesTable: PhasesTable.reducer,

  // };

  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  // const isDevelopment = process.env.NODE_ENV === 'development';
  // if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
  //   enhancers.push(window.devToolsExtension());
  // }

  // const rootReducer = combineReducers({
  //   ...reducers,
  //   routing: routerReducer
  // });

  // return createStore(
  //   combineReducers,
  //   initialState,
  //   compose(applyMiddleware(...middleware), ...enhancers)
  // );

// const inititalState = {};

return createStore(
  combineReducers, 
        initialState, 
        compose(applyMiddleware(thunk), 
                window.__REDUX_DEVTOOLS_EXTENSION__&& window.__REDUX_DEVTOOLS_EXTENSION__()));

}
