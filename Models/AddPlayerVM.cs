using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class AddPlayerVM
    {
        [Required(ErrorMessage = "Please Enter player's Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter player's age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter player's height")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Please enter player's weight")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Please enter player's speed between 1 and 40")]
        public int Speed { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public List<Teams> teams { get; set; }


    }
}
