using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace drinkW.Models
{
    [Table("tblConsumo")]
    public class Consumo
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime DataConsumo { get; set; }
        [Column("Recipiente")]
        [Display(Name = "Recipiente")]
        public string RecipienteConsumo { get; set; }
        [Column("Tamanho")]
        [Display(Name = "Tamanho")]
        public string TamanhoConsumo { get; set; }

    }
}
