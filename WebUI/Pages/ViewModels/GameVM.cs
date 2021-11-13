using System;
using System.ComponentModel.DataAnnotations;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class GameVM
    {
        public GameVM(Game game)
        {
            Name = game.Name;
            Description = game.Description;
            Price = game.Price;
            GenreName = game.GenreName;
        }

        [StringLength(50)]
        [Required(ErrorMessage = "Game Name is required")]
        [MinLength(3, ErrorMessage = "Game name should be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "Game name should be less than 50 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Game Description is required")]
        [MaxLength(50, ErrorMessage = "Game description should be less than 100 characters long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Game Price is required")]
        [Range(1, 500, ErrorMessage = "Game Price should be within 1 to 500$")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Game Genre is required")]
        public string GenreName { get; set; }

        public Game ToModel(Game game)
        {
            game.Name = Name;
            game.Description = Description;
            game.Price = Price;
            game.GenreName = GenreName;

            return game;
        }
    }
}
