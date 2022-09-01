using System;
namespace CarRepository.Domain.Models.DTO.BaseModels
{
    public class ResultModel<T>
    {
        public ResultModel(
            T _Data,
            int _Start = 0,
            int _Lenght = 0
            )
        {
            Data = _Data;
            ResultDate = DateTime.Now;
            Start = _Start;
            Lenght = _Lenght;
        }
        public DateTime ResultDate { get; set; }

        public T Data { get; set; }

        public int Start { get; set; }

        public int Lenght { get; set; }
    }
}

