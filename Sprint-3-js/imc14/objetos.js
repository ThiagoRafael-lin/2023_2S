let thiago = { 
    nome : "Thiago",
    idade : 18,
    altura : 1.72
}; //objeto literal

let carlos = new Object();
 carlos.nome = "Carlos";
 carlos.idade = 40;

// console.log(thiago);
// console.log(carlos);

const sacola = new Object();
sacola.itens = [];//lista/array

sacola.guardarItem = function(item) {//método
    this.itens.push(item);
};

sacola.guardarItem("Banana");

console.log(sacola.itens);