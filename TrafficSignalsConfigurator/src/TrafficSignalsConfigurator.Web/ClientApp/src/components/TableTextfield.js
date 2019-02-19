import React from 'react';

const TableTextfield = ({name, value, onChange, style}) => (
  
    <input type="text" 
           name={name}
           value={value}
           onChange={onChange} 
           className="form-control"
           style={style}  />
);

export default TableTextfield;