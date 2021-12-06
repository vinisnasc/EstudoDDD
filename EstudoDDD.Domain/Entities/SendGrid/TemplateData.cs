using Newtonsoft.Json;

namespace EstudoDDD.Domain.Entities.SendGrid
{
    public class TemplateData
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Weblink")]
        public string Weblink { get; set; }
    }
}
