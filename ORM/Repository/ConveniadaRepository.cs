using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;

namespace ORM.Repository
{
    public class ConveniadaRepository : Connection, Interfaces.IConveniadaRepository
    {
        public ConveniadaRepository(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<Conveniadas> GetAll()
        {
            IEnumerable<Conveniadas> dadosConveniada;
            string sql = $@"SELECT
                                ID_TREINA_CONVENIADA,
                                CONVENIADA,
                                DESCRICAO,
                                USUARIO_ATUALIZACAO,
                                DATA_ATUALIZACAO
                            FROM [dbo].[TREINA_CONVENIADAS]";
            using (var connect = new SqlConnection(base.GetConnection()))
            {
                dadosConveniada = connect.Query<Conveniadas>(sql);
            }
            return dadosConveniada;
        }

        public Conveniadas GetDescricao(string conveniada)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@conveniada", conveniada);
            try
            {
                string sql = $@"SELECT
                                ID_TREINA_CONVENIADA,
                                CONVENIADA,
                                DESCRICAO,
                                USUARIO_ATUALIZACAO,
                                DATA_ATUALIZACAO
                            FROM [dbo].[TREINA_CONVENIADAS]
                            WHERE CONVENIADA = @conveniada";
                using (var connect = new SqlConnection(base.GetConnection()))
                {
                    return connect.QueryFirstOrDefault<Conveniadas>(sql, parameter);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}