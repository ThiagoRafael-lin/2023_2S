let thiago = {
    nome: "Thiago",
    idade: 18,
    alura: 1.73
}; //classe

thiago.peso = 73;

let bigas = new Object();

finas.nome = "finas"
finas.idade = 18;
finas.sobrenome = "Rafael";

let pessoas = [];
//let pessoas2 = new array

pessoas.push(thiago, bigas);
pessoas.push(thiago);

console.log(thiago);
console.log(bigas);
console.log(pessoas);

pessoas.forEach((v, i) => { //Função anonima
    console.log(`Nome${i = 1}: ${v.nome}`);
})
