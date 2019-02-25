import { CHANGE, REMOVE_ROW, ADD_ROW, REMOVE_SPECIFIC_ROW } from "../actions/phasesTable";

const initialState = {
  rows: [{}],
  phasesConflicts: []
};

export const reducer = (state = initialState, action) => {

  switch (action.type) {
    case CHANGE: {
      const { name, value } = action.element;
      const rows = [...state.rows];   
      rows[action.index] = {
        [name]: value
      };
      return { ...state, rows };
    }
    case ADD_ROW: {
      const item = {
        id: "",
        type: "",
        minimumGreen: ""
      };

      const rows = [...state.rows, item];

      const phasesConflict = [];

      for (var i = 0; i < rows.length; i++) {
        var ar = [];
        for (var l = 0; l < rows.length; l++) {
          ar.push('');
        }
        phasesConflict.push(ar);
      }

      var count = 0;
      for (var m = 0; m < phasesConflict.length; m++) {
        for (var n = 0; n < rows.length; n++) {
          if (n === count) {
            var r= phasesConflict[m];
            r[n] = 'X';
            count++;
            break;
          }
        }
      }

      return { ...state, rows: rows, phasesConflicts: phasesConflict };
    }
    case REMOVE_ROW: {
      return {
        ...state,
        rows: state.rows.slice(0, -1)
      };
    }

    case REMOVE_SPECIFIC_ROW: {
      const rows = [...state.rows];
      rows.splice(action.index, 1);

      return {
        ...state,
        rows: rows
      };
    }

    default:
      return state;
  }
}
