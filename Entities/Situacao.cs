using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TREINA_SITUACAO")]
    public class Situacao : BaseEntity
    {
        [Key]
        [Column("ID_TREINA_SITUACAO")]
        public int Id_Treina_Situacao { get; set; }

        [Column("SITUACAO")]
        public string TipoSituacao { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}