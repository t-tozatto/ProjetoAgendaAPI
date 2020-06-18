using Newtonsoft.Json;

namespace ProjetoAgendaAPI.Models
{
    public class Contato
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "sobrenome")]
        public string Sobrenome { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "id_usuario")]
        public int IdUsuario { get; set; }
    }
}
