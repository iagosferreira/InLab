using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InLab.Models
{

    [Table("area")]
    public class Area
    {
        [Key]
        [Column("id_are")]
        public int IdAre { get; set; }

        [Column("nome_are")]
        public string NomeAre { get; set; } = string.Empty;

        // relacionamento: uma áre pode ter varios detectores

        public List<Detector> Detectores { get; set; } = new();
    }
}
