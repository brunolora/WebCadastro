using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCadastro.Models
{
    [Table("CadastroPet")]
    public class CadastroPet
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [MaxLength(20)]
        public string Nome { get; set; }

        [Column("Idade")]
        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Column("Peso")]
        [Display(Name = "Peso")]
        public int Peso { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        [MaxLength(40)]
        public string Email { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        [MaxLength(20)]
        public string Telefone { get; set; }
    }
}
