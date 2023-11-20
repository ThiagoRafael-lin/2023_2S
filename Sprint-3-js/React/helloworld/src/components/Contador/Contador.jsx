import React, {useState} from "react";
import "./Contador.css";

//<fragment> </fragment> container vazio

const Contador = () => {

    const [Contador, setContador] = useState(0);

    function handleIncrementar() {
        setContador(Contador + 1)
    }

    function handleDecrementar() {
        if (Contador > 0)
        setContador(Contador - 1)
    }



    return (
        
        <>
            <p>{Contador}</p>
            <button onClick={handleIncrementar}>Incrementar</button>

            <button onClick={handleDecrementar}>Decrementar</button>
            
        </>
    );
    
};

export default Contador;