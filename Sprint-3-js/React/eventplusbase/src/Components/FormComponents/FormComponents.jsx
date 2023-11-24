import React from "react";
import "./FormComponents.css";

export const Input = ({
  type,
  id,
  required,
  additionalClass,
  name,
  placeholder,
  manipulationFunction,
  value,
}) => {
  return (
    <input
      type={type}
      id={id}
      name={name}
      value={value}
      required={required}
      className={`input-component ${additionalClass}`}
      placeholder={placeholder}
      onChange={manipulationFunction}
      autoComplete="off"
    />
  );
};

export const Button = ({
  id,
  name,
  type,
  additionalClass = "",
  manipulationFunction,
  textButton,
}) => {
  return (
    <button
      type={type}
      name={name}
      id={id}
      className={`button-component ${additionalClass}`}
      textButton={textButton}
      // onClick={manipulationFunction}
    >
      {textButton}
    </button>
  );
};

export const Select = ({
  tipoEventos = [],
  id,
  name,
  required,
  additionalClass = "",
  manipulationFunction,
  defaultvalue
}) => {
  return (
    <select 
    id={id}
    name={name}
    required={required}
    className={`input-component ${additionalClass}`}
    onChange={manipulationFunction}
    value={defaultvalue}
    > 
      <option value="">Selecione</option>
      {tipoEventos.map((tp) => {
        return <option value={tp.idTipoEvento}>{tp.titulo}</option>;
      })}
    </select>
  );
};
