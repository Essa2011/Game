using System;

namespace Game.Models
{
    public class GameVM
    {
        public GameVM()
        {
        }

        public int ID { get; set; }
        public string TeamAName { get;  set; }
        public string TeamBName { get;  set; }
        public DateTime StartTime { get;  set; }
        public DateTime EndTime { get;  set; }
        public string Score { get;  set; }
    }
}