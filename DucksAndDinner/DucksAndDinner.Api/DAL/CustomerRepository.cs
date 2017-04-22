using System.Data;
using Dapper;
using DucksAndDinner.Api.Controllers;
using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Save(Customer newCustomer)
        {
            var sql = @"Insert into Customer(username,firstname,lastname,password,numberofduckspertypicalmeal)
                        Values(@username,@firstname,@lastname,@password,@numberofduckspertypicalmeal)";

            _dbConnection.Execute(sql, newCustomer);
        }
    }
}