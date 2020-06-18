using Newtonsoft.Json;
using ProjetoAgendaAPI.Libraries;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAgendaAPI.Models
{
    public class Contato
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "nome")]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MandatoryField")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "sobrenome")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        public string Sobrenome { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        [MinLength(14, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(15, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "id_usuario")]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MandatoryField")]
        public int IdUsuario { get; set; }
    }
}
