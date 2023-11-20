import React, { useEffect, useState } from "react";

const TestePage = () => {
  const [count, setCount] = useState(10);
  const [calculation, setCalculation] = useState(10);

    useEffect (() => { //a primeira função vai ser a que o useEffect vai executar
        setCalculation(count * 2);
    },[count]);// na dependencia é quando a função vai ser executado
    
  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={() => setCount((c) => c + 1)}>+</button>
      <p>Calculation: {calculation}</p>
    </div>
  );
};

export default TestePage;
