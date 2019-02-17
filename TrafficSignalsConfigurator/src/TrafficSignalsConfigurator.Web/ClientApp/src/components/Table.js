import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { addRow,  removeRow, removeSpecificRow, change } from "../actions/table";

const inputStyle = {
  width: '2em'
};

const Table = props => (
    <div>
    <div className="container">
      <div className="row clearfix">
        <div className="col-md-12 column">
          <table
            className="table table-bordered table-hover"
            id="tab_logic">
            <thead>
              <tr>
                <th className="text-center"> # </th>
                <th className="text-center"> Name </th>
                <th className="text-center"> Mobile </th>
                <th />
              </tr>
            </thead>
            <tbody>
              {props.rows.map((item, idx) => (
                <tr id="addr0" key={idx}>
                  <td>{idx}</td>
                  <td>
                    <input
                      type="text"
                      name="name"
                      value={props.rows[idx].name}
                      onChange={(e) => props.change(idx, e.target)}
                      className="form-control"
                    />
                  </td>
                  <td>
                    <input
                      type="text"
                      name="mobile"
                      value={props.rows[idx].mobile}
                      onChange={(e) => props.change(idx, e.target)}
                      className="form-control"
                    />
                  </td>
                  <td>
                    <button
                      className="btn btn-outline-danger btn-sm"
                      onClick={() => props.removeSpecificRow(idx)}>
                      Remove
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <button onClick={props.addRow} className="btn btn-primary">
            Add Row
          </button>
          <button
            onClick={props.removeRow}
            className="btn btn-danger float-right">
            Delete Last Row
          </button>
        </div>
      </div>
    </div>
    <table>
      <br></br>
    <tbody>
        {
          props.phasesConflicts.map((item, idx) => (
            <tr>
              {item.map((inner, innerIndex) => (
              <td>
                <input style={inputStyle} value={item[innerIndex]}
                />
              </td>
              ))}
            </tr>
        ))}
      </tbody>
    </table>
  </div>
);

const mapStateToProps = state => {
  return {
    rows: state.table.rows,
    phasesConflicts: state.table.phasesConflicts
  };
};

const mapDispatchToProps = dispatch => {
  return {
    addRow: () => dispatch(addRow()),
    removeRow: () => dispatch(removeRow()),
    removeSpecificRow: (idx) => dispatch(removeSpecificRow(idx)),
    change: (idx, e) => dispatch(change(idx, e)),
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Table);