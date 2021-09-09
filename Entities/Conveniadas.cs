using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TREINA_CONVENIADAS")]
    public class Conveniadas : BaseEntity
    {
        [Column("ID_TREINA_CONVENIADA")]
        public int Id_Treina_Conveniada { get; set; }

        [Column("CONVENIADA")]
        public string Conveniada { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}