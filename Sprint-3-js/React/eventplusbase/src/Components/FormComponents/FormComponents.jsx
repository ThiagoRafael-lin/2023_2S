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


const options = [
    {
      value: "53f955fd-5d4a-421f-a384-22d4ab4f69f3",
      text: "Evento Comemorativo",
    },
    {
      value: "3ea9d879-683c-41b5-8ed8-7a02d5487be9",
      text: "Festa do Sábias Palavras",
    },
  ];

export const Select = ({
  dados = [],
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
      {dados.map((opt) => {
        return <option value={opt.value}>{opt.text}</option>;
      })}
    </select>
  );
};
