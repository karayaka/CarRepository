using System;
using System.ComponentModel.DataAnnotations;

namespace CarRepository.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Silindi")]
        Deleted = 0,
        [Display(Name = "Silinmedi")]
        NonDeleted = 1,
    }
}

