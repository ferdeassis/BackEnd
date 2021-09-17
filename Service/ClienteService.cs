using System;
using Entities;
using ORM.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public void Add(Cliente obj)
        {
            if (obj.Logradouro == null)
                throw new Exception("Logradouro Inváilido");
            if (obj.Nome == null)
                throw new Exception("Nome Inváilido");
            if (obj.Numero_Residencia == null)
                throw new Exception("Residencia Inváilida");
            if (obj.Vlr_Salario == 0)
                throw new Exception("Salário Inváilido");
            if (obj.Bairro == null)
                throw new Exception("Bairro Inváilido");
            if (obj.Cidade == null)
                throw new Exception("Cidade Inváilida");
            if (obj.Cep == null)
                throw new Exception("Cep Inváilido");
            if (obj.Dt_Nascimento == null)
                throw new Exception("Data de nascimento Inváilida");

            var dataNow = new DateTime();
            dataNow = DateTime.Now;
            var dia = dataNow.Day - obj.Dt_Nascimento.Day;
            var mes = dataNow.Month - obj.Dt_Nascimento.Month;
            var ano = dataNow.Year - obj.Dt_Nascimento.Year;
            if (ano <= 18 && (mes < 0 || dia < 0))
                throw new Exception("Cliente de ter no mínimo 18 anos");

            _repository.Add(obj);
        }

        public void Update(Cliente obj)
        {
            _repository.Update(obj);
        }

        public Cliente GetCpf(string cpf)
        {
            if (cpf == "undefined")
            {
                throw new System.Exception("Cpf não informado");
            }
            return _repository.GetCpf(cpf);
        }
    }
}