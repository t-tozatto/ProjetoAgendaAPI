using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAgendaAPI.Models
{
    public class Usuario
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Index("EmailIndex", IsUnique = true)]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Index("NomeIndex", IsUnique = true)]
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "senha")]
        public string Senha { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public byte[] Foto { get; set; }
    }
}
