using DAL;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLogic
{
    public class Logic:IBusinessLogic
    {
        private readonly CarRepository _carRepository;
        private readonly IRepository<User> _userRepository;
        //private readonly SqlCommand _command;
        private readonly SqlConnection _connection;

        public Logic(IRepository<Car> carRepository, 
            IRepository<User> userRepository)
            //SqlCommand command)
        {
            _carRepository = (CarRepository)carRepository;
            _userRepository = userRepository;
            //_command = command;
        }

        public ProductDetails GetProductsDetailedList(int productId, int UserId)
        {
            _carRepository.OpenConnection();
            ProductDetails product = new ProductDetails();
            string commandText = "SELECT Mark, CarModel, Year, Vin, DateAdded, Username " +
                $"FROM Users join Cars on Cars.UserID=Users.ID and Cars.ID={productId}";
            _carRepository._command.CommandText = commandText;
            using (SqlDataReader reader = _carRepository._command.ExecuteReader())
            {
                while (reader.Read())
                {
                    product.Mark = (string)reader["Mark"];
                    product.CarModel = (string)reader["CarModel"];
                    product.Year = (int)reader["Year"];
                    product.Vin = (string)reader["Vin"];
                    product.DateAdded = (DateTime)reader["DateAdded"];
                    product.Owner = (string)reader["Username"];
                }
            }
            _carRepository.CloseConnection();
            return product;
        }

        public bool GetUserRoleByUsername(string username)
        {
            _userRepository.OpenConnection();
            string commandText = $"Select IsAdmin from Users where Username = '{username}'";
            _carRepository._command.CommandText = commandText;
            bool isAdmin = false;
            using (SqlDataReader reader = _carRepository._command.ExecuteReader())
            {
                while (reader.Read())
                {
                    isAdmin = (bool)reader[0];
                }
            }
            _userRepository.CloseConnection();
            return isAdmin;
        }

        public bool ValidateUser(string username, string password, out bool isAdmin, out int id)
        {
            _userRepository.OpenConnection();
            string commandText = $"SELECT ID, IsAdmin FROM Users WHERE Username = '{username}' " +
                $"and Password = '{password}'";
            _carRepository._command.CommandText = commandText;
            isAdmin = false;
            id = -1;
            using (SqlDataReader reader = _carRepository._command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.FieldCount > 0)
                    {
                        isAdmin = (bool)reader["IsAdmin"];
                        id = (int)reader["ID"];
                    }
                }
            }
            _userRepository.CloseConnection();
            return id > 0;
        }
    }
}
