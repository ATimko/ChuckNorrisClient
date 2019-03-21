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
        public string Joke { get; set; }

        /// <summary>
        /// Categories the joke belongs to
        /// </summary>
        public List<object> Categories { get; set; }
    }
    public class RandJokeResponse
    {
        public string Type { get; set; }
        public Value Value { get; set; }
    }
}
