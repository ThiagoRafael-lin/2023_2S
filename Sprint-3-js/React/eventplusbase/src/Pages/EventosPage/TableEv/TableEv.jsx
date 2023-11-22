import React from 'react';
import "./TableEv.css";

import editPen from "../../../assets/images/edit-pen.svg";
import trashDelete from "../../../assets/images/trash-delete.svg";


const TableEv = ({ dados, fnUpdate, fnDelete}) => {
    console.log(dados);
    return (
        <table className="table-data">
        <thead className="table-data__head">
          <tr className="table-data__head-row">
            <th className="table-data__head-title table-data__head-title--big">
              Título
            </th>
            <th className="table-data__head-title table-data__head-title--little">
              Editar
            </th>
            <th className="table-data__head-title table-data__head-title--little">
              Deletar
            </th>
          </tr>
        </thead>
  
        <tbody>
          {/* mapa dos dados */}
  
          {dados?.map((Ev) => {
            return (
              <tr className="table-data__head-row">
                <td className="table-data__data table-data__data--big">
                  {Ev.titulo}
                </td>
  
                <td className="table-data__data table-data__data--little">
                  <img
                    className="table-data__icon"
                    src={editPen}
                    alt="icone de editar"
                    onClick={() => {
                      fnUpdate(Ev.idTipoEvento);
                    }}
                  />
                </td>
  
                <td className="table-data__data table-data__data--little">
                  <img
                    className="table-data__icon"
                    src={trashDelete}
                    alt="Icone de Deletar"
                    onClick={() => {
                      fnDelete(Ev.idTipoEvento);
                    }}
                  />
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
    );
};

export default TableEv;