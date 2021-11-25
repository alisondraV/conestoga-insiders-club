using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class ReviewVM
    {
        public ReviewVM(Review review)
        {
            Rating = review.Rating;
            Description = review.Description;
            Approved = review.Approved;
        }


        [Required(ErrorMessage = "Rating is required.")]
        public byte Rating { get; set; }

        [Required(ErrorMessage = "Comment required.")]
        public string Description { get; set; }

        public bool? Approved { get; set; }

        public Review ToModel(Review review)
        {
            review.Rating = Rating;
            review.Description = Description;
            review.Approved = Approved;

            return review;
        }
    }
}
