using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Entities;
using Entities.Dtos;
using Microsoft.Extensions.Configuration;

namespace ORM
{
    public class UsuarioRepository : Connection, Interfaces.IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration config) : base(config) { }

        public void Add(Usuarios obj)
        {
            throw new System.NotImplementedException();
        }

        public Usuarios Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Usuarios> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Usuarios GetCpf(string cpf)
        {
            throw new System.NotImplementedException();
        }

        public string Login(LoginDto obj)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@usuario", obj.Usuario);
            param.Add("@senha", obj.Senha);

            string sql = $@"SELECT [dbo].[F_Verificar_Login](@usuario, @senha)";

            using (var connect = new SqlConnection(base.GetConnection()))
            {
                return connect.QueryFirstOrDefault<string>(sql, param);
            }
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Usuarios obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
