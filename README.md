# parcelamento
Teste de Avaliação do Jean Silva para a empresa Ctis.
Caminho da aplicação do Postman
http://localhost:port/api/cadastro/CadastrarDados

Padrao do dados a ser enviados
{
"numeroParcelas": 10,
"Datas": "01/01/2018",
"valorTotalCredito":10000.00
}

O Valor total de crédito deve ser nesse formato acima com ponto antes das duas casas decimais e se o valor for acima de mil reais 
não colocar pontos.A data deve ser no formato dd/mm/yyyy e número de parcela em inteiro.
Utiize o metodo post no Postman e selecionar o radionbutton raw para escrever o comando de envio selecionando a opção JSON(application/json) e logo embaixo acompanhar o resultado do post na aba body.
