const addRow = 'ADD_ROW';
const removeRow = 'REMOVE_ROW';
const removeSpecificRow = 'REMOVE_SPECIFIC_ROW';
const change = 'CHANGE';

const initialState = {
    rows: [{}]
  };

export const actionCreators = {         
    addRow: () => ({ type: addRow }),
    removeRow: () => ({ type: removeRow }),
    removeSpecificRow: (idx) => ({ type: removeSpecificRow, idx: idx }),
    change: (idx, e) => ({ type: change, idx: idx, e: e }),
};

export const reducer = (state, action) => {
  state = state || initialState;

  if(action.type === change){
    const { name, value } = action.e.target;
    const rows = [...state.rows];
    rows[action.idx] = {
      [name]: value
    };
    
    return { ...state, rows };
  }
  if (action.type === addRow) {
    const item = {
        name: "",
        mobile: ""
      };

    return { ...state, rows: [...state.rows, item] };
  }

  if (action.type === removeRow) {
    return { ...state, 
        rows: state.rows.slice(0, -1)
    };
  } 

  if(action.type === removeSpecificRow){
    const rows = [...state.rows];
    rows.splice(action.idx, 1);

    return { ...state, 
        rows: rows
    };
  }

  return state;
};