using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;

namespace ORM.Repository
{
    public class ParametroRepository : Connection, Interfaces.IParametroRepository
    {
        public ParametroRepository(IConfiguration configuration) : base(configuration) { }

        public Parametro GetParametro()
        {
            string sql = $@"SELECT 
                                ID_TREINA_PARAMETROS, 
                                ULTIMA_PROPOSTA, 
                                JURO_COMPOSTO, 
                                USUARIO_ATUALIZACAO, 
                                DATA_ATUALIZACAO 
                            FROM [dbo].[TREINA_PARAMETROS]";
            using (var connect = new SqlConnection(base.GetConnection()))
            {
                return connect.Query<Parametro>(sql).FirstOrDefault();
            }
        }

        public void Update(Parametro obj)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@proposta", obj.Ultima_Proposta);
            parameter.Add("@dtAtualizacao", DateTime.Now);

            string sql = $@"UPDATE [dbo].[TREINA_PARAMETROS]
                         SET
                            ULTIMA_PROPOSTA = @proposta,
                            DATA_ATUALIZACAO = @dtAtualizacao
                         WHERE ID_TREINA_PARAMETROS = 1";
            using (var connect = new SqlConnection(base.GetConnection()))
            {
                connect.Execute(sql, parameter);
            }
        }
    }
}