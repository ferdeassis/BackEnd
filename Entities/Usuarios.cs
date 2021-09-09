using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TREINA_USUARIOS")]
    public class Usuarios : BaseEntity
    {
        [Key]
        [Required]
        [Column("USUARIO")]
        public string Usuario { get; set; }

        [Required]
        [Column("SENHA")]
        public string Senha { get; set; }
    }
}