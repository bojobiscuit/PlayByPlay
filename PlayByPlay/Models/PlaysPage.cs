using System.Collections.Generic;

namespace PlayByPlay.Models
{
    public class PlaysPage
    {
        public int Page { get; set; }
        public IEnumerable<string> Plays { get; set; }
    }
}