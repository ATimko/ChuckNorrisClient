using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisClient
{
    public class Value
    {
        /// <summary>
        /// The Unique ID of the Joke
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text of the joke
        /// </summary>
        [JsonProperty("joke")]
        public string JokeText { get; set; }

        /// <summary>
        /// Categories the joke belongs to
        /// </summary>
        public List<string> Categories { get; set; }
    }
    public class RandJokeResponse
    {
        public string Type { get; set; }

        [JsonProperty("value")]
        public Value JokeData { get; set; }
    }
}
