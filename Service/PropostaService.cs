using System;
using System.Collections.Generic;
using Entities;
using ORM.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class PropostaService : IPropostaService
    {
        private IPropostaRepository _propostaRepository;
        private IParametroRepository _parametroRepository;
        //private ICalcularJurosService _calcularJuros;
        public PropostaService(IPropostaRepository propostaRepository, IParametroRepository parametroRepository)
        {
            _propostaRepository = propostaRepository;
            _parametroRepository = parametroRepository;
        }
        public void Add(Propostas obj)
        {
            try
            {
                if (obj.Prazo == 0 || obj.Prazo > 100)
                    throw new Exception("Prazo Inváilido");
                if (obj.Situacao == null)
                    throw new Exception("Situação Inváilida");
                if (obj.Vlr_Solicitado == 0)
                    throw new Exception("Valor Solicitado Inváilido");
                if (obj.Cpf == null)
                    throw new Exception("CPF Inváilido");
                CalcularJuros(obj.Prazo, obj.Vlr_Solicitado);

            }
            catch (Exception e)
            {
                throw e;
            }
            _propostaRepository.Add(obj);
        }
        public Propostas GetCpf(string cpf)
        {
            try
            {
                if (cpf == "undefined")
                {
                    throw new System.Exception("Cpf não informado");
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return _propostaRepository.GetCpf(cpf);
        }

        public void Update(Propostas obj)
        {
            _propostaRepository.Update(obj);
        }

        public void ValidarPrazo(int prazo)
        {
            if (prazo < 1 || prazo > 99)
                throw new ArgumentException("Prazo inválido");
        }

        public decimal CalcularJuros(int prazo, decimal Vlr_Solicitado)
        {
            ValidarPrazo(prazo);
            var juros = (_parametroRepository.GetParametro().Juro_Composto) / 100;
            var calculoJuros = Convert.ToDouble(Vlr_Solicitado) * Math.Pow(1 + Convert.ToDouble(juros), prazo);
            return (decimal)calculoJuros;
        }
    }
}