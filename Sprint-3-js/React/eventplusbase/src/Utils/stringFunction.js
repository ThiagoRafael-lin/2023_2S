/**
 * função que inverte a data do banco de dados
 * @param {*} data 
 * @returns 
 */

export const dateFormatDdToView  = data => {
    data = data.substr(0, 10);//retorna apenas a data
    data = data.split("-");
    return `${data[2]}/${data[1]}/${data[0]}`;
}

