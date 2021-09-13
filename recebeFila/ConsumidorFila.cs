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
            //await Console.Out.WriteLineAsync(context.Message.Proposta.ToString());
            var prazo = context.Message.Prazo;
            var dataNow = new DateTime();
            dataNow = DateTime.Now;
            var dia = dataNow.Day - context.Message.Dt_Nascimento.Day;
            var mes = dataNow.Month - context.Message.Dt_Nascimento.Month;
            var ano = dataNow.Year - context.Message.Dt_Nascimento.Year;
            var addIdade = context.Message.Prazo / 12;
            var idadeFinal = ano + addIdade;
            var mesFinal = mes + (context.Message.Prazo % 12);

            var parameters = new DynamicParameters();
            parameters.Add("@conveniada", context.Message.Conveniada);
            parameters.Add("@idadeFinal", idadeFinal);

            string sql = $@"SELECT
                                ID_TREINA_LIM_IDADE_CONVENIADA,
                                CONVENIADA,
                                IDADE_INICIAL,
                                IDADE_INICIAL,
                                VALOR_LIMITE,
                                PERCENTUAL_MAXIMO_ANALISE, USUARIO_ATUALIZACAO,
                                DATA_ATUALIZACAO
                            FROM [dbo].[TREINA_LIMITES_IDADE_CONVENIADA]
                            WHERE CONVENIADA = '@conveniada' AND IDADE_FINAL < = @idadeFinal";
            using (var connect = new SqlConnection(base)
            {
                connect.Execute(sql, parameters);
        }
    }
}
}