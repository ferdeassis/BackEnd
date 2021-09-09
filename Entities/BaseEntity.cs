using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public abstract class BaseEntity
    {
        [Required]
        [Column("USUARIO_ATUALIZACAO")]
        public string Usuario_Atualizacao { get; set; }

        [Required]
        [Column("DATA_ATUALIZACAO")]
        public DateTime Data_Atualizacao { get; set; }
    }
}