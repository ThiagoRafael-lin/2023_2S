//lista global
const listaPessoas = [

];

function calcular(e) {
    e.preventDefault()//captura/para o submit do form/página
    
    let nome = document.getElementById("nome").value.trim();//limpa a string
    let altura = parseFloat(document.getElementById("altura").value);//NaN
    let peso = parseFloat(document.getElementById("peso").value);

    //verifica se há algum campo sem preencher
    if (isNaN(altura) || isNaN(peso) || nome.lenght < 2) {
        alert("É necessario preencher todos os campos")
        return;
    }

    const imc = calcularImc(peso, altura);
    const txtsituacao = geraSituacao(imc);

    // console.log(nome);
    // console.log(altura);
    // console.log(peso);
    // console.log(imc);
    // console.log(situacao);

    //object short sintaxe
    const pessoa = {//objeto literal
        //PROPRIEDADE: VALOR 
        nome, //o nome da variavel é o mesmo nome da propriedade 
        altura,
        peso,
        imc: imc,
        situacao: txtsituacao //o nome da variavel não é o mesmo nome da propriedade
    }

    //insere uma pessoa no array
    listaPessoas.push(pessoa);

    //exibir os dados
    exibirDados();
    limparFormulario();
    //limpar os campos do formulario
function limparFormulario(){

    document.getElementById("nome").value = ""
    document.getElementById("altura").value = ""
    document.getElementById("peso").value = ""
}
}//fim da função calcular

function calcularImc(peso, altura) {
    return peso / (altura * altura);
    //return peso / Math.pow(altura, 2); //outro exemplo

}

function geraSituacao(imc) {
    if (imc < 18.5) {
        return "Magreza severa";
    }
    else if (imc <= 24.99) {
        return "Peso normal";
    }
    else if (imc <= 29.99) {
        return "Acima do peso";
    }
    else if (imc <= 34.99) {
        return "Obsidade I";
    }
    else if (imc <= 39.99) {
        return "Obsidade II";
    } else {
        return "Cuidado!!!"
    }
}//fim da função geraSituação

function exibirDados() {
    console.log(listaPessoas);

    //listar pessoas no console
    let linhas = '';
    listaPessoas.forEach(function (oPessoa) {
        //linhas de tabela
        linhas += `
         <tr>
          <td>${oPessoa.nome}</td>
          <td>${oPessoa.altura}</td>
          <td>${oPessoa.peso}</td>
          <td>${oPessoa.imc.toFixed(2)}</td>
          <td>${oPessoa.situacao}</td>
        </tr>
        `;
    });

    //inserir as linhas de tabela no html
    document.getElementById('cadastro').innerHTML = linhas;
};