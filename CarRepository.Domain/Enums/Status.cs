using System;
using System.ComponentModel.DataAnnotations;

namespace CarRepository.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Deleted")]
        Deleted = 0,
        [Display(Name = "NonDeleted")]
        NonDeleted = 1,
    }
}

