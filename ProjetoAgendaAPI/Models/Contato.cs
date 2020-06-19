using Newtonsoft.Json;
using ProjetoAgendaAPI.Libraries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoAgendaAPI.Models
{
    [Table("contato")]
    public class Contato
    {
        [JsonProperty(PropertyName = "id")]
        [Column("id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        [Column("email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "nome")]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MandatoryField")]
        [MinLength(2, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        [Column("nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "sobrenome")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        [MaxLength(15, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        [Column("telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MandatoryField")]
        //[Range(1, int.MaxValue, ErrorMessageResourceName = "MandatoryField")]
        [Column("id_usuario")]
        [ForeignKey("Usuario")]
        [JsonPropertyName("id_usuario")]
        [JsonProperty("id_usuario")]
        public int IdUsuario { get; set; }
    }
}
