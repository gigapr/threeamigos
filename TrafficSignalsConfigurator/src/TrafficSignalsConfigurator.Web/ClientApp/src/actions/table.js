const CHANGE = 'CHANGE';
const REMOVE_ROW = 'REMOVE_ROW';
const ADD_ROW = 'ADD_ROW';
const REMOVE_SPECIFIC_ROW = 'REMOVE_SPECIFIC_ROW';

export { CHANGE, ADD_ROW, REMOVE_ROW, REMOVE_SPECIFIC_ROW };

export const actionCreators = {         
    change: (index, e) => ({ type: change, index: index, e: e }),
    removeRow: () => ({ type: removeRow }),
    addRow: () => ({ type: addRow }),
    removeSpecificRow: (index) => ({ type: removeSpecificRow, index: index }),
};

const change = (index, element) => ({
    type: CHANGE,
    index: index, 
    element: element
})

const removeRow = () => ({
    type: REMOVE_ROW
})

const addRow = () => ({
    type: ADD_ROW
})

const removeSpecificRow = (index) => ({
    type: REMOVE_SPECIFIC_ROW,
    index: index
})

export { change, removeRow, addRow, removeSpecificRow };

