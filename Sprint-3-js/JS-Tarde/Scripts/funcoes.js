function calcular() {
    event.preventDefault()

    let n1 = parseFloat(document.getElementById("numero1").value);
    let n2 = parseFloat(document.getElementById("numero2").value);
    let res;//undefined
    let op = document.getElementById("operacao").value;

    if (isNaN(n1) || isNaN(n2)) {
        alert("Preencha todos os campos")

        return;
    }

    if (op == '+') {
        res = somar(n1, n2);
        console.log(`Resultado: ${res}`)
    } else if (op == '-') {
        res = subtrair(n1, n2);
        console.log(`Resultado: ${res}`)
    } else if (op == '*') {
        res = Multiplicar(n1, n2);
        console.log(`Resultado: ${res}`)
    } else if (op == '/') {
        res = Dividir(n1, n2);
        console.log(`Resultado: ${res}`)
    }

    document.getElementById('resultado').innerText = res;

}  //fim da função calcular

//console.log(`Resultado ${res}`);


function somar(x, y) {
    return (x + y).toFixed(2);//number
}

function subtrair(x, y) {
    return (x - y).toFixed(2);//number
}

function Multiplicar(x, y) {
    return (x * y).toFixed(2);//number
}

function Dividir(x, y) {

    if (y == 0) {

        return "Operação Invalida";
    }
    return (x / y).toFixed(2)
}