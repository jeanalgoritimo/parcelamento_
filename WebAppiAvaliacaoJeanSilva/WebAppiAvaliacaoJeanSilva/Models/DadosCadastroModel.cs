using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace WebAppiAvaliacaoJeanSilva.Models
{
    public class DadosCadastroModel
    {
        private int numeroParcelas_;
        private decimal valorTotalCredito_;
        private decimal valorSaldoAtualizado_;
        private int numero_;
        private decimal calculo;
        private string Data;
        private decimal _valorSaldoRemanescente;
        private decimal _valorCorrecao;

        public DadosCadastroModel(int _numero,
                                   string Data_,
                                   decimal _valorTotalCredito,
                                   decimal _valorSaldoAtualizado,
                                   decimal calculo_,
                                   decimal valorSaldoRemanescente_,
                                   decimal valorCorrecao_,
                                   int _numeroParcelas)
                                   

        {
            this.numeroParcelas = _numeroParcelas;
            this.valorTotalCredito = decimal.Round(_valorTotalCredito,2);
            this.ValorSaldoAtualizado = decimal.Round(_valorSaldoAtualizado, 2);
            this.Datas = Data_;
            this.numero = _numero;
            this.calculo = decimal.Round(calculo_, 2);
            this.valorSaldoRemanescente = decimal.Round(valorSaldoRemanescente_,2);
            this.valorCorrecao = decimal.Round(valorCorrecao_,2);
        }

        public int numero
        {
            get
            {
                return numero_;
            }

            set
            {
                numero_ = value;
            }
        }

        public string Datas
        {
            get
            {
                return Data;
            }

            set
            {
                Data = value;
            }
        }

        public decimal valorTotalCredito
        {
            get
            {
                return valorTotalCredito_;
            }

            set
            {
                valorTotalCredito_ = value;
            }
        }

        public decimal ValorSaldoAtualizado
        {
            get
            {
                return valorSaldoAtualizado_;
            }

            set
            {
                valorSaldoAtualizado_ = value;
            }
        }

        public decimal ValorParcela
        {
            get
            {
                return calculo;
            }

            set
            {
                calculo = value;
            }
        }

        public decimal valorSaldoRemanescente
        {
            get
            {
                return _valorSaldoRemanescente;
            }

            set
            {
                _valorSaldoRemanescente = value;
            }
        }

        public decimal valorCorrecao
        {
            get
            {
                return _valorCorrecao;
            }

            set
            {
                _valorCorrecao = value;
            }
        }

        public int numeroParcelas
        {
            get
            {
                return numeroParcelas_;
            }

            set
            {
                numeroParcelas_ = value;
            }
        }

    }
}