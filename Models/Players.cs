using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Players
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter player's name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter player's age")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Please enter player's height")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Please enter player's height")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Please enter player's speed between 1 and 40")]
        public int Speed { get; set; }
        [Required(ErrorMessage = "Please enter player's team ID")]
        public int TeamsId { get; set; }
        public Teams Team { get; set; }
    }

}
