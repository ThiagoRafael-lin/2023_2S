//Mais usados em arrays
//foreach - tem retorno void
//map - novo array modificado
//filter - retonas um novo array, apenas com elementos que atenderam a uma condição
//reduce - retorna apenas um valor do array

//MAP
// const numeros = [1, 2, 5, 10, 300];
// const dobro = numeros.map( (n) => {
//     return n * 2;
// } );

// console.log(numeros);
// console.log(dobro);


//FILTER
// const numeros = [1, 2, 5, 10, 300];

// const maior10 = numeros.filter((e) => {
    //         return e > 10;
    // });
    
    // console.log(maior10);
    
    
    // const comentarios = [
        //     {comentario: "bla bla bla", exibe: true},
        //     {comentario: "Evento foi uma", exibe: false},
        //     {comentario: "Ótimo evento", exibe: true}
        // ];
        
        // const comentariosOK = comentarios.filter((c) => {
            //     return c.exibe === true;
            // })
            
            // comentariosOK.forEach((c) => {
                //     console.log(c.comentario)
                // });
                
//REDUCE                
        const numeros = [1, 2, 5, 10, 300];
        const soma = numeros.reduce((vlInicial, numero) => {
            return vlInicial + numero
        });         
        console.log(soma);