using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TREINA_PARAMETROS")]
    public class Parametro : BaseEntity
    {
        [Column("ID_TREINA_PARAMETROS")]
        public int Id_Treina_ParametroS { get; set; }

        [Key]
        [Column("ULTIMA_PROPOSTA")]
        public int Ultima_Proposta { get; set; }

        [Column("JURO_COMPOSTO")]
        public int Juro_Composto { get; set; }
    }
}