using System.ComponentModel.DataAnnotations;

namespace Game.Models
{
    public class PlayerVM
    {
        public PlayerVM()
        {

        }

        public int playerID { get; set; }
        public string teamName { get; set; }
        public string teamLocation { get; set; }

        [Required(ErrorMessage = "Please Enter age")]
        public int playerAge { get; set; }

        [Required(ErrorMessage = "Please Enter a name")]
        public string playerName { get; set; }

        [Required(ErrorMessage = "Please Enter the height")]
        public int playerHeight { get; set; }

        [Required(ErrorMessage = "Please Enter the weight")]
        public int playerWeight { get; set; }


        [Required(ErrorMessage = "Please Enter a speed between 1 and 40")]
        public int playerSpeed { get; set; }
    }
}