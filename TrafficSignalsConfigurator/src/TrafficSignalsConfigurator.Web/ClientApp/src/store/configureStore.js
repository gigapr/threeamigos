import { applyMiddleware, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerMiddleware } from 'react-router-redux';
import combineReducers from '../reducers/index'

export default function configureStore(history, initialState) {
  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  const stateLoader = new StateLoader();

  var store = createStore(
    combineReducers,
    stateLoader.loadState(),
    compose(applyMiddleware(...middleware),
      window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()));

      store.subscribe(() => {
        stateLoader.saveState(store.getState());
    });

    return store;
}

class StateLoader {

  loadState() {
      try {
          let serializedState = localStorage.getItem("TrafficSignalsConfigurator");

          if (serializedState === null) {
              return this.initializeState();
          }

          return JSON.parse(serializedState);
      }
      catch (err) {
          return this.initializeState();
      }
  }

  saveState(state) {
      try {
          let serializedState = JSON.stringify(state);
          localStorage.setItem("TrafficSignalsConfigurator", serializedState);

      }
      catch (err) {
      }
  }

  initializeState() {
      return {
            //state object
          }
      };
  }