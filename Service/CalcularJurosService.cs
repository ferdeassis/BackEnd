using System;
using ORM.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class CalcularJurosService : ICalcularJurosService
    {
        private readonly IPropostaService _propostaService;
        private readonly IParametroRepository _parametroRepository;
        public CalcularJurosService(IPropostaService propostaService, IParametroRepository parametroRepository)
        {
            _propostaService = propostaService;
            _parametroRepository = parametroRepository;
        }
        public decimal CalcularJuros(int prazo, decimal Vlr_Solicitado)
        {
            _propostaService.ValidarPrazo(prazo);
            var juros = (_parametroRepository.GetParametro().Juro_Composto) / 100;
            var calculoJuros = Convert.ToDouble(Vlr_Solicitado) * Math.Pow(1 + Convert.ToDouble(juros), prazo);
            return (decimal)calculoJuros;
        }
    }
}