using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TREINA_CLIENTES")]
    public class Propostas : BaseEntity
    {
        [Key]
        [Column("ID_TREINA_PROPOSTA")]
        public int Id_Treina_Proposta { get; set; }

        [Column("PROPOSTA")]
        public int Proposta { get; set; }

        [Required(ErrorMessage = "Cpf é um campo obrigatório.")]
        [Column("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Conveniada é um campo obrigatório.")]
        [Column("CONVENIADA")]
        public string Conveniada { get; set; }

        [Required(ErrorMessage = "Valor solicitado é um campo obrigatório.")]
        [Column("VLR_SOLICITADO")]
        public decimal Vlr_Solicitado { get; set; }

        [Required(ErrorMessage = "Prazo é um campo obrigatório.")]
        [Column("PRAZO")]
        public int Prazo { get; set; }

        [Required(ErrorMessage = "Valor financiado é um campo obrigatório.")]
        [Column("VLR_FINANCIADO")]
        public decimal Vlr_Financiado { get; set; }

        [Required(ErrorMessage = "Situação é um campo obrigatório.")]
        [Column("SITUACAO")]
        public string Situacao { get; set; }

        [Column("OBSERVACAO")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "Data da situação é um campo obrigatório.")]
        [Column("DT_SITUACAO")]
        public DateTime Dt_Situacao { get; set; }

        [Column("USUARIO")]
        public string Usuario { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("SITDESCRICAO")]
        public string SITDescricao { get; set; }
    }
}