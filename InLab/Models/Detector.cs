using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InLab.Models
{
    [Table("detector")]
    public class Detector
    {
        [Key]
        [Column("id_ade")]
        public int IdAde { get; set; }

        [Column("id_are")]
        public int IdAre { get; set; }

        [ForeignKey("IdAre")]
        public Area? Area { get; set; }

        [Column("cadastro_det")]
        public string CadastroDet { get; set; } = string.Empty;

        [Column("serial_det")]
        public string SerialDet { get; set; } = string.Empty;

        [Column("fabricante_det")]
        public string FabricanteDet { get; set; } = string.Empty;

        [Column("modelo_det")]
        public string ModeloDet { get; set; } = string.Empty;

        [Column("status_uso_det")]
        public string StatusUsoDet { get; set; } = string.Empty;

        [Column("status_co_det")]
        public string StatusCoDet { get; set; } = string.Empty;

        [Column("data_co_det")]
        public DateTime? DataCoDet { get; set; }

        [Column("data_caç_det")]
        public DateTime? DataCacDet { get; set; }

        // Relacionamento: Um detector pode ter várias calibrações
        public List<Calibracao> Calibracoes { get; set; } = new();
    }
}