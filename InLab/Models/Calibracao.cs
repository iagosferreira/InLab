using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InLab.Models
{
    [Table("calibracao")]
    public class Calibracao
    {
        [Key]
        [Column("id_cal")]
        public int IdCal { get; set; }

        [Column("id_det")]
        public int IdDet { get; set; }

        [ForeignKey("IdDet")]
        public Detector? Detector { get; set; }

        [Column("data_cal")]
        public DateTime DataCal { get; set; }
    }
}