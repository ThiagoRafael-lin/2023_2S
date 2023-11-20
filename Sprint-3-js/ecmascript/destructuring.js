const camisaLacoste = {
    descricao: "Camisa Lacoste",
    preco: 399.98,
    marca: "Lacoste",
    tamanho: "G",
    cor: "Azul",
    promo: true 
}

// const descricao = camisaLacoste.descricao;
// const preco = camisaLacoste.preco; 

const {descricao, preco, promo} = camisaLacoste;// versão simplificada



// console.log(`
//     Produto: ${descricao}
//     preco: R$${preco}    
//     promoção: ${promo ? "sim" : "não"}     
// `);

const evento = {
    dataEvento: "10-03-2024",
    descricaoEvento: "traga bebida!",
    titulo: "Sun Shine",
    presenca: true,
    comentarioEvento: "A melhor festa..."
}

const {dataEvento, descricaoEvento, titulo, presenca, comentarioEvento} = evento; //destruturação

console.log(`
    Data: ${dataEvento}
    Descrição: ${descricaoEvento}
    Titulo: ${titulo}
    Presença: ${presenca ? "Irei" : "Não Irei"}
    Comentario: ${comentarioEvento}

`);