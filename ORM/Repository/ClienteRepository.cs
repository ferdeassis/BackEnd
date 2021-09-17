using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;

namespace ORM
{
    public class ClienteRepository : Connection, Interfaces.IClienteRepository
    {
        public ClienteRepository(IConfiguration config) : base(config) { }
        public void Add(Cliente obj)
        {
            DynamicParameters pam = new DynamicParameters();
            pam.Add("@cpf", obj.Cpf);
            pam.Add("@nome", obj.Nome);
            pam.Add("@dt_nascimento", obj.Dt_Nascimento);
            pam.Add("@genero", obj.Genero);
            pam.Add("@vlr_salario", obj.Vlr_Salario);
            pam.Add("@logradouro", obj.Logradouro);
            pam.Add("@numero_residencia", obj.Numero_Residencia);
            pam.Add("@bairro", obj.Bairro);
            pam.Add("@cidade", obj.Cidade);
            pam.Add("@cep", obj.Cep);
            pam.Add("@usuario_atualizacao", obj.Usuario_Atualizacao);
            pam.Add("@data_atualizacao", DateTime.Now);
            string sql = $@"INSERT INTO [dbo].[TREINA_CLIENTES]
                            (
                                CPF,
                                NOME,
                                DT_NASCIMENTO,
                                GENERO,
                                VLR_SALARIO,
                                LOGRADOURO,
                                NUMERO_RESIDENCIA,
                                BAIRRO,
                                CIDADE,
                                CEP,
                                USUARIO_ATUALIZACAO,
                                DATA_ATUALIZACAO
                            )VALUES
                            (
                                @cpf,
                                @nome,
                                @dt_nascimento,
                                @genero,
                                @vlr_salario,
                                @logradouro,
                                @numero_residencia,
                                @bairro,
                                @cidade,
                                @cep,
                                @usuario_atualizacao,
                                @data_atualizacao
                            )";
            using (var connect = new SqlConnection(base.GetConnection()))
            {
                connect.Execute(sql, pam);
            }
        }
        public Cliente GetCpf(string cpf)
        {
            string sql = $@"SELECT
                            ID_TREINA_CLIENTE,
                            CPF,
                            NOME,
                            FORMAT (DT_NASCIMENTO, 'dd/MM/yyyy') AS DT_NASCIMENTO,
                            GENERO,
                            VLR_SALARIO,
                            LOGRADOURO,
                            NUMERO_RESIDENCIA,
                            BAIRRO,
                            CIDADE,
                            CEP,
                            USUARIO_ATUALIZACAO,
                            DATA_ATUALIZACAO
                         FROM [dbo].[TREINA_CLIENTES]
                         WHERE CPF = {cpf}";

            using (var connect = new SqlConnection(base.GetConnection()))
            {
                return connect.Query<Cliente>(sql).FirstOrDefault();
            }
        }

        public void Update(Cliente obj)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@cpf", obj.Cpf);
            param.Add("@nome", obj.Nome);
            param.Add("@dt_nascimento", obj.Dt_Nascimento);
            param.Add("@genero", obj.Genero);
            param.Add("@vlr_salario", obj.Vlr_Salario);
            param.Add("@logradouro", obj.Logradouro);
            param.Add("@numero_residencia", obj.Numero_Residencia);
            param.Add("@bairro", obj.Bairro);
            param.Add("@cidade", obj.Cidade);
            param.Add("@cep", obj.Cep);
            param.Add("@usuario_atualizacao", obj.Usuario_Atualizacao);
            param.Add("@data_atualizacao", DateTime.Now);

            string sql = $@"UPDATE [dbo].[TREINA_CLIENTES]
                         SET
                            NOME = @nome,
                            DT_NASCIMENTO = @dt_nascimento,
                            GENERO = @genero,
                            VLR_SALARIO = @vlr_salario,
                            LOGRADOURO = @logradouro,
                            NUMERO_RESIDENCIA = @numero_residencia,
                            BAIRRO = @bairro,
                            CIDADE = @cidade,
                            CEP = @cep,
                            USUARIO_ATUALIZACAO = @usuario_atualizacao,
                            DATA_ATUALIZACAO = @data_atualizacao
                         WHERE CPF = @cpf";
            using (var connect = new SqlConnection(base.GetConnection()))
            {
                connect.Execute(sql, param);
            }
        }
    }
}