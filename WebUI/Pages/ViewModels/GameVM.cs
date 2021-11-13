﻿using System;
using System.ComponentModel.DataAnnotations;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class GameVM
    {
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

        public static Game ToModel(Game game, GameVM admingameVM)
        {
            game.Name = admingameVM.Name;
            game.Description = admingameVM.Description;
            game.Price = admingameVM.Price;
            game.GenreName = admingameVM.GenreName;

            return game;
        }

        public static GameVM ToViewModel(Game game)
        {
            return new GameVM
            {
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
                GenreName = game.GenreName
            };
        }
    }
}
