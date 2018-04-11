using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppiAvaliacaoJeanSilva.Models;


namespace WebAppiAvaliacaoJeanSilva.Controllers
{
    [RoutePrefix("api/cadastro")]
    public class CadastroDadosController : ApiController
    {
        private bool parcelaValorParcela;
        private bool retornoMensagem;
        private string mensagemRetorno = "";

        private string numeroParcelas;
        private string valorTotalCredito;
  
        List<DadosCadastroModel> _listaCalculo = new List<DadosCadastroModel>();
        private CalculoParcelas calculos = new CalculoParcelas();

       
        private static List<DadosCadastroModel> listaCadastros = new List<DadosCadastroModel>();

        [AcceptVerbs("GET","POST")]
        [Route("CadastrarDados")]
        public IEnumerable CadastrarDados(DadosCadastroModel Dados)
        {

            retornoMensagem = VerificarParcelas(Dados);

            if (retornoMensagem != false)
            {
                retornoMensagem=FormatarMensagem(Dados);

                if (retornoMensagem != false)
                {

                    return calculos.listaCalculo.ToList(); 
                }
                else
                {
                    return mensagemRetorno;
                }        
            }
            else
            {
               return mensagemRetorno;
            }
          
            
        }

        private bool VerificarParcelas(DadosCadastroModel Dados)
        {
            if (Dados.numeroParcelas < 2 || Dados.numeroParcelas > 60)
            {
                parcelaValorParcela = false;
                if (Dados.numeroParcelas < 2)
                {
                    mensagemRetorno = "Parcela não pode ser inferior à 2";
                }
                else
                {
                    mensagemRetorno = "Parcela não pode ser superior à 60";
                }
                 
            }
            else
            {
                parcelaValorParcela = true;
            }
            return parcelaValorParcela;
        }
        private bool FormatarMensagem(DadosCadastroModel Dados)
        {
            retornoMensagem = calculos.RetornoCalculoParcelas(Dados);
            if (retornoMensagem != true)
            {
                mensagemRetorno = calculos.mensagemErroparcelas;
            }
           
            return retornoMensagem;

           

           
        }


    }
}
