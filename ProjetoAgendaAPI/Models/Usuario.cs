using Newtonsoft.Json;
using ProjetoAgendaAPI.Libraries;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAgendaAPI.Models
{
    public class Usuario
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MandatoryField")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "nome")]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MandatoryField")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "senha")]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MandatoryField")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MinLength")]
        [MaxLength(40, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MaxLength")]
        public string Senha { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public byte[] Foto { get; set; }
    }
}
