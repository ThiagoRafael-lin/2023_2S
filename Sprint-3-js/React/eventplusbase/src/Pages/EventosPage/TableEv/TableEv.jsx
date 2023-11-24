import React from 'react';
import "./TableEv.css";

import editPen from "../../../assets/images/edit-pen.svg";
import trashDelete from "../../../assets/images/trash-delete.svg";
import { Tooltip } from 'react-tooltip';

const TableEv = ({ dados, fnUpdate, fnDelete }) => {
  console.log(dados);

  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Descrição
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Tipo Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Data
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

        {dados.map((Ev) => {
          return (

            <tr className="table-data__head-row">

              <td className="table-data__data table-data__data--big">
                {Ev.nomeEvento}
              </td>

              <td className="table-data__data table-data__data--little">
                <p
                data-tooltip-id={Ev.idEvento}
                data-tooltip-content={Ev.descricao}
                data-tooltip-place="top"
                >
                <Tooltip id={Ev.idEvento} className="tootip" />
                {Ev.descricao.substr(0, 15)}...
                </p>
                

              </td>

              <td className="table-data__data table-data__data--little">
                {Ev.tiposEvento.titulo}
              </td>

              <td className="table-data__data table-data__data--little">

                {new Date(Ev.dataEvento).toLocaleDateString()}
              </td>

              <td className="table-data__data table-data__data--little">
                <img
                  onClick={() => {
                    fnUpdate(Ev.idEvento);
                  }}
                  className="table-data__icon"
                  src={editPen}
                  alt="Icone de Atualizar"
                />
              </td>

              <td className="table-data__data table-data__data--little">
                <img
                  onClick={() => {
                    fnDelete(Ev.idEvento);
                  }}
                  className="table-data__icon"
                  src={trashDelete}
                  alt="Icone de Deletar"
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