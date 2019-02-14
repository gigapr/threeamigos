import { CHANGE, REMOVE_ROW, ADD_ROW, REMOVE_SPECIFIC_ROW } from "../actions/table";

const initialState = {
    rows: [{}]
};

export const reducer = (state, action) => {
    state = state || initialState;
  
    if(action.type === CHANGE){
      const { name, value } = action.element;
      const rows = [...state.rows];
      rows[action.index] = {
        [name]: value
      };
      
      return { ...state, rows };
    }
    if (action.type === ADD_ROW) {
      const item = {
          name: "",
          mobile: ""
        };
  
      return { ...state, rows: [...state.rows, item] };
    }
  
    if (action.type === REMOVE_ROW) {
      return { ...state, 
          rows: state.rows.slice(0, -1)
      };
    } 
  
    if(action.type === REMOVE_SPECIFIC_ROW){
      const rows = [...state.rows];
      rows.splice(action.index, 1);
  
      return { ...state, 
          rows: rows
      };
    }
  
    return state;
  };
