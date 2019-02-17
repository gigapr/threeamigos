import { CHANGE, REMOVE_ROW, ADD_ROW, REMOVE_SPECIFIC_ROW } from "../actions/phasesTable";

const initialState = {
    rows: [{}],
    phasesConflicts:[]
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
          id: "",
          type: "",
          minimumGreen: ""
      };
      
      const rows = [...state.rows, item];
      
      const phasesConflict = [];
    
      for(var i = 0; i< rows.length; i++){
        var ar = [];
        for(var l = 0; l< rows.length; l++){
            ar.push('');
        }
        phasesConflict.push(ar);
      }

      var count = 0;
      for(var i = 0; i< phasesConflict.length; i++){
        for(var l = 0; l< rows.length; l++){
          if(l == count){
            var m =phasesConflict[i];
            m[l] = 'X';
            count++;
            break;
          }
        }
      }

      return { ...state, rows: rows, phasesConflicts: phasesConflict };
    }
  
    if (action.type === REMOVE_ROW) {
      return { ...state, 
          rows: state.rows.slice(0, -1)
      };
    } 
  
    if(action.type === REMOVE_SPECIFIC_ROW){
      const rows = [...state.rows];
      rows.splice(action.index, 1);

      return { 
          ...state, 
          rows: rows
      };
    }

    return state;
  };
