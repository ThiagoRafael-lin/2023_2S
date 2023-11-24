import React from "react";
import "./NextEvent.css";
import { dateFormatDdToView } from "../../Utils/stringFunction";
import { Tooltip } from "react-tooltip";

//dateFormatDdToView(eventDate)

const NextEvent = ({ title, description, eventDate, idEvento }) => {
  function conectar(idEvento) {
    alert(`conectando ao evento ${idEvento}`);
  }
  return (
    <article className="event-card">
      <h2 className="event-card__title">{title}</h2>

      <p
        className="event-card__description"
        data-tooltip-id={idEvento}
        data-tooltip-content={description}
        data-tooltip-place="top"
      >
        <Tooltip id={idEvento} className="tootip" />
        {description.substr(0, 16)}...
      </p>
      <p className="event-card__description">
        {new Date(eventDate).toLocaleDateString()}
      </p>

      <a
        onClick={() => {
          conectar(idEvento);
        }}
        href=""
        className="event-card__connect-link"
      >
        Conectar
      </a>
    </article>
  );
};

export default NextEvent;
