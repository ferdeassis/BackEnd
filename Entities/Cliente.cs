using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TREINA_CLIENTES")]
    public class Cliente : BaseEntity
    {
        [Column("ID_TREINA_CLIENTE")]
        public int Id_Treina_Cliente { get; set; }

        [Key]
        [Required(ErrorMessage = "Cpf é um campo obrigatório.")]
        [Column("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        [Column("NOME")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de nascimento é um campo obrigatório.")]
        [Column("DT_NASCIMENTO")]
        public DateTime Dt_Nascimento { get; set; }

        [Required]
        [Column("GENERO")]
        public char Genero { get; set; }

        [Required(ErrorMessage = "Salário é um campo obrigatório.")]
        [Column("VLR_SALARIO")]
        public decimal Vlr_Salario { get; set; }

        [Required(ErrorMessage = "Logradouro é um campo obrigatório.")]
        [Column("LOGRADOURO")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Número da residência é um campo obrigatório.")]
        [Column("NUMERO_RESIDENCIA")]
        public string Numero_Residencia { get; set; }

        [Required(ErrorMessage = "Bairro é um campo obrigatório.")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é um campo obrigatório.")]
        [Column("CIDADE")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Cep é um campo obrigatório.")]
        [Column("CEP")]
        public string Cep { get; set; }
    }
}