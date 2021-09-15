using System;
using System.Threading.Tasks;
using Entities;
using MassTransit;
using Dapper;
using Microsoft.Data.SqlClient;

namespace recebeFila
{
    public class ConsumidorFila : IConsumer<DadosFila>
    {
        public async Task Consume(ConsumeContext<DadosFila> context)
        {
            var filaProposta = context.Message.Proposta;
            var prazo = context.Message.Prazo;
            var conveniada = context.Message.Conveniada;
            var vlrFin = context.Message.Vlr_Financiado;

            var dataNow = new DateTime();
            dataNow = DateTime.Now;
            var dia = dataNow.Day - context.Message.Dt_Nascimento.Day;
            var mes = dataNow.Month - context.Message.Dt_Nascimento.Month;
            var ano = dataNow.Year - context.Message.Dt_Nascimento.Year;
            var addIdade = context.Message.Prazo / 12;
            var idadeFinal = ano + addIdade;
            var mesFinal = mes + (context.Message.Prazo % 12);

            var limiteIdadeConveniada = await BuscarLimites(conveniada, idadeFinal);
            if (limiteIdadeConveniada == null)
            {
                UpdateNegado(filaProposta, "RE");
                return;
            }

            var valorLimite = limiteIdadeConveniada.Valor_Limite + (limiteIdadeConveniada.Valor_Limite / limiteIdadeConveniada.Percentual_Maximo_Analise);

            if (idadeFinal > limiteIdadeConveniada.Idade_Final)
            {
                UpdateNegado(filaProposta, "RE");
                return;
            }

            if (idadeFinal >= limiteIdadeConveniada.Idade_Inicial && idadeFinal <= limiteIdadeConveniada.Idade_Final)
            {

                if (limiteIdadeConveniada.Valor_Limite > vlrFin)
                {
                    UpdateNegado(filaProposta, "AP");
                    return;
                }
                if (vlrFin > limiteIdadeConveniada.Valor_Limite && vlrFin <= valorLimite)
                {
                    var observacao = "Proposta acima do valor limite";
                    UpdateObservacao(filaProposta, observacao, "AN");
                    return;
                }
                if (vlrFin > valorLimite)
                {
                    UpdateNegado(filaProposta, "PE");
                    return;
                }
            }
        }

        public async Task<LimiteIdadeConveniada> BuscarLimites(string conveniada, int idadeFinal)
        {
            var connectionString = "Server=localhost;Initial Catalog=Projeto;MultipleActiveResultSets=true; Trusted_Connection=True";
            LimiteIdadeConveniada retorno;
            var parameters = new DynamicParameters();
            parameters.Add("@conveniada", conveniada);
            parameters.Add("@idadeFinal", idadeFinal);
            try
            {
                string sql = $@"SELECT
                                ID_TREINA_LIM_IDADE_CONVENIADA,
                                CONVENIADA,
                                IDADE_INICIAL,
                                IDADE_FINAL,
                                VALOR_LIMITE,
                                PERCENTUAL_MAXIMO_ANALISE,
                                USUARIO_ATUALIZACAO,
                                DATA_ATUALIZACAO
                            FROM [dbo].[TREINA_LIMITES_IDADE_CONVENIADA]
                            WHERE CONVENIADA = @conveniada AND (@idadeFinal BETWEEN IDADE_INICIAL AND IDADE_FINAL)";
                using (var connect = new SqlConnection(connectionString))
                {
                    retorno = await connect.QueryFirstOrDefaultAsync<LimiteIdadeConveniada>(sql, parameters);
                }
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateNegado(int proposta, string situacao)
        {
            try
            {
                var connectionString = "Server=localhost;Initial Catalog=Projeto;MultipleActiveResultSets=true; Trusted_Connection=True";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@proposta", proposta);
                parameter.Add("@situacao", situacao);
                parameter.Add("@dtSituacao", DateTime.Now);
                parameter.Add("@dtAtualizacao", DateTime.Now);

                string sql = $@"UPDATE [dbo].[TREINA_PROPOSTAS]
                            SET
                                SITUACAO = @situacao,
                                DT_SITUACAO = @dtSituacao,
                                DATA_ATUALIZACAO = @dtAtualizacao
                            WHERE PROPOSTA = @proposta";
                using (var connect = new SqlConnection(connectionString))
                {
                    connect.Execute(sql, parameter);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateObservacao(int proposta, string observacao, string situacao)
        {
            try
            {
                var connectionString = "Server=localhost;Initial Catalog=Projeto;MultipleActiveResultSets=true; Trusted_Connection=True";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@proposta", proposta);
                parameter.Add("@observacao", observacao);
                parameter.Add("@situacao", situacao);
                parameter.Add("@dtSituacao", DateTime.Now);
                parameter.Add("@dtAtualizacao", DateTime.Now);

                string sql = $@"UPDATE [dbo].[TREINA_PROPOSTAS]
                            SET
                                OBSERVACAO = @observacao,
                                SITUACAO = @situacao,
                                DT_SITUACAO = @dtSituacao,
                                DATA_ATUALIZACAO = @dtAtualizacao
                            WHERE PROPOSTA = @proposta";
                using (var connect = new SqlConnection(connectionString))
                {
                    connect.Execute(sql, parameter);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}