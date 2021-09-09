using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;

namespace ORM.Repository
{
    public class ConsultaPropostaRepository : Connection, Interfaces.IConsultaPropostaRepository
    {
        public ConsultaPropostaRepository(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<Propostas> GetUser(string usuario)
        {
            try
            {
                // var parameter = new DynamicParameters();
                // parameter.Add("@usuario", usuario);

                IEnumerable<Propostas> listaProposta;
                string sql = $@"SELECT
                                    TP.ID_TREINA_PROPOSTA,
                                    TP.PROPOSTA,
                                    TP.CPF,
                                    TP.CONVENIADA,
                                    TP.VLR_SOLICITADO,
                                    TP.PRAZO,
                                    TP.VLR_FINANCIADO,
                                    TP.SITUACAO,
                                    TP.OBSERVACAO,
                                    TP.DT_SITUACAO,
                                    TP.USUARIO,
                                    TP.USUARIO_ATUALIZACAO,
                                    TP.DATA_ATUALIZACAO,
                                    TCONV.DESCRICAO,
                                    TS.DESCRICAO AS SITDESCRICAO,
                                    TC.NOME
                                FROM [DBO].[TREINA_PROPOSTAS] AS TP
                                INNER JOIN [DBO].[TREINA_CLIENTES] AS TC ON
                                TP.CPF = TC.CPF
                                INNER JOIN [DBO].[TREINA_CONVENIADAS] AS TCONV ON
                                TP.CONVENIADA = TCONV.CONVENIADA
                                INNER JOIN [DBO].[TREINA_SITUACAO] AS TS ON
                                TP.SITUACAO = TS.SITUACAO
                                WHERE USUARIO = '{usuario}'";
                using (var connect = new SqlConnection(base.GetConnection()))
                {
                    listaProposta = connect.Query<Propostas>(sql);
                }
                return listaProposta;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}