import React from 'react';
import { connect } from 'react-redux';
import { addRow, removeRow, removeSpecificRow, change } from "../actions/phasesTable";
import TableTextfield from "./TableTextfield";
import PhasesConflictsTable from "./PhasesConflictsTable";

const PhasesTable = props => (
  <div>
    <div className="container">
      <div className="row clearfix">
        <div className="col-md-12 column">
          <h2>Phases</h2>
          <table className="table table-bordered table-hover" id="tab_logic">
            <thead>
              <tr>
                <th className="text-center"> Id </th>
                <th className="text-center"> Type </th>
                <th className="text-center">Minimum Green</th>
                <th />
              </tr>
            </thead>
            <tbody>
              {props.rows.map((item, idx) => (
                <tr id="addr0" key={idx}>
                   <td>
                    <TableTextfield name="id" value={item.id} onChange={(e) => props.change(idx, e.target)}/>
                  </td>
                  <td>
                    <TableTextfield name="type" value={item.type} onChange={(e) => props.change(idx, e.target)}/>
                  </td>
                  <td>
                    <TableTextfield name="minimumGreen" value={item.minimumGreen} onChange={(e) => props.change(idx, e.target)}/>
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
          <button onClick={props.addRow} className="btn btn-primary">Add Row</button>
          <button onClick={props.removeRow} className="btn btn-danger">Delete Last Row</button>
        </div>
        <div className="col-md-12 column">
          <PhasesConflictsTable phasesConflicts={props.phasesConflicts}/>
        </div>
      </div>
    </div>
  </div>
);

const mapStateToProps = state => {
  return {
    rows: state.phasesTable.rows,
    phasesConflicts: state.phasesTable.phasesConflicts
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

export default connect(mapStateToProps, mapDispatchToProps)(PhasesTable);