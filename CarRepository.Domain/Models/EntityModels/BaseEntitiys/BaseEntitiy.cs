using System;
using System.ComponentModel.DataAnnotations;
using CarRepository.Domain.Enums;

namespace CarRepository.Domain.Models.EntityModels.BaseEntitiys
{
    public class BaseEntitiy
    {
        public BaseEntitiy()
        {
            CreatedDate = DateTime.Now;
            Status = Status.NonDeleted;
        }

        [Key]
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public Status Status { get; set; }
    }
}

