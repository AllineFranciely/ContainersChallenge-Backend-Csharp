using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContainersChallenge.Models
{
    [Table("containers")]
    public class Container
    {
        public Container()
        {
            Movimentacoes = new Collection<Movimentacao>();
        }

        [Key]
        public int ContainerId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Cliente { get; set; }

        [Required]
        [StringLength(20)]
        public string? Numero { get; set; }

        [Required]
        public int Tipo { get; set; }

        [Required]
        [StringLength(10)]
        public string? Situacao { get; set; }

        [Required]
        [StringLength(20)]
        public string? Categoria { get; set; }

        [JsonIgnore]
        public ICollection<Movimentacao> Movimentacoes { get; set; }

    }
}
