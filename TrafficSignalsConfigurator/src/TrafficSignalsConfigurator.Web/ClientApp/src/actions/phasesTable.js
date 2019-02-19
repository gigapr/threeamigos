export const CHANGE = 'CHANGE';
export const REMOVE_ROW = 'REMOVE_ROW';
export const ADD_ROW = 'ADD_ROW';
export const REMOVE_SPECIFIC_ROW = 'REMOVE_SPECIFIC_ROW';

export const actionCreators = {         
    change: (index, e) => ({ type: change, index: index, e: e }),
    removeRow: () => ({ type: removeRow }),
    addRow: () => ({ type: addRow }),
    removeSpecificRow: (index) => ({ type: removeSpecificRow, index: index }),
};

export const change = (index, element) => ({
    type: CHANGE,
    index: index, 
    element: element
});

export const removeRow = () => ({
    type: REMOVE_ROW
});

export const addRow = () => ({
    type: ADD_ROW
});

export const removeSpecificRow = (index) => ({
    type: REMOVE_SPECIFIC_ROW,
    index: index
});