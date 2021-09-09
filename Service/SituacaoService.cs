using System.Collections.Generic;
using AutoMapper;
using Entities;
using ORM.Interfaces;

namespace Service
{
    public class SituacaoService
    {
        private ISituacaoRepository _situacaoRepository;
        public SituacaoService(ISituacaoRepository situacaoRepository, IMapper mapper)
        {
            _situacaoRepository = situacaoRepository;
        }

        public IEnumerable<Situacao> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}