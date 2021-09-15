using System.ComponentModel.DataAnnotations.Schema;

namespace recebeFila
{
    [Table("TREINA_LIMITES_IDADE_CONVENIADA")]
    public class LimiteIdadeConveniada
    {
        [Column("ID_TREINA_LIM_IDADE_CONVENIADA")]
        public int Id_Treina_Lim_Idade_Conveniada { get; set; }

        [Column("CONVENIADA")]
        public string Conveniada { get; set; }

        [Column("IDADE_INICIAL")]
        public int Idade_Inicial { get; set; }

        [Column("IDADE_INICIAL")]
        public int Idade_Final { get; set; }

        [Column("VALOR_LIMITE")]
        public decimal Valor_Limite { get; set; }

        [Column("PERCENTUAL_MAXIMO_ANALISE")]
        public int Percentual_Maximo_Analise { get; set; }
    }
}