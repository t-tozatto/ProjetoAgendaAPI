using Newtonsoft.Json;

namespace ProjetoAgendaAPI.Models
{
    public class Usuario
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "senha")]
        public string Senha { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public byte[] Foto { get; set; }
    }
}
