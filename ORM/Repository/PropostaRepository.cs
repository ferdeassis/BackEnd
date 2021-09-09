using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;

namespace ORM.Repository
{
    public class PropostaRepository : Connection, Interfaces.IPropostaRepository
    {
        public PropostaRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Propostas obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@proposta", obj.Proposta);
                parameters.Add("@cpf", obj.Cpf);
                parameters.Add("@conveniada", obj.Conveniada);
                parameters.Add("@vlrSolicitado", obj.Vlr_Solicitado);
                parameters.Add("@prazo", obj.Prazo);
                parameters.Add("@vlrFinanciado", obj.Vlr_Financiado);
                parameters.Add("@situacao", obj.Situacao);
                //parameters.Add("@observacao", obj.Observacao);
                parameters.Add("@dtSituacao", DateTime.Now);
                parameters.Add("@usuario", obj.Usuario);
                parameters.Add("@usuarioAtualizacao", obj.Usuario_Atualizacao);
                parameters.Add("@dtAtualizacao", DateTime.Now);

                string sql = $@"INSERT INTO [dbo].[TREINA_PROPOSTAS]
                                (
                                    PROPOSTA,
                                    CPF,
                                    CONVENIADA,
                                    VLR_SOLICITADO,
                                    PRAZO,
                                    VLR_FINANCIADO,
                                    SITUACAO,
                                    DT_SITUACAO,
                                    USUARIO,
                                    USUARIO_ATUALIZACAO,
                                    DATA_ATUALIZACAO
                                )VALUES
                                (
                                    @proposta,
                                    @cpf,
                                    @conveniada,
                                    @vlrSolicitado,
                                    @prazo,
                                    @vlrFinanciado,
                                    @situacao,
                                    @dtSituacao,
                                    @usuario,
                                    @usuarioAtualizacao,
                                    @dtAtualizacao
                                )";
                using (var connect = new SqlConnection(base.GetConnection()))
                {
                    connect.Execute(sql, parameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Propostas> GetUser(string usuario)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@usuario", usuario);

            IEnumerable<Propostas> listaProposta;
            string sql = $@"SELECT
                                ID_TREINA_PROPOSTA,
                                PROPOSTA,
                                CPF,
                                CONVENIADA,
                                VLR_SOLICITADO,
                                PRAZO,
                                VLR_FINANCIADO,
                                SITUACAO,
                                OBSERVACAO,
                                DT_SITUACAO,
                                USUARIO,
                                USUARIO_ATUALIZACAO,
                                DATA_ATUALIZACAO
                            FROM [DBO].[TREINA_PROPOSTAS]
                            WHERE USUARIO = '@usuario'";
            using (var connect = new SqlConnection(base.GetConnection()))
            {
                listaProposta = connect.Query<Propostas>(sql);
            }
            return listaProposta;
        }
        public Propostas GetCpf(string cpf)
        {
            try
            {
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
                            WHERE TP.CPF = {cpf}";
                using (var connect = new SqlConnection(base.GetConnection()))
                {
                    return connect.QueryFirstOrDefault<Propostas>(sql);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Propostas obj)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@convenio", obj.Conveniada);
            parameter.Add("@vlrSolicitado", obj.Vlr_Solicitado);
            parameter.Add("@vlrFinanciado", obj.Vlr_Financiado);
            parameter.Add("@situacao", obj.Situacao);
            parameter.Add("@dtSituacao", DateTime.Now);
            parameter.Add("@dtAtualizacao", DateTime.Now);
            parameter.Add("@prazo", obj.Prazo);
            parameter.Add("@cpf", obj.Cpf);

            string sql = $@"UPDATE [dbo].[TREINA_PROPOSTAS]
                            SET
                                PRAZO = @prazo,
                                CONVENIADA = @convenio,
                                VLR_SOLICITADO = @vlrSolicitado,
                                VLR_FINANCIADO = @vlrFinanciado,
                                SITUACAO = @situacao,
                                DT_SITUACAO = @dtSituacao,
                                DATA_ATUALIZACAO = @dtAtualizacao
                            WHERE CPF = @cpf";
            using (var connect = new SqlConnection(base.GetConnection()))
            {
                connect.Execute(sql, parameter);
            }
        }
    }
}