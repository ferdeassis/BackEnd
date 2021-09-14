using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace recebeFila.Entities
{
    [Table("TREINA_PROPOSTAS")]
    public class PropostaFila
    {
        [Column("ID_TREINA_PROPOSTA")]
        public int Id_Treina_Proposta { get; set; }

        [Column("PROPOSTA")]
        public int Proposta { get; set; }

        [Column("CPF")]
        public string Cpf { get; set; }

        [Column("CONVENIADA")]
        public string Conveniada { get; set; }

        [Column("VLR_SOLICITADO")]
        public decimal Vlr_Solicitado { get; set; }

        [Column("PRAZO")]
        public int Prazo { get; set; }

        [Column("VLR_FINANCIADO")]
        public decimal Vlr_Financiado { get; set; }

        [Column("SITUACAO")]
        public string Situacao { get; set; }

        [Column("OBSERVACAO")]
        public string Observacao { get; set; }

        [Column("DT_SITUACAO")]
        public DateTime Dt_Situacao { get; set; }

        [Column("USUARIO")]
        public string Usuario { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}