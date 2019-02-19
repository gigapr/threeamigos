import { applyMiddleware, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerMiddleware } from 'react-router-redux';
import combineReducers from '../reducers/index'

export default function configureStore(history, initialState) {
  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  return createStore(
    combineReducers,
    initialState,
    compose(applyMiddleware(...middleware),
      window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()));

}
