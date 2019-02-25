import React from 'react';

const inputStyle = {
    width: '2em',
    textAlign: 'center'
};

const PhasesConflictsTable = ({phasesConflicts}) => (
    <div>
        {phasesConflicts.length > 0 ? <h2>Phase Conflicts</h2> : null}
        <table>
            <tbody>
                {
                    phasesConflicts.map((item, idx) => (
                        <tr key={idx}>
                            {item.map((inner, innerIndex) => (
                                <td>
                                    <input style={inputStyle} value={item[innerIndex]}/>
                                </td>
                            ))}
                        </tr>
                    ))}
            </tbody>
        </table>
    </div>
);


export default PhasesConflictsTable;