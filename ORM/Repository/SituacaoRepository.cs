using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;

namespace ORM.Repository
{
    public class SituacaoRepository : Connection, Interfaces.ISituacaoRepository
    {
        public SituacaoRepository(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<Situacao> GetAll()
        {
            IEnumerable<Situacao> dadosSituacao;
            string sql = $@"SELECT
	                            ID_TREINA_SITUACAO,
	                            SITUACAO as TIPOSITUACAO,
                                DESCRICAO,
                                USUARIO_ATUALIZACAO,
                                DATA_ATUALIZACAO
                            FROM [dbo].[TREINA_SITUACAO]";
            using (var connect = new SqlConnection(base.GetConnection()))
            {
                dadosSituacao = connect.Query<Situacao>(sql);
            }
            return dadosSituacao;
        }

        public Situacao GetDescricao(string situacao)
        {
            try
            {
                var parametros = new DynamicParameters();
                parametros.Add("@situacao", situacao);
                string sql = $@"SELECT
	                            ID_TREINA_SITUACAO,
	                            SITUACAO as TIPOSITUACAO,
                                DESCRICAO,
                                USUARIO_ATUALIZACAO,
                                DATA_ATUALIZACAO
                            FROM [dbo].[TREINA_SITUACAO]
                            WHERE SITUACAO = @situacao";
                using (var connect = new SqlConnection(base.GetConnection()))
                {
                    return connect.QueryFirstOrDefault<Situacao>(sql, parametros);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}