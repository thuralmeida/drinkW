using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace drinkW.Models
{
    [Table("tblRecipiente")]
    public class Recipiente
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Foto")]
        [Display(Name = "Foto")]
        public string Foto { get; set; }

        [Column("Tamanho")]
        [Display(Name = "Tamanho")]
        public string Tamanho { get; set; }
    }
}
