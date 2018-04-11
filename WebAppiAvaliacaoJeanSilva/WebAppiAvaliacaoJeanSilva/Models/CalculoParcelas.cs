using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebAppiAvaliacaoJeanSilva.Models
{
    public class CalculoParcelas
    {
        public List<DadosCadastroModel> listaCalculo = new List<DadosCadastroModel>();
        public List<DadosCadastroModel> listaResumo = new List<DadosCadastroModel>();
        private decimal calculo = 0.00M, calculoAux = 0.00M, valorTotalCreditoAux = 0.00M,
                valorAtualizado = 0.00M, valorAtualizadoAux = 0.00M, valorRemanescente = 0.00M,calculoadd = 0.00M;
        private int Parcelas;
        private string Data;
        private DateTime DataAux;
        public bool Statusparcelas;
        public string mensagemErroparcelas;


        public bool RetornoCalculoParcelas(DadosCadastroModel Dados)
        {
            Parcelas = Dados.numeroParcelas;
            for (int i = 0; i < Parcelas; i++)
            {
                if (i == 0)
                {
                    calculo = decimal.Round(Dados.valorTotalCredito / Dados.numeroParcelas , 2);
                    calculoAux = calculo;
                    valorRemanescente = Dados.valorTotalCredito - calculo;
                    Dados.numeroParcelas = Dados.numeroParcelas - 1;
                    Dados.numero =  1;
                    VerifcarValoresParcelas(Dados);
                    if (Statusparcelas == false)
                    {
                        break;
                    }
                    listaCalculo.Add(new DadosCadastroModel(Dados.numero,Dados.Datas,Dados.valorTotalCredito,Dados.valorTotalCredito,calculo,valorRemanescente,Dados.valorCorrecao,Dados.numeroParcelas));
                    valorTotalCreditoAux = Dados.valorTotalCredito;
                }
                else 
                {
                    valorAtualizadoAux = ((valorTotalCreditoAux - calculoAux) * 1)/100 ;
                    valorAtualizado = valorAtualizadoAux + (valorTotalCreditoAux - calculoAux);
                    calculo = decimal.Round(valorAtualizadoAux / Dados.numeroParcelas , 2);
                    calculoadd = calculoadd + calculo;
                    Dados.valorCorrecao = calculoadd;
                    calculo = calculo + calculoAux;
                    calculoAux = calculo;
                
                    valorRemanescente = valorAtualizado - calculo;
                    Dados.numeroParcelas = Dados.numeroParcelas - 1;
                    Dados.numero = Dados.numero + 1;
                    valorTotalCreditoAux = valorAtualizado;

                    Data = Dados.Datas;
                    var DataArra = DateTime.Parse(Data);
                    for (int d = 0; d <= i; d++)
                       DataAux=DataArra.AddMonths(d);
                       Data = DataAux.ToString("dd/MM/yyyy");

                    VerifcarValoresParcelas(Dados);
                    if (Statusparcelas == false)
                    {
                        break;
                    }
                    listaCalculo.Add(new DadosCadastroModel(Dados.numero,Data,Dados.valorTotalCredito,valorAtualizado,calculo,valorRemanescente,Dados.valorCorrecao,Dados.numeroParcelas));
                }
                
            }
                 
            return Statusparcelas;
        }
        private bool VerifcarValoresParcelas(DadosCadastroModel Dados)
        {
           if (Dados.valorTotalCredito > 2000 && calculo < 200)
            {
                mensagemErroparcelas = "Valores das Parcelas para esse Crédito " + Dados.valorTotalCredito +" não pode ser inferior a R$ 200 por parcela";
                Statusparcelas = false;
            }
            else if (Dados.valorTotalCredito <= 2000 && calculo < 50)
            {
                mensagemErroparcelas = "Valores das Parcelas para esse Crédito " + Dados.valorTotalCredito + " não pode ser inferior a R$ 50 por parcela";
                Statusparcelas = false;
            }else
            {
                Statusparcelas = true;
            }
              return Statusparcelas;
        }
    }
}