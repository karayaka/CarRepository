using System;
using CarRepository.DAL.CarRepositoryContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace CarRepository.DAL.Registrations
{//I'm a mac user and framework make mistake when migration, because of I switch design patter  
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CarRepositoryDataContext>
    {
        public CarRepositoryDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CarRepositoryDataContext>();
            var connectionString = "server = 213.238.183.40;port=3306;database=cagnazco_testDb;user=coffeStore;password=Kara.55315531*;SslMode = none";//cagnazcom
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            builder.UseMySql(connectionString,serverVersion);
            //builder.UseMySQL(connectionString);
            return new CarRepositoryDataContext(builder.Options);
        }
    }
}

