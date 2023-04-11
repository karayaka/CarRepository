using System;
namespace CarRepository.Domain.Exceptions
{
	public class NotFoundException:Exception
	{
		public NotFoundException():base("Item Not Found")
		{
		}
		public NotFoundException(string message):base(message)
		{

		}
	}
}

