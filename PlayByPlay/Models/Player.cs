using System.Collections.Generic;

namespace PlayByPlay.Models
{
    public class Player
    {
        public string Name { get; set; }
        public IEnumerable<int> Stats { get; set; }
    }
}