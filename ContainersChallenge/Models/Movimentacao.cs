using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContainersChallenge.Models
{
    [Table("movimentacoes")]
    public class Movimentacao
    {
        [Key]
        public int MovimentacaoId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Tipo { get; set; }

        [Required]
        [StringLength(50)]
        public string? DataInicio { get; set; }

        [Required]
        [StringLength(50)]
        public string? DataFim { get; set; }

        public int ContainerId { get; set; }

        [JsonIgnore]
        public Container? Container { get; set; }
    }
}
