using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Games
    {
        public int Id { get; set; }
        [Required]
        public int teamA { get; set; }
        [Required]
        public int teamB { get; set; }
        [Required]
        public DateTime startTime { get; set; }
        [Required]
        public DateTime endTime { get; set; }
        public string score { get; set; }
        //public Teams Teams { get; set; }
    }
}
