using Newtonsoft.Json;
using ProjetoAgendaAPI.Libraries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        [Column("nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "sobrenome")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        [MinLength(14, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(15, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        [Column("telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "id_usuario")]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MandatoryField")]
        [Column("id_usuario")]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
